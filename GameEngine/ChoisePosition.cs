using System;

namespace cross_zero.GameEngine
{
    public class ChoisePosition
    {
        public static void Choice(string tag, int rows, int columns)
        {
            bool flag = true;
            while (flag)
            {
                StartGame.GameStartsNow.position = Console.ReadLine();// выбор позиции
                if (StartGame.GameStartsNow.position == "")
                {
                    System.Console.WriteLine("Wrong!");
                    continue;
                }
                int policeMan = 0;
                try
                {
                    policeMan = Convert.ToInt32(StartGame.GameStartsNow.position);
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
                else if (!StartGame.GameStartsNow.IsOccupied(rows, columns, policeMan))
                {
                    System.Console.WriteLine("Wrong!");
                    continue;
                }
                else
                {
                    var point = Convert.ToString(StartGame.GameStartsNow.hsMatrix[StartGame.GameStartsNow.position]).Split(' ');
                    StartGame.GameStartsNow.matrixForCrossZero[Convert.ToInt32(point[0]), Convert.ToInt32(point[1])] = tag;
                    flag = false;
                    int[] current = new int[] { Convert.ToInt32(point[0]), Convert.ToInt32(point[1]) };

                    if (WinnerSearch.anybodyIsWin(tag, Convert.ToInt32(point[0]), Convert.ToInt32(point[1])))
                    {
                        System.Console.WriteLine("we have a winner!!!\n Winner is: {0}", tag);
                        StartGame.GameStartsNow.winnerIsHere = true;
                        break;
                    }
                }

            }
        }
    }
}