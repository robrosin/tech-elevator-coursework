using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using DatabaseAccess.Models;
using System.Data.SqlClient;

namespace DatabaseAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            // Execute a Select using a SQL Connection, Command and ExecuteReader.

            /*****************************************************************************/
            // Get the list of all cities in the world
            IList<City> cities = GetAllCities();

            // Print the list 
            Console.WriteLine(City.GetHeader());
            foreach (City city in cities)
            {
                Console.WriteLine(city);
            }

            Console.Clear();
            /*****************************************************************************/

            /*****************************************************************************/
            // Get the list of all cities in Ohio
            // Execute a Select with parameters
            cities = GetAllCitiesInState("Ohio");
            Console.WriteLine(City.GetHeader());
            foreach (City city in cities)
            {
                Console.WriteLine(city);
            }

            /*****************************************************************************/
            // Execute an Update using ExecuteNonQuery
            UpdateUSPresident("Donald J Trump");


            /*****************************************************************************/
            // Execute an Insert using ExecuteScalar
            AddCity();


            /*****************************************************************************/
            // Execute a Delete using ExecuteNonQuery
            DeleteUSCity("Richfield", "Ohio");

            return;
        }

        private static IList<City> GetAllCities()
        {
            List<City> cities = new List<City>();

            // TODO 02: Add code to list all cities

            return cities;
        }

        private static IList<City> GetAllCitiesInState(string state)
        {
            List<City> cities = new List<City>();

            // TODO03: Add code to list all cities in the given district of the USA

            return cities;
        }

        private static void UpdateUSPresident(string president)
        {
            // TODO 04: Add code to update the US President to what was passed into this method
            return;
        }

        private static void AddCity()
        {
            // TODO 05: Add code to add a new city
            return;
        }

        private static void DeleteUSCity(string cityName, string stateName)
        {
            // TODO 06: Add code to Delete a US city based on parameters passed in
            return;
        }
    }
}
