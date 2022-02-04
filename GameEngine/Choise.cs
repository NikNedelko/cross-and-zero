using System;

namespace cross_zero.GameEngine
{
    public class Choise
    {
        public static int size { get; set; }
        public static int winCount { get; set; }

        public static int InputValidator()
        {
            int value = 0;
            while (true)
            {

                try
                {
                    value = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine(PrintFactory.Prints.writeSize);
                    continue;
                }
                if (size == 0)
                {
                    if (value < 3 || value > 100)
                        Console.WriteLine(PrintFactory.Prints.sizeError);
                    else
                        break;
                }
                else
                {
                    if (value > size || value < 3)
                        Console.WriteLine(PrintFactory.Prints.sizeError);
                    else
                        break;
                }
            }
            return value;
        }
        public static void Choiser()
        {
            size=0;
            Console.WriteLine(PrintFactory.Prints.writeSize);
            size = InputValidator();
            StartGame.GameStartsNow.matrixForCrossZero = new string[size, size];
            System.Console.WriteLine("size is " + size + "\n");
            Console.WriteLine(PrintFactory.Prints.winCount);
            StartGame.GameStartsNow.WinCount = InputValidator();
            System.Console.WriteLine("win count is: " + StartGame.GameStartsNow.WinCount + "\n");
        }
    }
}