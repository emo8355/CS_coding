using System;
using System.Numerics;
using System.Runtime.ExceptionServices;

namespace Lab2
{
    class Program
    {

        static public int x = 10;
        static void Main(string[] args)
        {
            Console.WriteLine("Lab question one: \n");

            questionOne();
            Console.WriteLine("===========================================");
            Console.WriteLine("Lab question two: \n ");
            questionTwo();
        }


        static void questionOne()
        {
            Console.WriteLine("number square cube");
            for (int i = 0; i <= x; i++)
            {
                Console.WriteLine($"{i} {Math.Pow(i,2)} {Math.Pow(i, 3)}");
            }
        }
        
        static void questionTwo()
        {
            Console.WriteLine("Enter five numbers:");
            int positive = 0;
            int negative = 0;
            int zero = 0;

            string input = Console.ReadLine();

            string[] inputArray = input.Split(",");

            foreach (string n in inputArray)
            {
                int num1 = Convert.ToInt32(n);
                if (num1 > 0)
                {
                    positive += 1;
                }
                else if (num1 < 0)
                {
                    negative += 1;
                }
                else
                {
                    zero += 1;
                }

            }

            Console.WriteLine($"Total number of positive: {positive}");
            Console.WriteLine($"Total number of negative: {negative}");
            Console.WriteLine($"Total number of zero: {zero}");
        }
    }
}
