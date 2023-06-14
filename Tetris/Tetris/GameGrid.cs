namespace Tetris
{
    public class GameGrid // Le code commence par définir un espace de noms (namespace) appelé "Tetris". Ensuite, il définit une classe interne (internal) appelée "GameGrid" qui représente la grille de jeu. La classe "GameGrid" a une variable privée (private) de type tableau multidimensionnel (int[,]) appelée "grid". Cette variable stocke les valeurs de la grille du jeu Tetris. Il y a aussi deux propriétés publiques (public) "Rows" et "Columns" qui donnent le nombre de lignes et de colonnes de la grille respectivement.
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        public int this[int r, int c] // Cette ligne de code définit un indexeur (indexer) pour la classe "GameGrid". Cela permet d'accéder aux éléments de la grille en utilisant la syntaxe "grille[r, c]". La partie "get => grid[r, c];" permet d'obtenir la valeur de la case de la grille à la position (r, c), et la partie "set => grid[r, c] = value;" permet de définir la valeur de cette case.
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int rows, int columns) // Le constructeur de la classe "GameGrid" prend en paramètres le nombre de lignes et de colonnes de la grille et initialise les propriétés "Rows" et "Columns" avec ces valeurs. Il crée également un nouveau tableau 2D (int[rows, columns]) pour stocker les valeurs de la grille.
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        public bool IsInside(int r, int c) //Cette méthode "IsInside" vérifie si une position donnée (r, c) se trouve à l'intérieur des limites de la grille. Elle retourne "true" si la position est à l'intérieur et "false" sinon. 
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        public bool IsEmpty(int r, int c) // La méthode "IsEmpty" vérifie si une case donnée (r, c) est vide. Elle utilise la méthode "IsInside" pour vérifier si la case se trouve à l'intérieur de la grille, puis vérifie si la valeur de la case est égale à 0. Elle retourne "true" si la case est vide et "false" sinon.
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        public bool IsRowFull(int r) // La méthode "IsRowFull" vérifie si une ligne donnée (r) est entièrement remplie. Elle parcourt chaque colonne de la ligne et si une case contient la valeur 0, cela signifie que la ligne n'est pas entièrement remplie, donc elle retourne "false". Si toutes les cases de la ligne sont différentes de 0, alors la ligne est entièrement remplie et elle retourne "true".
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsRowEmpty(int r) // La méthode "IsRowEmpty" vérifie si une ligne donnée (r) est vide. Elle parcourt chaque colonne de la ligne et si une case contient une valeur différente de 0, cela signifie que la ligne n'est pas vide, donc elle retourne "false". Si toutes les cases de la ligne sont égales à 0, alors la ligne est vide et elle retourne "true".
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void ClearRow(int r) // La méthode privée "CLearRow" efface une ligne donnée (r) en réinitialisant toutes les cases de cette ligne à 0.
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        private void MoveRowDown(int r, int numRows) // La méthode privée "MoveRowDown" déplace une ligne donnée (r) vers le bas en remplaçant les valeurs des cases de la ligne (r) par les valeurs des cases de la ligne (r + numRows). Les cases de la ligne (r) sont ensuite réinitialisées à 0.
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows() // La méthode "ClearFullRows" efface toutes les lignes entièrement remplies de la grille et retourne le nombre de lignes effacées. Elle parcourt les lignes de bas en haut (de Rows-1 à 0) et utilise les méthodes "IsRowFull", "CLearRow" et "MoveRowDown" pour effacer les lignes remplies et déplacer les lignes au-dessus vers le bas si nécessaire.
        {
            int cleared = 0;

            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }
    }
}



