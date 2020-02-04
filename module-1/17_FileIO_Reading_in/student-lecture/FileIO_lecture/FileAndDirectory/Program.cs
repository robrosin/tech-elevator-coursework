using FileAndDirectory.Classes;
using System;
using System.IO;

namespace FileAndDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            DoDirectoryAndFileStuff();
            return;


            // Use the Navigator to allow the user to move around the file system.
            Navigator nav = new Navigator();
            nav.Run();

            Console.Write("Now, wasn't that FUN???");
            Console.ReadLine();

            return;
        }

        static void DoDirectoryAndFileStuff()
        {
            // Practice some Directory / File class methods


        }
    }
}
