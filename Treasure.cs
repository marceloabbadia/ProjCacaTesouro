using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacaTesouro
{
    internal class Treasure : IElements
    {
        public int[,] Coordinates { get; set; }

        public string Name => "Treasure";
        public char Symbol => 'G';

        public ConsoleColor Color => ConsoleColor.DarkYellow;

        public Treasure(int startX, int startY)
        {
            Coordinates = new int[1, 2];
            Coordinates[0, 0] = startX;
            Coordinates[0, 1] = startY;

        }

        public static int[,] Print(int matrixWidthX, int matrixWeightY)
        {
            Random random = new Random();

            Treasure treasure = new Treasure(0, 0);
            treasure.Coordinates = new int[1, 2];

            do
            {
                treasure.Coordinates[0, 0] = random.Next(1, matrixWidthX - 1);
                treasure.Coordinates[0, 1] = random.Next(1, matrixWeightY - 1); 
            }
            while (treasure.Coordinates[0, 0] == 0 || treasure.Coordinates[0, 0] == matrixWidthX - 1 ||
                   treasure.Coordinates[0, 1] == 0 || treasure.Coordinates[0, 1] == matrixWeightY - 1);

            return treasure.Coordinates;
        }

    }
}



