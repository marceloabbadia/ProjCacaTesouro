using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CacaTesouro.Utils.Utils;
using CacaTesouro.Vehicles;

namespace CacaTesouro
{
    public static class Forest
    {
        public static int MatrixWidthX;
        public static int MatrixWeigthY;

        public static bool ForestMap(int MatrixWidthX, int MatrixWeigthY)
        {
            Treasure treasure = new Treasure(0, 0);
            treasure.Coordinates = treasure.Move(MatrixWidthX, MatrixWeigthY);

            Motorcycle motocycle = new Motorcycle(0, 0);
            motocycle.Coordinates = StartPosition(motocycle, MatrixWidthX, MatrixWeigthY);

            Tank tank = new Tank(0, 0);
            tank.Coordinates = StartPosition(tank, MatrixWidthX, MatrixWeigthY);

            if (tank.Coordinates[0, 0] == motocycle.Coordinates[0, 0] && tank.Coordinates[0, 1] == motocycle.Coordinates[0, 1])
            {
                tank.Coordinates = StartPosition(tank, MatrixWidthX, MatrixWeigthY);
            }

            Excavator excavator = new Excavator(0, 0);
            excavator.Coordinates = StartPosition(excavator, MatrixWidthX, MatrixWeigthY);
            
            if (tank.Coordinates[0, 0] == excavator.Coordinates[0, 0] && tank.Coordinates[0, 1] == excavator.Coordinates[0, 1])
            {
                excavator.Coordinates = StartPosition(tank, MatrixWidthX, MatrixWeigthY);
            }


            int cont = 1;
            bool game = true;

            while (game)
            {
                Console.WriteLine("LEGENDA:");
                Console.WriteLine("G = 'Tesouro' | M= 'Moto' | T= 'Tanque' | E = 'Escavadora'");
                Console.WriteLine();
                Console.Write("Jogando...");
                Console.WriteLine();

                for (int i = 0; i < MatrixWidthX; i++)
                {
                    for (int j = 0; j < MatrixWeigthY; j++)
                    {
                        if (treasure.Coordinates[0, 0] == i && treasure.Coordinates[0, 1] == j)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("G");
                            Console.ResetColor();
                        }
                        else if (motocycle.Coordinates[0, 0] == i && motocycle.Coordinates[0, 1] == j)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("M");
                            Console.ResetColor();
                        }
                        else if (tank.Coordinates[0, 0] == i && tank.Coordinates[0, 1] == j)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("T");
                            Console.ResetColor();
                        }
                        else if (excavator.Coordinates[0, 0] == i && excavator.Coordinates[0, 1] == j)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("E");
                            Console.ResetColor();
                        }
                        else if (i == 0 || i == MatrixWidthX - 1 || j == 0 || j == MatrixWeigthY - 1)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write("-");
                        }
                    }
                    Console.WriteLine();
                }

                System.Threading.Thread.Sleep(350);


                if (treasure.Coordinates[0, 0] == motocycle.Coordinates[0, 0] && treasure.Coordinates[0, 1] == motocycle.Coordinates[0, 1])
                {
                    game = false;
                    Console.WriteLine("Fim de jogo! A moto venceu!");
                    Console.WriteLine($"Jogadas: {cont} ");
                }
                else if (treasure.Coordinates[0, 0] == tank.Coordinates[0, 0] && treasure.Coordinates[0, 1] == tank.Coordinates[0, 1])
                {
                    game = false;
                    Console.WriteLine("Fim de jogo! O tanque venceu!");
                    Console.WriteLine($"Jogadas: {cont} ");
                }
                else if (treasure.Coordinates[0, 0] == excavator.Coordinates[0, 0] && treasure.Coordinates[0, 1] == excavator.Coordinates[0, 1])
                {
                    game = false;
                    Console.WriteLine("Fim de jogo! O escavador venceu!");
                    Console.WriteLine($"Jogadas: {cont} ");
                }
                else
                {
                    Console.Clear();
                    cont++;
                    motocycle.Move(MatrixWidthX, MatrixWeigthY);
                    tank.Move(MatrixWidthX, MatrixWeigthY);
                    excavator.Move(MatrixWidthX, MatrixWeigthY);

                }
            }

            return true;
        }



    }

}

