using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public abstract class Block // La classe abstraite "Block" définit trois membres abstraits : "Tiles", "StartOffset" et "Id". Ces membres doivent être implémentés dans les classes dérivées de "Block" pour définir les spécificités de chaque type de bloc. "Tiles" est un tableau bidimensionnel de positions représentant les tuiles du bloc dans différentes rotations. "StartOffset" est la position de départ du bloc. "Id" est un identifiant unique pour le bloc.
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int Id { get; }

        // La classe "Block" contient deux champs privés : "rotationState" de type entier et "offset" de type "Position". "rotationState" représente l'état de rotation actuel du bloc. "offset" représente le décalage du bloc par rapport à sa position de référence.

        private int rotationState;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePositions() // La méthode publique "TilePositions()" retourne un énumérable d'objets "Position". Cette méthode itère sur les positions des tuiles du bloc correspondant à l'état de rotation actuel (défini par "rotationState"). Pour chaque position "p" dans "Tiles[rotationState]", la méthode crée une nouvelle instance de la classe "Position" en ajoutant les valeurs de "p.Row" et "p.Column" à "offset.Row" et "offset.Column" respectivement, et la retourne à l'aide de l'instruction "yield return".

        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        // Les méthodes "RotateCW()" et "RotateCCW()" permettent de faire pivoter le bloc dans le sens des aiguilles d'une montre (CW) et dans le sens inverse des aiguilles d'une montre (CCW) respectivement. Dans "RotateCW()", "rotationState" est incrémenté de 1, et si la nouvelle valeur dépasse la longueur du tableau "Tiles", elle est ramenée à 0 en utilisant l'opération de modulo (%).
        // Dans "RotateCCW()", "rotationState" est décrémenté de 1, et si la valeur actuelle est 0, elle est définie sur la longueur du tableau "Tiles" moins 1 pour assurer une rotation correcte dans le sens inverse.

        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        // La méthode "Move()" permet de déplacer le bloc en ajustant les valeurs de "offset.Row" et "offset.Column" en fonction des nombres de lignes (rows) et de colonnes (columns) spécifiés.
        // La méthode "Reset()" réinitialise l'état du bloc en rétablissant "rotationState" à 0 et en remettant "offset.Row" et "offset.Column" à leurs valeurs initiales définies par "StartOffset.Row" et "StartOffset.Column".

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}



// En résumé, ce code permet de créer une structure de base pour les blocs du jeu Tetris, en définissant des fonctionnalités communes à tous les types de blocs. Les classes dérivées pour chaque type de bloc peuvent implémenter les membres abstraits spécifiques à leur propre géométrie et configuration. Cela facilite l'extensibilité et la gestion des blocs dans le jeu Tetris, en séparant la logique générale des blocs de leurs caractéristiques spécifiques.