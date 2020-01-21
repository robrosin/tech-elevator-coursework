using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use our custom Person data type (class)
            CreatePerson();

            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e
            char firstChar = name[0];
            char lastChar = name[name.Length - 1];
            Console.WriteLine($"First and Last Character. {firstChar}, {lastChar} ");

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            Console.WriteLine($"First 3 characters: {name.Substring(0, 3)}");

            // 3. Now print out the first three and the last three characters
            // Output: Adaace

            Console.WriteLine($"First 3 & Last 3 characters: {name.Substring(0, 3)}{name.Substring(name.Length-3, 3)}");

            // 4. What about the last word?
            // Output: Lovelace
            string[] names = name.Split(' ');

            Console.WriteLine($"Last Word: {names[names.Length-1]}");


            // Join the names back together, with a colon between
            string joinedName = string.Join(":", names);

            Console.WriteLine($"Joined name is {joinedName}");

            // 5. Does the string contain inside of it "Love"?
            // Output: true

            Console.WriteLine($"Contains \"Love\" is {name.Contains("love", StringComparison.InvariantCultureIgnoreCase)}");

            // 6. Where does the string "lace" show up in name?
            // Output: 8

            Console.WriteLine($"Index of \"lace\": {name.IndexOf("lace")} ");

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3
            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == 'a' || name[i] == 'A')
                {
                    count++;
                }
            }
            Console.WriteLine($"Number of \"a's\": {count}");

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"

            name = name.Replace("Ada", "Ada, Countess of Lovelace");
            Console.WriteLine(name);

            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if (name == null)
            {
                Console.WriteLine("All Done");
            }

            // Console.ReadLine();
        }

        public static void CreatePerson()
        {
            // Create a new Person object from the Person class
            Person instructor;
            instructor = new Person();

            // Set the properties of this object
            instructor.FirstName = "Mike";
            instructor.LastName = "Morel";
            instructor.HeightInches = 71;

            // Create another person and set its value.
            Person student = new Person();
            student.FirstName = "Karina";
            student.LastName = "Gentile";
            student.HeightInches = 67;

            Console.WriteLine($"Instructor is {instructor.FirstName} {instructor.LastName}");
        }
    }

}