using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacaTesouro.Vehicles;

namespace CacaTesouro.Utils
{
    internal class Utils
    {
        public static int[,] StartPosition( IElements vehicle,int MatrixWidthX, int MatrixWeigthY)
        {

            Random random = new Random();

            int moveX = random.Next(0, MatrixWidthX - 1);
            int moveY = random.Next(0, MatrixWeigthY - 1);

            vehicle.Coordinates[0, 0] = moveX;
            vehicle.Coordinates[0, 1] = moveY;


            while (vehicle.Coordinates[0, 0] == 0 || vehicle.Coordinates[0, 0] == MatrixWidthX - 1 ||
           vehicle.Coordinates[0, 1] == 0 || vehicle.Coordinates[0, 1] == MatrixWeigthY - 1)
            {
                moveX = random.Next(1, MatrixWidthX - 1);
                moveY = random.Next(1, MatrixWeigthY - 1);
                vehicle.Coordinates[0, 0] = moveX;
                vehicle.Coordinates[0, 1] = moveY;
            }

            return vehicle.Coordinates;
        }



    }
}
