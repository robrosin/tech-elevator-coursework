using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WorldDB.Models;

namespace WorldDB.DAL
{
    public class CountrySqlDAO
    {
        private string connectionString;
        public CountrySqlDAO(string connString)
        {
            this.connectionString = connString;
        }
        // TODO 01: Create a CountrySqlDAO class (GetCountries, GetCountries(continent), GetCountry(code))
        public List<Country> GetCountries()
        {
            // Declare the result variable
            List<Country> list = new List<Country>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connetion
                    conn.Open();

                    // Create the command for the sql statement
                    string sql = "Select * from country";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the query and get the result set in a reader
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // For each row, create a new country and add it to the list
                    while (rdr.Read())
                    {
                        Country country = new Country();
                        country.Code = Convert.ToString(rdr["code"]);
                        country.Name = Convert.ToString(rdr["name"]);
                        country.Continent = Convert.ToString(rdr["continent"]);
                        country.Region = Convert.ToString(rdr["region"]);
                        country.GovernmentForm = Convert.ToString(rdr["governmentform"]);
                        country.HeadOfState = Convert.ToString(rdr["headofstate"]);
                        country.LocalName = Convert.ToString(rdr["localname"]);
                        country.Code2 = Convert.ToString(rdr["code2"]);
                        country.SurfaceArea = Convert.ToDouble(rdr["surfacearea"]);
                        country.Population = Convert.ToInt32(rdr["population"]);
                        //--------------
                        if (rdr["indepyear"] is DBNull)
                        {
                            country.IndependenceYear = null;
                        }
                        else
                        {
                            country.IndependenceYear = Convert.ToInt32(rdr["indepyear"]);
                        }
                        //-----------------
                        if (rdr["lifeexpectancy"] is DBNull)
                        {
                            country.LifeExpectency = null;
                        }
                        else
                        {
                            country.LifeExpectency = Convert.ToDouble(rdr["lifeexpectency"]);
                        }
                        //---------------
                        if (rdr["capital"] is DBNull)
                        {
                            country.CapitalID = null;
                        }
                        else
                        {
                            country.CapitalID = Convert.ToInt32(rdr["capital"]);
                        }
                        //----------------
                        if (rdr["gnp"] is DBNull)
                        {
                            country.GNP = null;
                        }
                        else
                        {
                            country.GNP = Convert.ToInt32(rdr["gnp"]);
                        }
                        list.Add(country);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
            }
            return list;
        }
        public List<Country> GetCountries(string continent)
        {
            // Declare the result variable
            List<Country> list = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connetion
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
                        Country country = RowToObject(rdr);
                        list.Add(country);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
            }
            return list;
        }
        public List<Country> GetCountry(string code)
        {
            List<Country> list = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connetion
                    conn.Open();

                    // Create the command for the sql statement
                    string sql = "Select * from country where code = @code";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@code", code);

                    // Execute the query and get the result set in a reader
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // For each row, create a new country and add it to the list
                    while (rdr.Read())
                    {
                        Country country = RowToObject(rdr);
                        list.Add(code);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write(ex.Message);
            }
            return list;
        }
        private static Country RowToObject(SqlDataReader rdr)
        {
            Country country = new Country();
            country.Code = Convert.ToString(rdr["code"]);
            country.Name = Convert.ToString(rdr["name"]);
            country.Continent = Convert.ToString(rdr["continent"]);
            country.Region = Convert.ToString(rdr["region"]);
            country.GovernmentForm = Convert.ToString(rdr["governmentform"]);
            country.HeadOfState = Convert.ToString(rdr["headofstate"]);
            country.LocalName = Convert.ToString(rdr["localname"]);
            country.Code2 = Convert.ToString(rdr["code2"]);
            country.SurfaceArea = Convert.ToDouble(rdr["surfacearea"]);
            country.Population = Convert.ToInt32(rdr["population"]);
            //--------------
            if (rdr["indepyear"] is DBNull)
            {
                country.IndependenceYear = null;
            }
            else
            {
                country.IndependenceYear = Convert.ToInt32(rdr["indepyear"]);
            }
            //-----------------
            if (rdr["lifeexpectancy"] is DBNull)
            {
                country.LifeExpectency = null;
            }
            else
            {
                country.LifeExpectency = Convert.ToDouble(rdr["lifeexpectency"]);
            }
            //---------------
            if (rdr["capital"] is DBNull)
            {
                country.CapitalID = null;
            }
            else
            {
                country.CapitalID = Convert.ToInt32(rdr["capital"]);
            }
            //----------------
            if (rdr["gnp"] is DBNull)
            {
                country.GNP = null;
            }
            else
            {
                country.GNP = Convert.ToInt32(rdr["gnp"]);
            }

            return country;
        }
    }
}