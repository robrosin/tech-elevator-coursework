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
        private const string CONNECTION_STRING = @"Server=.\SqlExpress;Database=World;Trusted_Connection=True;";

        static void Main(string[] args)
        {
            // Execute a Select using a SQL Connection, Command and ExecuteReader.

            /*****************************************************************************/
            // Get the list of all cities in the world
            //IList<City> cities = GetAllCities();

            //Console.WriteLine(City.GetHeader());
            //foreach(City city in cities)
            //{
            //    Console.WriteLine(city);
            //}

            //Console.ReadLine();


            //// Print the list 
            //Console.WriteLine(City.GetHeader());
            //foreach (City city in cities)
            //{
            //    Console.WriteLine(city);
            //}

            Console.Clear();
            /*****************************************************************************/

            /*****************************************************************************/
            // Get the list of all cities in Ohio
            // Execute a Select with parameters
            //IList<City> cities = GetAllCitiesInState("Ohio");
            //Console.WriteLine(City.GetHeader());
            //foreach (City city in cities)
            //{
            //    Console.WriteLine(city);
            //}

            /*****************************************************************************/
            // Execute an Update using ExecuteNonQuery
            //UpdateUSPresident("Dwayne The Rock Johnson");


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
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select top 30 * from city", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    City city = new City()
                    {
                        CityId = Convert.ToInt32(rdr["id"]),
                        Name = Convert.ToString(rdr["name"]),
                        CountryCode = Convert.ToString(rdr["countrycode"]),
                        District = Convert.ToString(rdr["district"]),
                        Population = Convert.ToInt32(rdr["population"])
                    };
                    cities.Add(city);
                }
            }
            return cities;
        }

        private static IList<City> GetAllCitiesInState(string state)
        {
            List<City> cities = new List<City>();

            // TODO03: Add code to list all cities in the given district of the USA
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from city Where countrycode = 'USA' AND district = @district", conn);
                cmd.Parameters.AddWithValue("@district", state);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    City city = new City()
                    {
                        CityId = Convert.ToInt32(rdr["id"]),
                        Name = Convert.ToString(rdr["name"]),
                        CountryCode = Convert.ToString(rdr["countrycode"]),
                        District = Convert.ToString(rdr["district"]),
                        Population = Convert.ToInt32(rdr["population"])
                    };
                    cities.Add(city);
                }
            }


            return cities;
        }

        private static void UpdateUSPresident(string president)
        {
            // TODO 04: Add code to update the US President to what was passed into this method
            string sql = "Update country set headofstate = @headofstate Where code = 'USA'";

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@headofstate", president);
                int rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated == 0)
                {
                    throw new Exception("Not able to update the prez");
                }
                else if (rowsUpdated > 1)
                {
                    throw new Exception($"Oh, crap! {president} now rules the world!");
                }
            }
            return;
        }

        private static void AddCity()
        {
            // TODO 05: Add code to add a new city
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                string sql =
@"Insert into city
(name, countrycode, district, population)
values (@name, @countrycode, @district, @population);
Select @@identity;
";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", "Timbuckfour");
                cmd.Parameters.AddWithValue("@countrycode", "AUS");
                cmd.Parameters.AddWithValue("@district", "New South Wales");
                cmd.Parameters.AddWithValue("@population", 3);

                int newId = Convert.ToInt32( cmd.ExecuteScalar());

                Console.WriteLine($"Added city with id {newId}");
            }
            return;
        }

        private static void DeleteUSCity(string cityName, string stateName)
        {
            // TODO 06: Add code to Delete a US city based on parameters passed in
            return;
        }
    }
}
