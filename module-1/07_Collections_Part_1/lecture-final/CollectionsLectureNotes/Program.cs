using System;
using System.Collections.Generic;

namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // LIST<T>
            //
            // Lists allow us to hold collections of data. They are declared with a type of data that they hold
            // only allowing items of that type to go inside of them.
            //
            // The syntax used for declaring a new list of type T is
            //      List<T> list = new List<T>();
            //
            //

            // Creating lists of integers
            List<int> numbers = new List<int>(100);
            Console.WriteLine(numbers);
            Console.WriteLine($"The numbers list has {numbers.Count} elements");
            //Console.WriteLine(numbers[0]);


            // Creating lists of strings
            List<string> words = new List<string>() { "Red", "Blue", "Green" };
            Console.WriteLine(words);
            words[0] = "Pink";
            Console.WriteLine( string.Join(", ", words) );
            Console.WriteLine(words[0]);
            /////////////////


            //////////////////
            // OBJECT EQUALITY
            //////////////////
            // Create a second list of numbers, which empty just like the first
            List<int> numbers2 = new List<int>();

            if (numbers == numbers2)
            {
                Console.WriteLine("The two lists are EQUAL");
            }
            else
            {
                Console.WriteLine("The two lists are NOT equal");
            }

            numbers2 = numbers;
            if (numbers == numbers2)
            {
                Console.WriteLine("The two lists are EQUAL");
            }
            else
            {
                Console.WriteLine("The two lists are NOT equal");
            }

            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list
            numbers.Add(2);
            numbers.Add(20);

            Console.WriteLine(string.Join(", ", numbers));

            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////
            string[] moreWords = new string[] { "Cyan", "Magenta", "White" };
            words.AddRange(moreWords);
            Print(words);


            //////////////////
            // ITERATING BY INDEX
            //////////////////
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine($"{i} {words[i]}");
            }


            Console.WriteLine("=================================");
            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////
            Console.WriteLine($"Does the list contain Green? {words.IndexOf("Green")}");
            Console.WriteLine($"Does the list contain Yellow? {words.IndexOf("Yellow")}");

            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////
            Console.Write("The unsorted list: ");
            Print(words);

            List<string> originalList = new List<string>(words);
            words.Reverse();
            Console.Write("The Reversed list: ");
            Print(words);
            Console.Write("The original list: ");
            Print(originalList);

            words.Sort();
            Console.Write("The Sorted list: ");
            Print(words);



            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.

            Queue<string> todo = new Queue<string>();
            todo.Enqueue("1. Wash the dishes");
            todo.Enqueue("2. Wipe the counters");
            todo.Enqueue("3. Sweep the floor");
            todo.Enqueue("4. Scrub the floor");

            Console.WriteLine(string.Join(", ", todo));

            Console.WriteLine($"The next item in the Q is '{todo.Peek()}'");

            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////
            while (todo.Count > 0)
            {
                string task = todo.Dequeue();
                Console.WriteLine(task);
            }


            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items. 


            ////////////////////
            // PUSHING ITEMS TO THE STACK
            //////////////////// 
            Stack<string> browserStack = new Stack<string>();
            browserStack.Push("Home Page");
            browserStack.Push("Login Page");
            browserStack.Push("Dashboard");
            browserStack.Push("Detail Page");

            Console.WriteLine(string.Join(", ", browserStack)) ;


            ////////////////////
            // POPPING THE STACK
            ////////////////////
            string previousPage = browserStack.Pop();
            Console.WriteLine($"The previous page was: {previousPage}");
            Console.WriteLine(string.Join(", ", browserStack));

            previousPage = browserStack.Peek();
            Console.WriteLine();
            Console.WriteLine($"The previous page was: {previousPage}");
            Console.WriteLine(string.Join(", ", browserStack));

            // This DOES NOT work!
            //foreach (string page in browserStack)
            //{
            //    Console.WriteLine(page);
            //    browserStack.Pop();
            //}

            while(browserStack.Count > 0)
            {
                string page = browserStack.Pop();
                Console.WriteLine(page);
            }

            //Console.ReadLine();

        }

        public static void Print(List<string> list)
        {
            Console.WriteLine(string.Join(", ", list));

        }
    }
}
