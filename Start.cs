using System;
using System.Collections;
using System.Collections.Generic;
namespace StartGame
{
    class GameStartsNow
    {
        private static string[,] matrixForCrossZero;
        private static Hashtable hsMatrix = new Hashtable();
        private static string position;
        private static bool winnerIsHere;
        private static int WinCount;
        private static int rows = 0;
        private static int columns = 0;
        private static int size = 0;

        public static void Intro()
        {
            while (true)
            {
                PrintFactory.Prints.Intro();
                //int size;
                while (true)
                {
                    Console.WriteLine("\nwrite size:");
                    try
                    {
                        size = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nnumber plz <3");
                        continue;
                    }
                    if (size < 3 || size > 100)
                        Console.WriteLine("size is too small or too big, try again");
                    else
                        break;
                }
                matrixForCrossZero = new string[size, size];
                System.Console.WriteLine("size is " + size + "\n");

                while (true)
                {
                    Console.WriteLine("write win count:");
                    try
                    {
                        WinCount = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nnumber plz <3");
                        continue;
                    }
                    if (WinCount > size || WinCount < 3)
                        Console.WriteLine("count is too small or too big, try again");
                    else
                        break;
                }
                System.Console.WriteLine("win count is: " + size + "\n");
                winnerIsHere = false;
                Game();
                System.Console.WriteLine("\nI hope u enjoy that XD\n write anything to continue or write 'ex' for exit");
                var dontExme = System.Console.ReadLine();
                if (dontExme == "ex")
                {
                    System.Console.WriteLine("thank u very much for your time! have a good day!");
                    break;
                }
            }
        }

        private static void Game()
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
                    Choice("X", rows, columns);
                }
                else
                {
                    System.Console.WriteLine("O choise position");
                    Choice("O", rows, columns);
                }
                PrintFactory.Prints.NewMatrix(matrixForCrossZero, rows, columns);
                if (winnerIsHere)
                    break;
            }
        }

        private static void Choice(string tag, int rows, int columns)
        {
            bool flag = true;
            while (flag)
            {
                position = Console.ReadLine();// выбор позиции
                if (position == "")
                {
                    System.Console.WriteLine("Wrong!");
                    continue;
                }
                int policeMan = 0;
                try
                {
                    policeMan = Convert.ToInt32(position);
                }
                catch (Exception)
                {
                    System.Console.WriteLine("Wrong!");
                    continue;
                }
                if (policeMan < 0 && policeMan > rows * columns)
                {
                    System.Console.WriteLine("Wrong!");
                    continue;
                }
                else if (!IsOccupied(rows, columns, policeMan))
                {
                    System.Console.WriteLine("Wrong!");
                    continue;
                }
                else
                {
                    var point = Convert.ToString(hsMatrix[position]).Split(' ');
                    matrixForCrossZero[Convert.ToInt32(point[0]), Convert.ToInt32(point[1])] = tag;
                    flag = false;
                    int[] current = new int[] { Convert.ToInt32(point[0]), Convert.ToInt32(point[1]) };

                    if (anybodyIsWin(tag, Convert.ToInt32(point[0]), Convert.ToInt32(point[1])))
                    {
                        System.Console.WriteLine("we have a winner!!!\n Winner is: {0}", tag);
                        winnerIsHere = true;
                        break;
                    }
                }

            }
        }

        private static bool IsOccupied(int rows, int columns, int target)
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

        private static bool anybodyIsWin(string tag, int rowsCurrent, int columnsCurrent)
        {
            int count = 1, tryCount = 0;
            //left-right
            int i = columnsCurrent - 1, j = columnsCurrent + 1;
            bool iIsValid = true, jIsValid = true;
            while (true)
            {
                if (i < 0)
                    iIsValid = false;
                if (j > columns)
                    jIsValid = false;
                try
                {
                    if (matrixForCrossZero[rowsCurrent, i] == tag && iIsValid)
                    {
                        count++;
                    }
                }
                catch (Exception)
                {
                    iIsValid = false;
                }
                try
                {
                    if (matrixForCrossZero[rowsCurrent, j] == tag && jIsValid)
                    {
                        count++;
                    }
                }
                catch (Exception)
                {
                    jIsValid = false;
                }
                if (iIsValid)
                    i--;
                if (jIsValid)
                    j++;
                if (count >= 3)
                    return true;
                if (tryCount >= 2)
                {
                    break;
                }
                tryCount++;
            }
            count = 1;
            tryCount = 0;
            jIsValid = true;
            iIsValid = true;
            i = rowsCurrent + 1;
            j = rowsCurrent - 1;
            //up down
            while (true)
            {
                if (i > rows)//down
                    iIsValid = false;
                if (j < 0)//up
                    jIsValid = false;
                try
                {
                    if (matrixForCrossZero[i, columnsCurrent] == tag && iIsValid)
                    {
                        count++;
                    }
                }
                catch (Exception)
                {
                    iIsValid = false;
                }
                try
                {
                    if (matrixForCrossZero[j, columnsCurrent] == tag && jIsValid)
                    {
                        count++;
                    }
                }
                catch (Exception)
                {
                    jIsValid = false;
                }
                if (iIsValid)
                    i++;
                if (jIsValid)
                    j--;
                if (count >= 3)
                    return true;
                if (tryCount >= 2)
                {
                    break;
                }
                tryCount++;
            }

            count = 1;
            tryCount = 0;
            jIsValid = true;
            iIsValid = true;
            int seconI = columnsCurrent - 1;
            int secondJ = columnsCurrent + 1;
            i = rowsCurrent - 1;
            j = rowsCurrent + 1;
            //up left to down right
            while (true)
            {
                if (i < 0)
                    iIsValid = false;
                if (j > columns)
                    jIsValid = false;
                try
                {
                    if (matrixForCrossZero[i, seconI] == tag && iIsValid)
                    {
                        count++;
                    }
                }
                catch (Exception)
                {
                    iIsValid = false;
                }
                try
                {
                    if (matrixForCrossZero[j, secondJ] == tag && jIsValid)
                    {
                        count++;
                    }
                }
                catch (Exception)
                {
                    jIsValid = false;
                }
                if (iIsValid)
                {
                    i--;
                    seconI--;
                }
                if (jIsValid)
                {
                    j++;
                    secondJ++;
                }
                if (count >= 3)
                    return true;
                if (tryCount >= 2)
                {
                    break;
                }
                tryCount++;
            }

            count = 1;
            tryCount = 0;
            jIsValid = true;
            iIsValid = true;
            seconI = rowsCurrent + 1;
            secondJ = rowsCurrent - 1;
            i = columnsCurrent - 1;
            j = columnsCurrent + 1;
            //left down to right up
            while (true)
            {
                if (i < 0)//left down
                    iIsValid = false;
                if (j > columns)//right up
                    jIsValid = false;
                try
                {
                    if (matrixForCrossZero[seconI, i] == tag && iIsValid)
                    {
                        count++;
                    }
                }
                catch (Exception)
                {
                    iIsValid = false;
                }
                try
                {
                    if (matrixForCrossZero[secondJ, j] == tag && jIsValid)
                    {
                        count++;
                    }
                }
                catch (Exception)
                {
                    jIsValid = false;
                }
                if (iIsValid)
                {
                    i--;
                    seconI--;
                }
                if (jIsValid)
                {
                    j++;
                    secondJ++;
                }
                if (count >= 3)
                    return true;
                if (tryCount >= 2)
                {
                    break;
                }
                tryCount++;
            }
            return false;
        }
    }
}