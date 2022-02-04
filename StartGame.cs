using System;
using System.Collections;
using System.Collections.Generic;
using cross_zero.GameEngine;
namespace StartGame
{
    class GameStartsNow
    {
        public static string[,] matrixForCrossZero;
        public static Hashtable hsMatrix = new Hashtable();
        public static string position;
        public static bool winnerIsHere;
        public static int WinCount;
        public static int rows = 0;
        public static int columns = 0;
        public static int size = 0;

        public static void Intro()
        {
            while (true)
            {
                PrintFactory.Prints.Intro();
                Choise.Choiser();
                winnerIsHere = false;
                Game();
                System.Console.WriteLine(PrintFactory.Prints.startGameMess);
                var dontExme = System.Console.ReadLine();
                if (dontExme == "ex")
                {
                    System.Console.WriteLine(PrintFactory.Prints.thankU);
                    break;
                }
            }
        }

        public static void Game()
        {
            rows = matrixForCrossZero.GetUpperBound(0) + 1;    // количество строк
            columns = matrixForCrossZero.Length / rows;        // количество столбцов
            int numbersForMatrix = 1;
            hsMatrix.Clear();
            hsMatrix = new Hashtable();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var str = Convert.ToString(i + " " + j);
                    hsMatrix.Add(Convert.ToString(numbersForMatrix), str);
                    matrixForCrossZero[i, j] = Convert.ToString(numbersForMatrix);
                    numbersForMatrix++;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrixForCrossZero[i, j]}\t");
                }
                Console.WriteLine();
            }
            //Console.ReadLine();
            int motionCount = rows * columns;
            System.Console.WriteLine("go!");
            for (int i = 0; i < motionCount; i++)
            {
                if (i % 2 == 0)
                {
                    System.Console.WriteLine("X choise position");
                    ChoisePosition.Choice("X", rows, columns);
                }
                else
                {
                    System.Console.WriteLine("O choise position");
                    ChoisePosition.Choice("O", rows, columns);
                }
                PrintFactory.Prints.NewMatrix(matrixForCrossZero, rows, columns);
                if (winnerIsHere)
                    break;
            }
        }


        public static bool IsOccupied(int rows, int columns, int target)
        {
            string localTarget = Convert.ToString(target);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrixForCrossZero[i, j] == localTarget)
                        return true;
                }
            }
            return false;
        }


    }
}