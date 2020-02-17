using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CountrySqlDAO : ICountryDAO
    {
        //TODO 01: Create a CountrySqlDAO class (GetCountries, GetCountries(continent), GetCountry(code))

        private string connectionString;

        public CountrySqlDAO(string connString)
        {
            this.connectionString = connString;
        }

        public IList<Country> GetCountries()
        {
            // Declare the result variable
            List<Country> list = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create the command for the sql statement
                    string sql = "Select * from country";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the query and get the result set in a reader
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // For each row, create a new country and add it to the list
                    while (rdr.Read())
                    {
                        Country country = RowToObject(rdr);

                        list.Add(country);

                    }

                }
            }
            catch (SqlException ex)
            {
                // TODO: We should log this somewhere
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        private static Country RowToObject(SqlDataReader rdr)
        {
            Country country = new Country();
            country.Code = Convert.ToString(rdr["code"]);
            country.Name = Convert.ToString(rdr["Name"]);
            country.Continent = Convert.ToString(rdr["Continent"]);
            country.Region = Convert.ToString(rdr["Region"]);
            country.GovernmentForm = Convert.ToString(rdr["GovernmentForm"]);
            country.HeadOfState = Convert.ToString(rdr["HeadOfState"]);
            country.LocalName = Convert.ToString(rdr["LocalName"]);
            country.Code2 = Convert.ToString(rdr["Code2"]);

            country.SurfaceArea = Convert.ToDouble(rdr["surfacearea"]);

            if (rdr["indepyear"] is DBNull)
            {
                country.IndependenceYear = null;
            }
            else
            {
                country.IndependenceYear = Convert.ToInt32(rdr["indepyear"]);
            }

            if (rdr["capital"] is DBNull)
            {
                country.CapitalId = null;
            }
            else
            {
                country.CapitalId = Convert.ToInt32(rdr["capital"]);
            }

            if (rdr["gnp"] is DBNull)
            {
                country.GNP = null;
            }
            else
            {
                country.GNP = Convert.ToDecimal(rdr["gnp"]);
            }

            if (rdr["lifeexpectancy"] is DBNull)
            {
                country.LifeExpectancy = null;
            }
            else
            {
                country.LifeExpectancy = Convert.ToDouble(rdr["lifeexpectancy"]);
            }

            country.Population = Convert.ToInt32(rdr["population"]);
            return country;
        }

        public IList<Country> GetCountries(string continent)
        {
            // Declare the result variable
            List<Country> list = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create the command for the sql statement
                    string sql = "Select * from country where continent = @continent";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@continent", continent);

                    // Execute the query and get the result set in a reader
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // For each row, create a new country and add it to the list
                    while (rdr.Read())
                    {
                        list.Add(RowToObject(rdr));
                    }

                }
            }
            catch (SqlException ex)
            {
                // TODO: We should log this somewhere
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public Country GetCountry(string code)
        {
            // Declare the result variable
            Country country = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create the command for the sql statement
                    string sql = "Select * from country where code = @code";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@code", code);

                    // Execute the query and get the result set in a reader
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // For each row, create a new country and add it to the list
                    if (rdr.Read())
                    {
                        country = RowToObject(rdr);
                    }

                }
            }
            catch (SqlException ex)
            {
                // TODO: We should log this somewhere
                Console.WriteLine(ex.Message);
            }

            return country;
        }

    }
}
