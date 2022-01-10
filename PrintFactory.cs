using System;
namespace PrintFactory
{
    class Prints
    {
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