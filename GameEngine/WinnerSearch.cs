using System;

namespace cross_zero.GameEngine
{
    public class WinnerSearch
    {
        public static bool anybodyIsWin(string tag, int rowsCurrent, int columnsCurrent)
        {
            int count = 1, tryCount = 0;
            //left-right
            int i = columnsCurrent - 1, j = columnsCurrent + 1;
            bool iIsValid = true, jIsValid = true;
            while (true)
            {
                if (i < 0)
                    iIsValid = false;
                if (j > StartGame.GameStartsNow.columns)
                    jIsValid = false;
                try
                {
                    if (StartGame.GameStartsNow.matrixForCrossZero[rowsCurrent, i] == tag && iIsValid)
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
                    if (StartGame.GameStartsNow.matrixForCrossZero[rowsCurrent, j] == tag && jIsValid)
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
                if (i > StartGame.GameStartsNow.rows)//down
                    iIsValid = false;
                if (j < 0)//up
                    jIsValid = false;
                try
                {
                    if (StartGame.GameStartsNow.matrixForCrossZero[i, columnsCurrent] == tag && iIsValid)
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
                    if (StartGame.GameStartsNow.matrixForCrossZero[j, columnsCurrent] == tag && jIsValid)
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
                if (j > StartGame.GameStartsNow.columns)
                    jIsValid = false;
                try
                {
                    if (StartGame.GameStartsNow.matrixForCrossZero[i, seconI] == tag && iIsValid)
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
                    if (StartGame.GameStartsNow.matrixForCrossZero[j, secondJ] == tag && jIsValid)
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
                if (j > StartGame.GameStartsNow.columns)//right up
                    jIsValid = false;
                try
                {
                    if (StartGame.GameStartsNow.matrixForCrossZero[seconI, i] == tag && iIsValid)
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
                    if (StartGame.GameStartsNow.matrixForCrossZero[secondJ, j] == tag && jIsValid)
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