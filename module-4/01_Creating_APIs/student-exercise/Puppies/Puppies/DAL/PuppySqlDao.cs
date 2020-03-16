using Puppies.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Puppies.DAL
{
    public class PuppySqlDao : IPuppyDao
    {
        private readonly string connectionString;

        public PuppySqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all puppies
        /// </summary>
        /// <returns></returns>
        public IList<Puppy> GetPuppies()
        {
            List<Puppy> output = new List<Puppy>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM puppy", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(new Puppy()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Weight = Convert.ToInt32(reader["weight"]),
                            Gender = Convert.ToString(reader["gender"]),
                            PaperTrained = Convert.ToBoolean(reader["paper_trained"]),
                        });
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return output;
        }

        /// <summary>
        /// Returns a specific puppy
        /// </summary>
        /// <returns></returns>
        public Puppy GetPuppy(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM puppy WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Puppy()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Weight = Convert.ToInt32(reader["weight"]),
                            Gender = Convert.ToString(reader["gender"]),
                            PaperTrained = Convert.ToBoolean(reader["paper_trained"]),
                        };
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return null;
        }

        /// <summary>
        /// Saves a new puppy to the system.
        /// </summary>
        /// <param name="newPuppy"></param>
        /// <returns></returns>
        public int AddPuppy(Puppy newPuppy)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO puppy (name, weight, gender, paper_trained) VALUES (@name, @weight, @gender, @paper_trained); Select @@Identity;", conn);
                    cmd.Parameters.AddWithValue("@name", newPuppy.Name);
                    cmd.Parameters.AddWithValue("@weight", newPuppy.Weight);
                    cmd.Parameters.AddWithValue("@gender", newPuppy.Gender);
                    cmd.Parameters.AddWithValue("@paper_trained", newPuppy.PaperTrained);

                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    return id;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void UpdatePuppy(Puppy puppy)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        @"Update puppy Set
                        name = @name,
                        weight = @weight,
                        gender = @gender, 
                        paper_trained = @paper_trained
                        Where id = @id", 
                    conn);
                    cmd.Parameters.AddWithValue("@id", puppy.Id);
                    cmd.Parameters.AddWithValue("@name", puppy.Name);
                    cmd.Parameters.AddWithValue("@weight", puppy.Weight);
                    cmd.Parameters.AddWithValue("@gender", puppy.Gender);
                    cmd.Parameters.AddWithValue("@paper_trained", puppy.PaperTrained);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void DeletePuppy(int puppyId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        @"Delete puppy
                        Where id = @id",
                    conn);
                    cmd.Parameters.AddWithValue("@id", puppyId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
