using CLI;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;

namespace WorldDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get config if needed
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                        IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("DATABASE");

            // Create DAOs if needed
            //ICityDAO cityDAO = new CitySqlDAO(connectionString);
            //ICountryDAO countryDAO = new CountrySqlDAO(connectionString);

            MainMenu menu = new MainMenu();
            menu.Run();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Goodbye...");
            Thread.Sleep(1500);
        }
    }
}
