using InvoiceAppApi.Interffaces;
using InvoiceAppApi.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace InvoiceAppApi.Repository
{
    public class CustomerRepository : IcustomerRepository

    {
        private readonly IConfiguration _configuration;

        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool AddCustomer(Customer Customer)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddCustomerName", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Customername", Customer.Customername);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool AddItemname(ItemName Item)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddItemName", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ItemName", Item.Item_Name);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
                return true;
        }

        public bool AddMenu(MenuModel Menu)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddNewMenu", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Menu", Menu.Menu);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool AddPaymentMode(PaymentModeModel PaymentMode)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddPaymentMode", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode.PaymentMode);
                cmd.Parameters.AddWithValue("@IsActive", PaymentMode.IsActive);



                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool AddRole(RoleClass Role)
        {

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddRoleName", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Role", Role.Role);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool AddUser(User User)
        {

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Adduser2", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserName", User.UserName);
                cmd.Parameters.AddWithValue("@Password", User.Password);
                cmd.Parameters.AddWithValue("@RoleID", 3);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool DeleteCustomer(int Id)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteCustomer", con)
                {

                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", Id);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

            }
            return true;
        }

        public bool DeleteItemName(int Id)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteItemFromItemName", con)
                {

                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", Id);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
                return true;
        }

        public bool DeleteMenu(int Id)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteMenu", con)
                {

                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", Id);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool DeletePaymentMode(int Id)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeletePaymentMode", con)
                {

                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", Id);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool DeleteRole(int Id)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteRole", con)
                {

                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", Id);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool DeleteUser(int Id)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", con)
                {

                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", Id);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool EditCustomerName(Customer Customer)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditCustomerName", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", Customer.ID);
                cmd.Parameters.AddWithValue("@Customername", Customer.Customername);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool EditItemName(ItemName Item)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditItemName", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", Item.ID);
                cmd.Parameters.AddWithValue("@ItemName", Item.Item_Name);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;

        }

        public bool EditMenu(MenuModel Menu)
        {

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditMenuName", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID",Menu.ID);
                cmd.Parameters.AddWithValue("@Menu", Menu.Menu);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool EditPaymentModed(PaymentModeModel PaymentMode)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditPaymentMode", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", PaymentMode.ID);
                cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode.PaymentMode);
                cmd.Parameters.AddWithValue("@IsActive", PaymentMode.IsActive);



                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool EditPermissions(List<Rolepermissions> Permissions)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (var item in Permissions)
                {
                    //if (item.ID == 0)
                    //{
                    using (SqlCommand cmd = new SqlCommand("ChangePermission", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Menu", item.Menu);
                        cmd.Parameters.AddWithValue("@Add", item.Add);
                        cmd.Parameters.AddWithValue("@Edit", item.Edit);
                        cmd.Parameters.AddWithValue("@Delete", item.Delete);
                        cmd.Parameters.AddWithValue("@View", item.View);
                        cmd.Parameters.AddWithValue("@RoleID", item.RoleID);


                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            return true;
        }

        public bool EditRoleName(RoleClass Role)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditRoleName", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", Role.ID);
                cmd.Parameters.AddWithValue("@Role", Role.Role);


                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool EditUser(User User)
        {

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditUserName", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", User.ID);
                cmd.Parameters.AddWithValue("@UserName", User.UserName);
                cmd.Parameters.AddWithValue("@PassWord", User.Password);



                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public ICollection<MenuModel> GetAllMenuList()
        {
            var list2 = new List<MenuModel>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetAllMenuList", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new MenuModel
                        {
                            ID = reader.GetInt32(0),
                            Menu = reader.GetString(1),

                        };


                        list2.Add(note);
                    }

                }

                return list2;
            }
        }

        public ICollection<User2> GetAllUserList()
        {
            var list = new List<User2>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();
                SqlCommand cmd2 = new SqlCommand("GetAllUserList", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = cmd2.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new User2
                        {
                            UserName = reader.GetString(0),
                            Password = reader.GetString(1),
                            RoleID = reader.GetInt32(2),
                            ID = reader.GetInt32(3),
                            Role = reader.GetString(4),
                        };


                        list.Add(note);
                    }

                }

                return list;
            }
        }

        public ICollection<Customer> GetCustomerList()
        {
            var list2 =new List<Customer>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetCustomerName", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new Customer
                        {
                            ID = reader.GetInt32(0),
                            Customername = reader.GetString(1),

                        };


                        list2.Add(note);
                    }

                }

                return list2;
            }
        }

        public ICollection<ItemName> GetItemList()
        {
            var list2 = new List<ItemName>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetItemName", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new ItemName
                        {
                            ID = reader.GetInt32(0),
                            Item_Name = reader.GetString(1),

                        };


                        list2.Add(note);
                    }

                }

                return list2;
            }
        }

        public ICollection<PaymentModeModel> GetPaymentModeList()
        {
            var list2 = new List<PaymentModeModel>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetAllPaymentMethodList", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new PaymentModeModel
                        {
                            ID = reader.GetInt32(0),
                            PaymentMode = reader.GetString(1),
                            IsActive = reader.GetInt32(2),


                        };


                        list2.Add(note);
                    }

                }

                return list2;
            }
        }

        public ICollection<PaymentModeModel> GetPaymentModeList2()
        {
            var list2 = new List<PaymentModeModel>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetPaymentMode2", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new PaymentModeModel
                        {
                            ID = reader.GetInt32(0),
                            PaymentMode = reader.GetString(1),
                            IsActive = reader.GetInt32(2),


                        };


                        list2.Add(note);
                    }

                }

                return list2;
            }
        }

        public ICollection<RoleClass> GetRoleList()
        {

            var list2 = new List<RoleClass>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetRoles", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new RoleClass
                        {
                            ID = reader.GetInt32(0),
                            Role = reader.GetString(1),

                        };


                        list2.Add(note);
                    }

                }

                return list2;
            }
            }

        public ICollection<Rolepermissions> GetRolePermissions(int RoleId)
        {
            var list2 = new List<Rolepermissions>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd3 = new SqlCommand("TempList", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd3.Parameters.AddWithValue("@RoleID", RoleId);

                using (SqlDataReader reader = cmd3.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note2 = new Rolepermissions
                        {
                            Menu = reader.GetString(0),
                            Add = reader.GetInt32(1),
                            Edit = reader.GetInt32(2),
                            Delete = reader.GetInt32(3),
                            View = reader.GetInt32(4),
                            RoleID = reader.GetInt32(5),

                        };


                        list2.Add(note2);
                    }

                }
            }

                return list2;
            }

        public ICollection<Rolepermissions> GetUserPermission(int RoleID)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                var list2 = new List<Rolepermissions>();

                SqlCommand cmd3 = new SqlCommand("GetUserPermissionList", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                
                    con.Open();

                

                cmd3.Parameters.AddWithValue("@RoleID", RoleID);

                using (SqlDataReader reader = cmd3.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new Rolepermissions
                        {
                            Menu = reader.GetString(0),
                            Add = reader.GetInt32(1),
                            Edit = reader.GetInt32(2),
                            Delete = reader.GetInt32(3),
                            View = reader.GetInt32(4),

                        };

                        list2.Add(note);
                    }
                    return list2;

                }
            }
        }

        public bool GiveRole(GiveRole Role)
        {

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ProvideRole", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RID", Role.RoleID);
                cmd.Parameters.AddWithValue("@UID", Role.UserID);



                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
    }
}
