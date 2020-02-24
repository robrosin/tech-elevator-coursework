using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Carts
{
    public class CartSqlDao : ICartDao
    {
        private readonly string connectionString;

        public CartSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Cart> GetAllCarts()
        {
            // Implement this method to pull in all carts from database
            List<Cart> carts = new List<Cart>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "Select * from carts";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cart cart = Save(rdr);

                    carts.Add(cart);
                }
            }
            return carts;
        }

        public Cart Save(SqlDataReader newCart)
        {
            // Implement this method to save cart to database
            Cart cart = new Cart();
            cart.Id = Convert.ToInt32(newCart["id"]);
            cart.Username = Convert.ToString(newCart["username"]);
            cart.CookieValue = Convert.ToString(newCart["cookie_value"]);
            cart.Created = Convert.ToDateTime(newCart["created"]);

            return cart;
        }

        //public Cart Save(Cart newCart)
        //{
        //    // Implement this method to save cart to database
        //    Cart cart = new Cart();
        //    cart.Id = Convert.ToInt32(newCart["id"]);
        //    cart.Username = Convert.ToString(newCart["username"]);
        //    cart.CookieValue = Convert.ToString(newCart["cookie_value"]);
        //    cart.Created = Convert.ToDateTime(newCart["created"]);

        //    return cart;
        //}
    }
}