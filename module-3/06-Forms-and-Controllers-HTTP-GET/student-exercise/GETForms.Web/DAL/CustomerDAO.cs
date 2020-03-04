using GETForms.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.DAL
{
    public class CustomerDAO : ICustomerDAO
    {
        private string connectionString;

        public CustomerDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Searches for customers.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public IList<Customer> SearchForCustomers(string search, string sortBy)
        {
            IList<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM customer WHERE last_name LIKE @name or first_name LIKE @name ORDER BY CASE @sort WHEN 'last_name' THEN last_name WHEN 'email' THEN email WHEN 'active' THEN active END", connection);
                cmd.Parameters.AddWithValue("@name", "%" + search + "%");
                cmd.Parameters.AddWithValue("@sort", sortBy);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(MapRowToCustomer(reader));
                }
            }

            return customers;
        }

        private Customer MapRowToCustomer(SqlDataReader reader)
        {
            return new Customer()
            {
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"]),
                Email = Convert.ToString(reader["email"]),
                IsActive = Convert.ToBoolean(reader["active"])
            };
        }
    }
}