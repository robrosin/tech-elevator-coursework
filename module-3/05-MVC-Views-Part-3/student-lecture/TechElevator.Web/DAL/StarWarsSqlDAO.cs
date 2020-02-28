using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TechElevator.Web.Models;

namespace TechElevator.Web.DAL
{
    public class StarWarsSqlDAO : IStarWarsDAO
    {
        private string connectionString;
        public StarWarsSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private IList<Film> GetList(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql);
            return GetList(cmd);
        }

        private IList<Film> GetList(SqlCommand cmd)
        {
            IList<Film> list = new List<Film>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                cmd.Connection = conn;

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(RowToObject(rdr));
                }
            }
            return list;
        }

        private Film RowToObject(SqlDataReader rdr)
        {
            Film obj = new Film();
            obj.Id = Convert.ToString(rdr["Id"]);
            obj.Name = Convert.ToString(rdr["Name"]);
            obj.Description = Convert.ToString(rdr["Description"]);
            obj.Series = Convert.ToString(rdr["Series"]);
            obj.ImageUrl = Convert.ToString(rdr["ImageUrl"]);
            obj.Length = Convert.ToInt32(rdr["Length"]);
            obj.YearReleased = Convert.ToInt32(rdr["YearReleased"]);
            return obj;
        }

        public Film GetFilm(string id)
        {
            SqlCommand cmd = new SqlCommand("Select * from Film where Id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            IList<Film> films = GetList(cmd);
            if (films.Count == 0)
            {
                return null;
            }
            return films[0];
        }

        public IList<Film> GetFilms()
        {
            return GetList("select * from Film");
        }

        public IList<Film> GetFilms(string searchFor, string series)
        {
            if (searchFor == null)
            {
                searchFor = "";
            }
            if (series == null)
            {
                series = "";
            }
            string sql = "Select * from Film where (Name like @searchfor or Description like @searchFor) and series like @series";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@searchFor", $"%{searchFor}%");
            cmd.Parameters.AddWithValue("@series", $"%{series}%");
            return GetList(cmd);
        }
    }
}
