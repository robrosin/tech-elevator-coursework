using System;
using System.IO;

namespace FizzWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\Student\\git\\robrosin-c\\module-1\\18_FileIO_Writing_out\\student-exercise\\FizzBuzz.txt"))
            {
                string num = "";
                for (int i = 1; i <= 300; i++)
                {
                    num = i.ToString();
                    if ((i % 15 == 0))
                    {
                        writer.WriteLine("FizzBuzz");
                    }
                    else if ((i % 5 == 0) || (i.ToString().Contains("5")))
                    {
                        writer.WriteLine("Buzz");
                    }
                    else if ((i % 3 == 0) || (i.ToString().Contains("3")))
                    {
                        writer.WriteLine("Fizz");
                    }
                    else
                    {
                        writer.WriteLine(num);
                    }
                }
            }
        }
    }
}


