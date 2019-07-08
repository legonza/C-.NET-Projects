using DvdLibraryWebAPI.Interfaces;
using DvdLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI.Repositories
{
    public class ADORepository : IDvdRepository
    {
        public List<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=DvdLibraryDatabase;" + "Trusted_Connection=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GetAllDvds";
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.dvdId = (int)dr["dvdId"];
                        currentRow.title = dr["title"].ToString();
                        currentRow.releasedYear = (int)dr["releasedYear"];
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public Dvd Get(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryDatabase"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GetDvdById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dvdId", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.dvdId = (int)dr["dvdId"];
                        currentRow.title = dr["title"].ToString();
                        currentRow.releasedYear = (int)dr["releasedYear"];
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        currentRow.notes = dr["notes"].ToString();
                        return currentRow;
                    }
                }
                cmd.ExecuteNonQuery();
            }
            return null;
        }

        public void Add(Dvd dvd)
        {
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryDatabase"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "AddDvd";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@title", dvd.title);
                cmd.Parameters.AddWithValue("@releasedYear", dvd.releasedYear);
                cmd.Parameters.AddWithValue("@director", dvd.director);
                cmd.Parameters.AddWithValue("@rating", dvd.rating);
                cmd.Parameters.AddWithValue("@notes", dvd.notes);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryDatabase"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "EditDvdById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdId", dvd.dvdId);
                cmd.Parameters.AddWithValue("@title", dvd.title);
                cmd.Parameters.AddWithValue("@releasedYear", dvd.releasedYear);
                cmd.Parameters.AddWithValue("@director", dvd.director);
                cmd.Parameters.AddWithValue("@rating", dvd.rating);
                cmd.Parameters.AddWithValue("@notes", dvd.notes);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int ID)
        {
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryDatabase"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DeleteDvdById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dvdId", ID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}