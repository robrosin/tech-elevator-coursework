using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using WorldDB.DAL;
using WorldDB.Views;

namespace WorldDB
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                        IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("World");

            ICityDAO cityDAO = new CitySqlDAO(connectionString);
            ICountryDAO countryDAO = new CountrySqlDAO(connectionString);
            ILanguageDAO languageDAO = new LanguageSqlDAO(connectionString);

            WorldDBMenu menu = new WorldDBMenu(cityDAO, countryDAO, languageDAO);
            menu.Run();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Goodbye...");
            Thread.Sleep(1500);
        }
    }
}
