using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADO
{
    public class AccountRepositoryADO : IAccountRepository
    {
        public void AddContact(Contacts contacts)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Name", contacts.Name);
                cmd.Parameters.AddWithValue("@Email", contacts.Email);
                cmd.Parameters.AddWithValue("@Phone", contacts.Phone);
                cmd.Parameters.AddWithValue("@Message", contacts.Message);
                cn.Open();
                cmd.ExecuteNonQuery();
                contacts.ContactId = (int)param.Value;
            }
        }
        public IEnumerable<UsersList> GetUsers()
        {
            List<UsersList> users = new List<UsersList>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UserSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UsersList row = new UsersList();

                        row.UserId = dr["UserId"].ToString();
                        row.RoleId = dr["RoleId"].ToString();
                        row.Email = dr["Email"].ToString();
                        row.UserName = dr["UserName"].ToString();
                        users.Add(row);
                    }
                }
            }
            return users;
        }
    }
}
