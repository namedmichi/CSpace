using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edabit
{
    internal class Program
    {
        static int[][] testArray = new int[][] {
        new int[] { 1, 2, 3 },
        new int[] { 4, 5 },
        new int[] { 6 },
        new int[] { 7, 8, 9, 10 }
};
        static void Main(string[] args)
        {
            //Console.WriteLine("[{0}]", string.Join(", ", ArrayOfMultiples(10, 10)));
            //Console.WriteLine(ReverseCase("Test"));
            Console.WriteLine("[{0}]", string.Join(", ", FindLargest( testArray )));

        }

        static string[] ArrayOfMultiples(int zahl, int len)
        {
            string[] array = new string[len];
            foreach (int i in Enumerable.Range(1, len))
            {
                array[i - 1] = (i * zahl).ToString();
            }


            return array;

        }

        static string ReverseCase(string s)
        {
            string newword = "";
            foreach (char c in s)
            {
                if ( Char.IsLower(c) )
                {
                    char tempc;
                    tempc = Char.ToUpper(c);
                    newword += tempc.ToString();
                }
                else
                {
                    char tempc;
                    tempc = Char.ToLower(c);
                    newword += tempc.ToString();
                }

                  
            }
            return newword;
        }



        static int[] FindLargest(int[][] arraylist)
        {
            int[] largest = new int[arraylist.Length];


                int c = 0;
            foreach ( Array array in arraylist ) 
            {

                int heighest = 0;
                foreach( int i in array)
                {
                    if (i > heighest)
                    {
                        heighest = i;
                    }
                }
                largest[c] = heighest;
                c++;
            }

            return largest;

        }




    }
}
