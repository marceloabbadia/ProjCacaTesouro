using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacaTesouro.Vehicles
{
    public class Motorcycle : IVehicles
    {
        public int[,] Coordinates { get; set; }

        public string Name => "Motocycle";
        public char Symbol => 'M';

        public bool Status;

        public ConsoleColor Color => ConsoleColor.Green;


        public Motorcycle(int startX, int startY)
        {
            Coordinates = new int[1, 2];
            Coordinates[0, 0] = startX;
            Coordinates[0, 1] = startY;
            Status = true;
        }

        public int[,] Move(int widthForestX, int heightForestY, int otherX1, int otherY1, int otherX2, int otherY2)
        {
            Random random = new Random();
            int moveX, moveY;

            while (true)
            {
                moveX = random.Next(-2, 3);
                moveY = random.Next(-2, 3);

                // Verifica se o movimento é válido (não move mais de uma célula)
                if (Math.Abs(moveX) + Math.Abs(moveY) > 1)
                    continue;

                int newX = Coordinates[0, 0] + moveX;
                int newY = Coordinates[0, 1] + moveY;

                // Limita dentro da área permitida
                newX = Math.Max(1, Math.Min(newX, widthForestX - 2));
                newY = Math.Max(1, Math.Min(newY, heightForestY - 2));

                // Verifica se as novas coordenadas não coincidem com outros veículos
                if ((newX != otherX1 || newY != otherY1) && (newX != otherX2 || newY != otherY2))
                {
                    Coordinates[0, 0] = newX;
                    Coordinates[0, 1] = newY;
                    break;
                }
            }

            return Coordinates;
        }
    }
}