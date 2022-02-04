using System;
namespace PrintFactory
{
    class Prints
    {
        public static string writeSize="\nwrite size:";
        public static string giveNumber ="\nnumber plz <3";
        public static string sizeError ="size is too small or too big, try again";
        public static string winCount ="write win count:";
        public static string startGameMess="\nI hope u enjoy that XD\n write anything to continue or write 'ex' for exit";
        public static string thankU ="thank u very much for your time! have a good day!";
        public static void Intro(){
            System.Console.WriteLine("Hello everybody, My game is start");
        }
        public static void Rules(){
            System.Console.WriteLine("");
        }
        public static void trans(){
            System.Console.WriteLine("");
        }
        public static void NewMatrix(string[,] matrix,int rows,int columns){

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
    }
}