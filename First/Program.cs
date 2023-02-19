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
                {"Michi", 17 + "jr"},
                {"Michael", 30 + "sn"}
            };

            for (int i = 0; i < 1; i++)
            {

                for (int j = 0; j < 2; j++)
                {
                    
                    Console.Write(obj[i, j] + " ");
                    
                    

                }
                Console.WriteLine();
            }

        }
    }
}