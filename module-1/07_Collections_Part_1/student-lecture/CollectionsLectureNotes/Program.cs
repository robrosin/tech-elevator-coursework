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
            List<int> numbers = new List<int>();
            Console.WriteLine(numbers);
            Console.WriteLine($"The numbers list has {numbers.Count} elements");

            // Creating lists of strings
            List<string> words = new List<string>() { "Red", "Blue", "Green" };
            Console.WriteLine(words);
            Console.WriteLine(string.Join(" ", words));

            /////////////////


            //////////////////
            // OBJECT EQUALITY
            //////////////////
            // Create a second list of numbers which is emmpty just like the first
            List<int> numbers2 = new List<int>();

            if (numbers == numbers2)
            {
                Console.WriteLine("Lists are equal");
            }
            else
            {
                Console.WriteLine("Lists are not equal");
            }

            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list
            numbers.Add(2);
            numbers.Add(20);

            Console.WriteLine(string.Join(",", numbers));
            

            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////

            string[] moreWords = new string[] { "Cyan", "Magenta", "White" };
            words.AddRange(moreWords);
            Console.WriteLine(string.Join(",", words));



            //////////////////
            // ITERATING BY INDEX
            //////////////////

            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine($"{i} {words[i]}");
            }



            Console.WriteLine("==============================");

            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////
            ///
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }


            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////
            Console.WriteLine($"Does the list contain Green? {words.Contains("Green")}");
            Console.WriteLine($"Does the list contain Yellow? { words.Contains("Yellow")}");
            Console.WriteLine($"Where in the index is Green? {words.IndexOf("Green")}");


            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////
            ///
            Console.WriteLine("The unsorted list: ");
            Console.WriteLine(string.Join(",", words));

            words.Sort();
            Console.WriteLine("The sorted list: ");
            Console.WriteLine(string.Join(",", words));


            words.Reverse();
            Console.WriteLine("The reversed list: ");
            Console.WriteLine(string.Join(",", words));

            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.

            Queue<string> todo = new Queue<string>();
            todo.Enqueue("1. Wash the dishes");
            todo.Enqueue("2. Wipe the counters");
            todo.Enqueue("3. Sweep the floor");
            todo.Enqueue("4. Scrub the floor");

            Console.WriteLine(string.Join(",", todo));

            //Console.WriteLine($"The next item in the Q is: '{todo.Peek}'");

            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////
            ///

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
            browserStack.Push("Detail");

            Console.WriteLine(string.Join(",", browserStack));


            ////////////////////
            // POPPING THE STACK
            ////////////////////
            string previousPage = browserStack.Pop();
            Console.WriteLine($"The previous page was: {previousPage}");
            Console.WriteLine(string.Join(",", browserStack));

            previousPage = browserStack.Peek();
            Console.WriteLine($"The previous page was: {previousPage}");
            Console.WriteLine(string.Join(",", browserStack));

            //This DOES NOT work!
            //foreach (string page in browserStack)
            //{
            //    Console.WriteLine(page);
            //    browserStack.Pop();
            //}

            while (browserStack.Count > 0)
            {
                string page = browserStack.Pop();
                Console.WriteLine(page);
            }



        }

    }
}
