using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace Tetris
{
    public class IBlock : Block // Le code est contenu dans le namespace "Tetris". La classe "IBlock" hérite de la classe abstraite "Block" et en hérite toutes les fonctionnalités et membres.
    {
        private readonly Position[][] tiles = new Position[][] //La classe "IBlock" définit un tableau bidimensionnel "tiles" de positions représentant les tuiles du bloc "I-block" dans différentes rotations. Chaque élément du tableau correspond à une rotation spécifique du bloc, et chaque rotation est représentée par un tableau de positions. Chaque position est créée à l'aide de l'initialiseur d'objets avec des coordonnées x et y.
        {
            new Position[] { new(1,0), new(1,1), new(1,2), new(1,3) },
            new Position[] { new(0,2), new(1,2), new(2,2), new(3,2) },
            new Position[] { new(2,0), new(2,1), new(2,2), new(2,3) },
            new Position[] { new(0,1), new(1,1), new(2,1), new(3,1) }
        };

        // La propriété "Id" est redéfinie en tant que propriété en lecture seule dans la classe "IBlock" et retourne la valeur 1 pour identifier spécifiquement le bloc "I-block". La méthode "StartOffset" est redéfinie en tant que méthode protégée dans la classe "IBlock" et retourne une instance de la classe "Position" avec les coordonnées(-1, 3). Cela définit la position de départ du bloc "I-block". La méthode "Tiles" est redéfinie en tant que méthode protégée dans la classe "IBlock" et retourne le tableau "tiles" défini précédemment, représentant les différentes rotations du bloc "I-block".

        public override int Id => 1;
        protected override Position StartOffset => new Position(-1, 3);
        protected override Position[][] Tiles => tiles;
    }
}

// En résumé, ce code définit la classe "IBlock" qui représente le type spécifique de bloc "I-block" dans le jeu Tetris. Il utilise l'héritage de la classe abstraite "Block" pour obtenir les fonctionnalités de base du bloc et redéfinit les membres abstraits pour spécifier les propriétés et les configurations spécifiques du bloc "I-block". Les rotations possibles et les positions des tuiles du bloc sont définies dans le tableau "tiles".