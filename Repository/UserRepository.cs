using InvoiceAppApi.Interffaces;
using InvoiceAppApi.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace InvoiceAppApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool AddNewUser(User NewUser)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                {
                    using (SqlCommand cmd = new SqlCommand("AddUser2", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName",NewUser.UserName);
                        cmd.Parameters.AddWithValue("@Password",NewUser.Password );
                        cmd.Parameters.AddWithValue("@RoleID", 3);

                        cmd.ExecuteNonQuery();
                    }
                }
            } 
            return true;    
        }

        public UserDetails GetUserDetails(Login login)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UserValid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", login.UserName);
                    cmd.Parameters.AddWithValue("@Password", login.Password);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var UseDetail = new UserDetails
                            {
                                UserId= reader.GetInt32(1),
                                RoleID = reader.GetInt32(2),
                                Role = reader.GetString(3),
                            };

                           return UseDetail;
                        }
                    }


                }

            }

            return new UserDetails();
        }

    

    public bool LoginCheck(Login login)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            { 
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UserValid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName",login.UserName);
                    cmd.Parameters.AddWithValue("@Password",login.Password);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool userExists = (bool)reader["UserExists"];

                            if (userExists)
                            {
                                return true;
                            }
                        }
                    }


                }

            }

                return false;
        }



    }
}
