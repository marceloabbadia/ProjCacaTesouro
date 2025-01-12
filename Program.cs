namespace CacaTesouro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool newGame = true;

            while (newGame)
            {
                int MatrixPositionX = 0;
                int MatrixPositionY = 0;

                while (true)
                {
                    Console.WriteLine("Informe o tamanho (Número inteiro entre 5 e 25) da altura da floresta:");
                    if (int.TryParse(Console.ReadLine(), out MatrixPositionX) && (MatrixPositionX >= 5 && MatrixPositionX <=25))
                        break;

                    Console.WriteLine("Valor inválido! Por favor, insira um número inteiro positivo.");
                }

                while (true)
                {
                    Console.WriteLine("Informe o tamanho ((Número inteiro entre 25 e 100) da largura da floresta:");
                    if (int.TryParse(Console.ReadLine(), out MatrixPositionY) && (MatrixPositionY >= 25 && MatrixPositionY <=100))
                        break;

                    Console.WriteLine("Valor inválido! Por favor, insira um número inteiro positivo.");
                }

                Console.Clear();

                bool endGame = Forest.ForestMap(MatrixPositionX, MatrixPositionY);

                if (endGame)
                {
                    Console.WriteLine("Deseja jogar novamente? (S/N)");
                    string response = Console.ReadLine()?.Trim().ToUpper();

                    newGame = response == "S" || response == "SIM";
                }
            }

            Console.WriteLine("Obrigado por jogar!");
        }
    }
}
