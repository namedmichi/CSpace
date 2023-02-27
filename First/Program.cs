using System;
using System.Data.Common;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            object[,] obj =
            {
                {"Michi", 17 , " testt"},
                {"Michael", 30 , " sn"}
            };

            //for (int i = 0; i < 2; i++)
            //{

            //    for (int j = 0; j < 2; j++)
            //    {

            //        Console.Write(obj[i, j] + " ");



            //    }
            //    Console.WriteLine();
            //}

            printRow(0, obj);
            printRow(1, obj);

        }

        static void printRow(int rowNumber, object[,] o)
        {
            Console.Write(o[rowNumber, 0] + " " + o[rowNumber, 1] + " " + o[rowNumber, 2] + " ");
            Console.WriteLine();
        }
    }
}