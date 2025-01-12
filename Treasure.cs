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

         public Treasure(int startX, int startY)
        {
            Coordinates = new int[1, 2];
            Coordinates[0, 0] = startX;
            Coordinates[0, 1] = startY;
        }

        public int[,] Move(int MatrixWidthX, int MatrixWeigthY)
        {
            Random random = new Random();

            Treasure treasure = new Treasure(0, 0);

            int moveX = random.Next(1, MatrixWidthX - 1);
            int moveY = random.Next(1, MatrixWeigthY - 1);

            treasure.Coordinates[0, 0] = moveX;
            treasure.Coordinates[0, 1] = moveY;

            int newX = Math.Max(1, Math.Min(treasure.Coordinates[0, 0], MatrixWidthX - 2)); 
            int newY = Math.Max(1, Math.Min(treasure.Coordinates[0, 1], MatrixWeigthY - 2));

            treasure.Coordinates[0, 0] = newX;
            treasure.Coordinates[0, 1] = newY;


            return treasure.Coordinates;
        }



    }
}



