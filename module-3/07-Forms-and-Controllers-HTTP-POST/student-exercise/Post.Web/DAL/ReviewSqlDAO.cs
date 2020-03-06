using Post.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Web.DAL
{
    public class ReviewSqlDAO : IReviewDAO
    {
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=squirrels;Integrated Security=True";

        public ReviewSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all reviews
        /// </summary>
        /// <returns></returns>
        public IList<ReviewModel> GetAllReviews()
        {
            List<ReviewModel> output = new List<ReviewModel>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql =
                        @"select * from reviews";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        ReviewModel forumPost = RowToObject(reader);
                        output.Add(forumPost);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        private ReviewModel RowToObject(SqlDataReader reader)
        {
            // Create a review
            ReviewModel review = new ReviewModel();
            review.UserName = Convert.ToString(reader["username"]);
            review.Rating = Convert.ToInt32(reader["rating"]);
            review.ReviewTitle = Convert.ToString(reader["review_title"]);
            review.ReviewText = Convert.ToString(reader["review_text"]);
            review.ReviewDate = Convert.ToDateTime(reader["review_date"]);
            return review;
        }

        /// <summary>
        /// Saves a new review to the system.
        /// </summary>
        /// <param name="newReview"></param>
        /// <returns></returns>

        //public bool SaveReview(ReviewModel post)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            string sql = $"INSERT INTO squirrels (username, rating, review_title, review_text, review_date) VALUES (@username, @rating, @review_title, @review_text, GetDate()); Select @@Identity;";
        //            SqlCommand cmd = new SqlCommand(sql, conn);
        //            cmd.Parameters.AddWithValue("@username", post.UserName);
        //            cmd.Parameters.AddWithValue("@rating", post.Rating);
        //            cmd.Parameters.AddWithValue("@review_title", post.ReviewTitle);
        //            cmd.Parameters.AddWithValue("@review_text", post.ReviewText);
        //            cmd.Parameters.AddWithValue("@review_date", post.ReviewDate);


        //            int postVerify = 0;

        //            if (postVerify == Convert.ToInt32(cmd.ExecuteScalar()))
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }

        public int SaveReview(ReviewModel review)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"INSERT INTO squirrels(username, rating, review_title, review_text, review_date) VALUES(@username, @rating, @review_title, @review_text, GetDate()); Select @@Identity; ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", review.UserName);
                    cmd.Parameters.AddWithValue("@rating", review.Rating);
                    cmd.Parameters.AddWithValue("@review_title", review.ReviewTitle);
                    cmd.Parameters.AddWithValue("@review_text", review.ReviewText);
                    cmd.Parameters.AddWithValue("@review_date", review.ReviewDate);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
