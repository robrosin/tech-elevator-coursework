using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;
using WorldDB.DAL;
using WorldDB.Models;

namespace WorldDB.Tests
{
    [TestClass]
    public class CitySQLDAOTests
    {
        private TransactionScope transaction = null;
        private string connectionString = "Server=.\\SqlExpress;Database=World;Trusted_Connection=True;";
        private int newCityId;

        [TestInitialize]
        public void SetupDatabase()
        {
            // Start a transaction so we can roll back when we are finished with this test
            transaction = new TransactionScope();

            // Open Setup.sql and read in the script to be executed
            string setupSQL;
            using (StreamReader rdr = new StreamReader("Setup.sql"))
            {
                setupSQL = rdr.ReadToEnd();
            }

            // Connect to the database and execute the script
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(setupSQL, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                // Get the result (new city id) and save it for use later in a test
                if (rdr.Read())
                {
                    newCityId = Convert.ToInt32(rdr["newCityId"]);
                }
            }
        }
        [TestCleanup]
        // Roll back the transaction to get our good data back
        public void CleanupDatabase()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void GetCitiesByCountryCodeTest()
        {
            // Initialize data in the DB
            // SetupDatabase();

            // Perform our test
            // ------ Arrange
            CitySqlDAO dao = new CitySqlDAO(connectionString);

            // ------ Act
            IList<City> cities = dao.GetCitiesByCountryCode("USA");

            // ------ Assert
            Assert.AreEqual(2, cities.Count);

            // Go back to the original DB values
            // CleanupDatabase();
        }
        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AddCityTest_BadCountry()
        {
            City city = new City()
            {
                CountryCode = "XYZ",
                Name = "Who cares",
                Population = 1,
                District = "Who cares"
            };

            CitySqlDAO dao = new CitySqlDAO(connectionString);

            dao.AddCity(city);
        }
    }
}