using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            /*****************************************************************************
            Part 1: Variable Scope
            ******************************************************************************/
            // Declare a variable
            int outerVariable = 5;
            Console.WriteLine("outerVariable is " + outerVariable);

            // Start a statement block
            {

                // Print out the variable defined in the outer scope
                Console.WriteLine("outerVariable is " + outerVariable);

                // Declare a variable in the block (inner scope)
                int innerVariable = 10;

                // Print out that variable
                Console.WriteLine("Inner variable is " + innerVariable);

                // End the statement block
            }
            // Print the the variable declared in the block
            // OOOPS, cannot do this!
            //Console.WriteLine("Inner variable is " + innerVariable);


            /*****************************************************************************
            Part 2: Methods
            ******************************************************************************/
            // Call the MultiplyBy method
            int height = 10;
            int width = 20;
            int area = MultiplyBy(height, width);
            Console.WriteLine($"The area of a rectangle {height} by {width} is {area}");

            // Call MultiplyBy a few more different ways
            int a = 0;
            int answer = MultiplyBy(a, 300);

            answer = MultiplyBy(10 * 30, 5 * 15);

            a = -250;
            answer = MultiplyBy(Math.Abs(a), 10);

            // Create and print some boolean expressions


            Console.ReadKey();
        }

        /*
         * Create a method called MultiplyBy, which takes two integers and returns the integert product.
         */
        static public int MultiplyBy(int multiplicand, int multiplier)
        {
            int product = multiplicand * multiplier;
            return product;
        }

    }
}
