using Exceptions.Classes;
using System;
using System.Globalization;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //CompareStringCase();

            #region DoSomethingDangerous
            /* 
            * try/catch blocks will also catch Exceptions that are 
            * thrown from method called further down the stack 
            */
            try
            {
                int result = DoSomethingDangerous(8, 0);
                Console.WriteLine($"The result is {result}");
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("BAD!!!");
                throw;
                
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Be a hero, DON'T divide by zero!");
                throw;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("And that's all I have to say about that.");
            }

            #endregion


            //DoMathFun();
            //Console.ReadLine();


            DoBankAccount();
            Console.ReadLine();


            // A template for error-handling...
            try
            {
                // Do some work here...
            }
            catch (ArgumentNullException e)
            {
                // catch most specific Exceptions first
            }
            catch (Exception e)
            {
                // (optional) catch more general exceptions later
                // (optional) re-throw the same exception so it can be caught further up the stack
                throw;
            }
            finally
            {
                // (optional) Do work that should execute whether the above succeeded or failed
            }

            Console.ReadKey();
        }

        private static void CompareStringCase()
        {
            string str1 = "dog", str2 = "Dog";
            if (str1 == str2)       // They will be different
            {
                Console.WriteLine($"{str1} and {str2} are the same");
            }
            else
            {
                Console.WriteLine($"{str1} and {str2} are DIFFERENT");
            }

            if (str1.ToLower() == str2.ToLower())       // They will be same
            {
                Console.WriteLine($"{str1} and {str2} are the same");
            }
            else
            {
                Console.WriteLine($"{str1} and {str2} are DIFFERENT");
            }

            if (string.Compare(str1, str2) == 0)       // They will be different
            {
                Console.WriteLine($"{str1} and {str2} are the same");
            }
            else
            {
                Console.WriteLine($"{str1} and {str2} are DIFFERENT");
            }

            if (string.Compare(str1, str2, true) == 0)       // They will be same
            {
                Console.WriteLine($"{str1} and {str2} are the same");
            }
            else
            {
                Console.WriteLine($"{str1} and {str2} are DIFFERENT");
            }

            if (string.Compare(str1, str2, StringComparison.InvariantCultureIgnoreCase) == 0)       // They will be same
            {
                Console.WriteLine($"{str1} and {str2} are the same");
            }
            else
            {
                Console.WriteLine($"{str1} and {str2} are DIFFERENT");
            }
            return;
        }

        private static int DoSomethingDangerous(int a, int b)
        {
            int result = a / b;
            return result;
        }

        private static void DoMathFun()
        {
            try
            {
                MathFun math = new MathFun();
                Console.WriteLine(math.Average(new int[] { }));
                Console.WriteLine(math.ParseAndAdd("23, 45, 65"));
            }
            catch (Exception exc)
            {
                Console.WriteLine($"ERROR!!! {exc.Message}");
            }
            finally
            {
                Console.WriteLine("Running the final block...");
            }
        }

        private static void DoBankAccount()
        {
            BankAccount account = new BankAccount(0m);
            try
            {
                account.Withdraw(500m);

            }
            catch (AccountOverdrawException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(account);
        }
    }
}
