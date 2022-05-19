using System;
using System.Numerics;
using System.Collections.Generic;

/*
    The drawing shows 6 squares the sides of which have a length of 1, 1, 2, 3, 5, 8. It's easy to see that the sum of the perimeters of these squares is : 4 * (1 + 1 + 2 + 3 + 5 + 8) = 4 * 20 = 80

    Could you give the sum of the perimeters of all the squares in a rectangle when there are n + 1 squares disposed in the same manner as in the drawing (https://www.codewars.com/kata/559a28007caad2ac4e000083/train/csharp)

    Hint:
    See Fibonacci sequence
 */

namespace PerimeterOfSquaresInARectangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = new BigInteger(7);

            Console.WriteLine("Total perimeter is: " + Perimeter(n));

            Console.Read();
        }

        public static BigInteger Perimeter(BigInteger n)
        {
            BigInteger result = BigInteger.Zero;
            List<BigInteger> squareValue = new List<BigInteger>();

            for (int i = 0; i < n+1; i++)
            {
                if(i < 2)
                {
                    squareValue.Add(BigInteger.One);
                    result += squareValue[i];
                }
                else
                {
                    squareValue.Add(squareValue[i - 2] + squareValue[i - 1]);
                    result += squareValue[i];
                }
            }

            return result * 4;
        }
    }
}
