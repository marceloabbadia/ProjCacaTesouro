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

        public static bool ForestMap(int matrixWidthX, int matrixWeigthY)
        {

            Treasure treasure = new Treasure(0, 0);
            treasure.Coordinates = Treasure.Print(matrixWidthX, matrixWeigthY);

            Motorcycle motocycle = new Motorcycle(0, 0);
            motocycle.Coordinates = StartPosition(motocycle, matrixWidthX, matrixWeigthY);
            if (treasure.Coordinates[0, 0] == motocycle.Coordinates[0, 0] && treasure.Coordinates[0, 1] == motocycle.Coordinates[0, 1])
            {
                motocycle.Coordinates = StartPosition(motocycle, matrixWidthX, matrixWeigthY);
            }


            Tank tank = new Tank(0, 0);
            tank.Coordinates = StartPosition(tank, matrixWidthX, matrixWeigthY);

            if (tank.Coordinates[0, 0] == motocycle.Coordinates[0, 0] && tank.Coordinates[0, 1] == motocycle.Coordinates[0, 1])
            {
                tank.Coordinates = StartPosition(tank, matrixWidthX, matrixWeigthY);
            }

            Excavator excavator = new Excavator(0, 0);
            excavator.Coordinates = StartPosition(excavator, matrixWidthX, matrixWeigthY);

            if (tank.Coordinates[0, 0] == excavator.Coordinates[0, 0] && tank.Coordinates[0, 1] == excavator.Coordinates[0, 1])
            {
                excavator.Coordinates = StartPosition(tank, matrixWidthX, matrixWeigthY);
            }


            int cont = 1;
            bool game = true;

            while (game)
            {
                Console.Clear();

                Console.WriteLine("LEGENDA:");
                Console.WriteLine("G = 'Tesouro' | M= 'Moto' | T= 'Tanque' | E = 'Escavadora'");
                Console.WriteLine();
                Console.Write("Jogando...");
                Console.WriteLine();

                for (int i = 0; i < matrixWidthX; i++)
                {
                    for (int j = 0; j < matrixWeigthY; j++)
                    {
                        if (treasure.Coordinates[0, 0] == i && treasure.Coordinates[0, 1] == j)
                        {
                            Console.ForegroundColor = treasure.Color;
                            Console.Write(treasure.Symbol);
                            Console.ResetColor();
                        }
                        else if (motocycle.Coordinates[0, 0] == i && motocycle.Coordinates[0, 1] == j && motocycle.Status == true)
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
                        else if (excavator.Coordinates[0, 0] == i && excavator.Coordinates[0, 1] == j && excavator.Status == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("E");
                            Console.ResetColor();
                        }
                        else if (i == 0 || i == matrixWidthX - 1 || j == 0 || j == matrixWeigthY - 1)
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
                Console.WriteLine();

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

                    if (tank.Coordinates[0, 0] == motocycle.Coordinates[0, 0] && (tank.Coordinates[0, 1] == motocycle.Coordinates[0, 1]))
                    {
                        motocycle.Status = false;
                        motocycle.Coordinates[0, 0] = 0;
                        motocycle.Coordinates[0, 1] = 0;


                    }
                    else if (tank.Coordinates[0, 0] == excavator.Coordinates[0, 0] && (tank.Coordinates[0, 1] == excavator.Coordinates[0, 1]))

                    {
                        excavator.Status = false;
                        excavator.Coordinates[0, 0] = 0;
                        excavator.Coordinates[0, 1] = 0;

                    }

                    motocycle.Move(matrixWidthX, matrixWeigthY, tank.Coordinates[0, 0], tank.Coordinates[0, 1], excavator.Coordinates[0, 0], excavator.Coordinates[0, 1]);
                    tank.Move(matrixWidthX, matrixWeigthY, motocycle.Coordinates[0, 0], motocycle.Coordinates[0, 1], excavator.Coordinates[0, 0], excavator.Coordinates[0, 1]);
                    excavator.Move(matrixWidthX, matrixWeigthY, motocycle.Coordinates[0, 0], motocycle.Coordinates[0, 1], tank.Coordinates[0, 0], tank.Coordinates[0, 1]);

                }

                Console.WriteLine();
                Console.WriteLine($"Posicao Tesouro:[{treasure.Coordinates[0, 0]} , {treasure.Coordinates[0, 1]}]");
                Console.WriteLine($"Movimento Moto:[{motocycle.Coordinates[0, 0]} , {motocycle.Coordinates[0, 1]}]");
                Console.WriteLine($"Movimento Tanque:[{tank.Coordinates[0, 0]} , {tank.Coordinates[0, 1]}]");
                Console.WriteLine($"Movimento Escavador:[{excavator.Coordinates[0, 0]} , {excavator.Coordinates[0, 1]}]");
                Console.WriteLine();
            }


            return true;
        }



    }

}

