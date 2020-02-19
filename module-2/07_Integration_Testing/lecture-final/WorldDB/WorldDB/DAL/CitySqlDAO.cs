using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CitySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public bool AddCity(City city)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO city VALUES (@name, @countrycode, @district, @population); Select @@identity As NewId;", conn);
                cmd.Parameters.AddWithValue("@name", city.Name);
                cmd.Parameters.AddWithValue("@countrycode", city.CountryCode);
                cmd.Parameters.AddWithValue("@district", city.District);
                cmd.Parameters.AddWithValue("@population", city.Population);

                // Use ExecuteScalar because we are only getting one column, one row
                int id = Convert.ToInt32(cmd.ExecuteScalar());

                // We could also have done it with ExecuteReader
                //SqlDataReader rdr = cmd.ExecuteReader();
                //rdr.Read();
                //int id = Convert.ToInt32(rdr["NewId"]);

                Console.WriteLine($"The new city id is {id}");
            }
            return true;
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> cities = new List<City>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // column    // param name  
                    SqlCommand cmd = new SqlCommand("SELECT * FROM city WHERE countryCode = @countryCode;", conn);
                    // param name    // param value
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        City city = ConvertReaderToCity(reader);
                        cities.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred reading cities by country.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return cities;
        }

        /// <summary>
        /// Given an id, get the city identified by that id.
        /// </summary>
        /// <param name="id">Id of a city</param>
        /// <returns>City object for the id, NULL if the id does not exist</returns>
        public City GetCityById(int id)
        {
            City city = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // column    // param name  
                SqlCommand cmd = new SqlCommand("SELECT * FROM city WHERE id = @id;", conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    city = ConvertReaderToCity(reader);
                }
            }
            return city;
        }

        private City ConvertReaderToCity(SqlDataReader reader)
        {
            City city = new City();
            city.CityId = Convert.ToInt32(reader["id"]);
            city.Name = Convert.ToString(reader["name"]);
            city.CountryCode = Convert.ToString(reader["countrycode"]);
            city.District = Convert.ToString(reader["district"]);
            city.Population = Convert.ToInt32(reader["population"]);

            return city;
        }
    }
}
