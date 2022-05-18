using System;
using System.Numerics;

namespace AddingBigNumbers
{
    /*
        We need to sum big numbers and we require your help.
        Write a function that returns the sum of two numbers. The input numbers are strings and the function must return a string.
        
        Notes:
        The input numbers are big.
        The input is a string of only digits
        The numbers are positives
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "15632165465312315654321268865321";
            string b = "142354513214";

            Console.WriteLine("The sum of {0} + {1} = {2}", a, b, Add(a, b));

            Console.Read();
        }

        public static string Add(string a, string b)
        {
            BigInteger aA = BigInteger.Parse(a);
            BigInteger bB = BigInteger.Parse(b);

            return (aA + bB).ToString();
        }
    }
}
