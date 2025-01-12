using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacaTesouro.Vehicles
{
    public class Motorcycle : IElements
    {
        public int[,] Coordinates { get; set; }

        public Motorcycle(int startX, int startY)
        {
            Coordinates = new int[1, 2];
            Coordinates[0, 0] = startX;
            Coordinates[0, 1] = startY;
        }

        public int[,] Move(int WidthForestX, int HeigthForestY)
        {

            Random random = new Random();

            int moveX = random.Next(-2, 3);
            int moveY = random.Next(-2, 3);

            while (Math.Abs(moveX) + Math.Abs(moveY) > 2)
            {
                moveX = random.Next(-2, 3);
                moveY = random.Next(-2, 3);
            }

            int newX = Coordinates[0, 0] + moveX;
            int newY = Coordinates[0, 1] + moveY;

            newX = Math.Max(1, Math.Min(newX, WidthForestX - 2));
            newY = Math.Max(1, Math.Min(newY, HeigthForestY - 2));

            Coordinates[0, 0] = newX;
            Coordinates[0, 1] = newY;


            return Coordinates;

        }

    }
}
