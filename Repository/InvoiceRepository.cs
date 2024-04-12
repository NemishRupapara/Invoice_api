using InvoiceAppApi.Dto;
using InvoiceAppApi.Interffaces;
using InvoiceAppApi.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace InvoiceAppApi.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IConfiguration _configuration;

        public InvoiceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool AddInvoice(InvoiceDto Invoice)
        {
            int insertedID = 0;

            string connectionString = _configuration.GetConnectionString("DefaultConnection");


            if (Invoice.Invoice.InvoiceID == 0)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    string inputDate = Invoice.Invoice.BillDate;
                    DateTime dateValue = DateTime.ParseExact(inputDate, "yyyy-MM-dd", null);
                    string formattedDate = dateValue.ToString("dd-MM-yyyy");

                    string inputDate2 = Invoice.Invoice.DueDate;
                    DateTime dateValue2 = DateTime.ParseExact(inputDate2, "yyyy-MM-dd", null);
                    string formattedDate2 = dateValue2.ToString("dd-MM-yyyy");
                    SqlCommand cmd = new SqlCommand("AddInvoice", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@InvoiceNo", Invoice.Invoice.InvoiceNo);
                    cmd.Parameters.AddWithValue("@CustomerName", Invoice.Invoice.CustomerName);
                    cmd.Parameters.AddWithValue("@GSTNo", Invoice.Invoice.GSTNo);
                    cmd.Parameters.AddWithValue("@BillDate", formattedDate);
                    cmd.Parameters.AddWithValue("@DueDate", formattedDate2);
                    cmd.Parameters.AddWithValue("@RemainingDays", Invoice.Invoice.RemainingDays);
                    cmd.Parameters.AddWithValue("@Totalitem", Invoice.Item.Count);
                    cmd.Parameters.AddWithValue("@TotalAmount", Invoice.Invoice.TotalAmount);
                    cmd.Parameters.AddWithValue("@UserID",Invoice.Invoice.UserID);
                    cmd.Parameters.AddWithValue("@PaidAmount", 0);
                    cmd.Parameters.AddWithValue("@RemainingAmount", Invoice.Invoice.TotalAmount);


                    cmd.Parameters.Add("@InsertedID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    insertedID = Convert.ToInt32(cmd.Parameters["@InsertedID"].Value);
                }
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //con.Open();

                //foreach (var item in Invoice.Item)
                //{
                //    using (SqlCommand cmd = new SqlCommand("add3", con))
                //    {
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        cmd.Parameters.AddWithValue("@InvoiceID", insertedID);

                //        cmd.Parameters.AddWithValue("@Item", item.Item);
                //        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                //        cmd.Parameters.AddWithValue("@Rate", item.Rate);
                //        cmd.Parameters.AddWithValue("@Amount", item.Amount);

                //        int rowsAffected = cmd.ExecuteNonQuery();
                //        // You can handle the result as needed
                //    }
                //}
                DataTable dt = new DataTable();
                dt.Columns.Add("InvoiceID");
                dt.Columns.Add("Item");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Rate");
                dt.Columns.Add("Amount");


                foreach (var item in Invoice.Item)
                {
                    dt.Rows.Add(insertedID,item.Item,item.Quantity,item.Rate,item.Amount);
                }


                SqlCommand cmd = new SqlCommand("add3", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ItemTable";
                param.Value = dt;
                cmd.Parameters.Add(param);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



            }

            return true;
        }

        public bool DeleteInvoice(int InvID)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteInvoice", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", InvID);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }

                return true;
        }

        public bool DeletePayment(int paymentID)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeletePaymentAndDetails", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", paymentID);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }

            return true;
        }

        public bool EditInvoice(InvoiceDto Invoice)
        {
            string inputDate = Invoice.Invoice.BillDate;
            DateTime dateValue = DateTime.ParseExact(inputDate, "yyyy-MM-dd", null);
            string formattedDate = dateValue.ToString("dd-MM-yyyy");

            string inputDate2 = Invoice.Invoice.DueDate;
            DateTime dateValue2 = DateTime.ParseExact(inputDate2, "yyyy-MM-dd", null);
            string formattedDate2 = dateValue2.ToString("dd-MM-yyyy");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditInvoice", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@InvoiceID", Invoice.Invoice.InvoiceID);
                cmd.Parameters.AddWithValue("@InvoiceNo", Invoice.Invoice.InvoiceNo);
                cmd.Parameters.AddWithValue("@CustomerName", Invoice.Invoice.CustomerName);
                cmd.Parameters.AddWithValue("@GSTNo", Invoice.Invoice.GSTNo);
                cmd.Parameters.AddWithValue("@BillDate", formattedDate);
                cmd.Parameters.AddWithValue("@DueDate", formattedDate2);
                cmd.Parameters.AddWithValue("@RemainingDays", Invoice.Invoice.RemainingDays);
                cmd.Parameters.AddWithValue("@Totalitem", Invoice.Invoice.Totalitem);
                cmd.Parameters.AddWithValue("@TotalAmount", Invoice.Invoice.TotalAmount);
                cmd.Parameters.AddWithValue("@PaidAmount", 0);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();




                int? tempID = Invoice.Invoice.InvoiceID;
                List<int> idList = Invoice.Item.Where(x => x.ID != 0).Select(item => item.ID).ToList();
                string idString = string.Join(",", idList);


                if (!string.IsNullOrEmpty(idString))
                {

                    con.Open();
                    using (SqlCommand cmd2 = new SqlCommand("DeleteItems", con))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@IDList", idString);
                        cmd2.Parameters.AddWithValue("@InvoiceID", tempID);

                        cmd2.ExecuteNonQuery();

                    }
                    con.Close();
                }
            }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    foreach (var item in Invoice.Item)
                    {
                        //if (item.ID == 0)
                        //{
                        using (SqlCommand cmd = new SqlCommand("Add2", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", item.ID);
                            cmd.Parameters.AddWithValue("@InvoiceID", item.InvoiceID);
                            cmd.Parameters.AddWithValue("@Item", item.Item);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@Rate", item.Rate);
                            cmd.Parameters.AddWithValue("@Amount", item.Amount);

                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                      
                    }
                }
            

            return true;
        }

        public bool EditMultiplePayment(MultiplePayment_ViewModel viewModel)
        {
            int insertedID = 0;

            string connectionString = _configuration.GetConnectionString("DefaultConnection");


            
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    string inputDate = viewModel.Detail.PaymentDate;
                    DateTime dateValue = DateTime.ParseExact(inputDate, "yyyy-MM-dd", null);
                    string formattedDate = dateValue.ToString("dd-MM-yyyy");

                    string inputDate2 = viewModel.Detail.ChequeDate;
                    DateTime dateValue2 = DateTime.ParseExact(inputDate2, "yyyy-MM-dd", null);
                    string formattedDate2 = dateValue2.ToString("dd-MM-yyyy");
                    SqlCommand cmd = new SqlCommand("AddPaymentdetails", con)       
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@CustomerName", viewModel.Detail.CustomerName);
                    cmd.Parameters.AddWithValue("@PaymentMode", viewModel.Detail.PaymentMode);
                    cmd.Parameters.AddWithValue("@ReferenceNo", viewModel.Detail.ReferenceNo);
                    cmd.Parameters.AddWithValue("@PaymentDate", formattedDate);
                    cmd.Parameters.AddWithValue("@ChequeDate", formattedDate2);
                    cmd.Parameters.AddWithValue("@BankName", viewModel.Detail.BankName);
                    cmd.Parameters.AddWithValue("@Amount", viewModel.Detail.Amount);
                  

                    cmd.Parameters.Add("@InsertedID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    insertedID = Convert.ToInt32(cmd.Parameters["@InsertedID"].Value);
                }
            

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (var item in viewModel.InvoicePayments)
                {
                    using (SqlCommand cmd = new SqlCommand("AddInoicePayments", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PaymentID", insertedID);

                        cmd.Parameters.AddWithValue("@InvoiceID", item.InvoiceID);
                       
                        cmd.Parameters.AddWithValue("@SinglePaidAmount", item.SinglePaidAmount);


                        int rowsAffected = cmd.ExecuteNonQuery();
                        // You can handle the result as needed
                    }
                }
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (var item in viewModel.Invoice)
                {
                    using (SqlCommand cmd = new SqlCommand("EditInvoicePayment", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InvoiceID", item.InvoiceID);
                        cmd.Parameters.AddWithValue("@InvoiceNo", item.InvoiceNo);
                        cmd.Parameters.AddWithValue("@TotalAmount", item.TotalAmount);
                        cmd.Parameters.AddWithValue("@PaidAmount", item.PaidAmount);
                        cmd.Parameters.AddWithValue("@RemainingAmount", item.RemainingAmount);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        // You can handle the result as needed
                    }
                }
            }

            return true;
        }

        public bool EditPaymentDetails(MultiplePayment_ViewModel viewModel)
        {
            string inputDate = viewModel.Detail.PaymentDate;
            DateTime dateValue = DateTime.ParseExact(inputDate, "yyyy-MM-dd", null);
            string formattedDate = dateValue.ToString("dd-MM-yyyy");

            string inputDate2 = viewModel.Detail.ChequeDate;
            DateTime dateValue2 = DateTime.ParseExact(inputDate2, "yyyy-MM-dd", null);
            string formattedDate2 = dateValue2.ToString("dd-MM-yyyy");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("EditPaymentDetails2", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", viewModel.Detail.ID);
                    cmd.Parameters.AddWithValue("@CustomerName", viewModel.Detail.CustomerName);
                    cmd.Parameters.AddWithValue("@PaymentMode", viewModel.Detail.PaymentMode);
                    cmd.Parameters.AddWithValue("@ReferenceNo", viewModel.Detail.ReferenceNo);
                    cmd.Parameters.AddWithValue("@PaymentDate", formattedDate);
                    cmd.Parameters.AddWithValue("@ChequeDate", formattedDate2);
                    cmd.Parameters.AddWithValue("@BankName", viewModel.Detail.BankName);
                    cmd.Parameters.AddWithValue("@Amount", viewModel.Detail.Amount);

                    int rowsAffected = cmd.ExecuteNonQuery();

                }
              

            }


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (var item in viewModel.InvoicePayments)
                {
                    //if (item.ID == 0)
                    //{
                    using (SqlCommand cmd = new SqlCommand("EditInvoicePayment2", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", item.ID);
                        cmd.Parameters.AddWithValue("@PaymentID", item.PaymentID);
                        cmd.Parameters.AddWithValue("@InvoiceID", item.InvoiceID);
                        cmd.Parameters.AddWithValue("@InvoiceNo", item.InvoiceNo);
                        cmd.Parameters.AddWithValue("@CustomerName", item.CustomerName);
                        cmd.Parameters.AddWithValue("@TotalAmount", item.TotalAmount);
                        cmd.Parameters.AddWithValue("@PaidAmount", item.PaidAmount);
                        cmd.Parameters.AddWithValue("@RemainingAmount", item.RemainingAmount);
                        cmd.Parameters.AddWithValue("@SinglePaidAmount", item.SinglePaidAmount);


                        int rowsAffected = cmd.ExecuteNonQuery();
                    }

                }
            }


            return true;
        }

        //public bool EditMultiplePayment(List<InvoicePayment> payments)
        //{
        //    string inputDate = payments[0].PaymentDate;
        //    DateTime dateValue = DateTime.ParseExact(inputDate, "yyyy-MM-dd", null);
        //    string formattedDate = dateValue.ToString("dd-MM-yyyy");

        //    string inputDate2 = payments[0].ChequeDate;
        //    DateTime dateValue2 = DateTime.ParseExact(inputDate2, "yyyy-MM-dd", null);
        //    string formattedDate2 = dateValue2.ToString("dd-MM-yyyy");

        //    string connectionString = _configuration.GetConnectionString("DefaultConnection");
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();

        //        // Create an XML structure from the payments list
        //        StringBuilder xmlData = new StringBuilder();
        //        xmlData.Append("<PaymentsData>");
        //        foreach (var payment in payments)
        //        {
        //            xmlData.Append("<Payment>");
        //            xmlData.Append($"<InvoiceID>{payment.InvoiceID}</InvoiceID>");
        //            xmlData.Append($"<InvoiceNo>{payment.InvoiceNo}</InvoiceNo>");
        //            xmlData.Append($"<TotalAmount>{payment.TotalAmount}</TotalAmount>");
        //            xmlData.Append($"<ReceivedAmount>{payment.ReceivedAmount}</ReceivedAmount>");
        //            xmlData.Append($"<RemainingAmount>{payment.RemainingAmount}</RemainingAmount>");
        //            xmlData.Append($"<PaymentMode>{payment.PaymentMode}</PaymentMode>");
        //            xmlData.Append($"<ReferenceNo>{payment.ReferenceNo}</ReferenceNo>");
        //            xmlData.Append($"<SingleEntryAmount>{payment.SingleEntryAmount}</SingleEntryAmount>");
        //            xmlData.Append($"<PaymentDate>{formattedDate}</PaymentDate>");
        //            xmlData.Append($"<ChequeDate>{formattedDate2}</ChequeDate>");
        //            xmlData.Append($"<BankName>{payment.BankName}</BankName>");


        //            xmlData.Append("</Payment>");
        //        }
        //        xmlData.Append("</PaymentsData>");

        //        // Create SqlCommand and pass the XML data as a parameter
        //        SqlCommand cmd = new SqlCommand("EditMultiplePayment", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter parameter = cmd.Parameters.AddWithValue("@PaymentsData", xmlData.ToString());
        //        parameter.SqlDbType = SqlDbType.Xml;

        //        int rowsAffected = cmd.ExecuteNonQuery();
        //        con.Close();

        //        return rowsAffected > 0; // Return true if rows were affected
        //    }
        //}



        public bool EditSinglePayment(Payment payment)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("EditSinglePayment", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@InvoiceID", payment.InvoiceID);
                cmd.Parameters.AddWithValue("@InvoiceNo", payment.InvoiceNo);
                cmd.Parameters.AddWithValue("@TotalAmount", payment.TotalAmount);
                cmd.Parameters.AddWithValue("@ReceivedAmount", payment.PaidAmount);
                cmd.Parameters.AddWithValue("@RemainingAmount", payment.RemainingAmount);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();


            }
            return true;
        }

        public ICollection<InvoiceClass> GetAllInvoiceList()
        {
            var list = new List<InvoiceClass>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("GetAllInvoice", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                using (SqlDataReader reader = cmd2.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new InvoiceClass
                        {
                            InvoiceID = reader.GetInt32(0),
                            InvoiceNo = reader.GetInt32(1),
                            CustomerName = reader.GetString(2),
                            GSTNo = reader.GetString(3),
                            BillDate = reader.GetString(4),
                            DueDate = reader.GetString(5),
                            RemainingDays = reader.GetInt32(6),
                            Totalitem = reader.GetInt32(7),
                            TotalAmount = reader.GetInt32(8),
                            PaidAmount = reader.GetInt32(9),
                            RemainingAmount = reader.GetInt32(10),
                            UserName = reader.GetString(11),


                        };

                        list.Add(note);
                    }
                }
            }
            return list;

        }

        public ICollection<PaymentDetails> GetAllPaymentDetailsList(int userID)
        {
            //GetAllPaymentDetailList
            var list = new List<PaymentDetails>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("GetAllPaymentDetailList", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd2.Parameters.AddWithValue("@UserID", userID);

                using (SqlDataReader reader = cmd2.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new PaymentDetails
                        {
                            ID = reader.GetInt32(0),
                            CustomerName = reader.GetString(1),
                            PaymentMode = reader.GetString(2),
                            ReferenceNo = reader.GetString(3),
                            PaymentDate = reader.GetString(4),
                            ChequeDate = reader.GetString(5),
                            BankName = reader.GetString(6),
                            Amount = reader.GetInt32(7),
                           
                        };

                        list.Add(note);
                    }
                }
            }
            return list;

        }

        public InvoiceDto GetEditInvoiceDetail(int InvID)
        {
            var Data = new InvoiceDto();
            var list = new List<Class1>();
           
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Getitems", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", InvID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var note = new Class1
                        {
                            ID = reader.GetInt32(0),
                            Item = reader.GetString(1),
                            Quantity = reader.GetInt32(2),
                            Rate = reader.GetInt32(3),
                            Amount = reader.GetInt32(4),
                            InvoiceID = reader.GetInt32(5),
                        };
                        Console.WriteLine(note);
                        Console.WriteLine("Hii");
                        list.Add(note);
                    }

                }
                using (var cmd4 = new SqlCommand("GetInvoice", con))
                {
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.Parameters.AddWithValue("@ID", InvID);

                    using (var reader = cmd4.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var billDate = DateTime.ParseExact(reader.GetString(4), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            var dueDate = DateTime.ParseExact(reader.GetString(5), "dd-MM-yyyy", CultureInfo.InvariantCulture);

                            var invdata = new InvoiceClass
                            {
                                InvoiceID = reader.GetInt32(0),
                                InvoiceNo = reader.GetInt32(1),
                                CustomerName = reader.GetString(2),
                                GSTNo = reader.GetString(3),
                                BillDate = billDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                                DueDate = dueDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                                RemainingDays = reader.GetInt32(6),
                                Totalitem = reader.GetInt32(7),
                                TotalAmount = reader.GetInt32(8),
                                PaidAmount = reader.GetInt32(9),
                                RemainingAmount= reader.GetInt32(10),

                            };
                            Data.Invoice = invdata;
                        }
                    }
                }

            }
               Data.Item = list;
            return Data;

        }

        public ICollection<InvoiceClass> GetInvoiceList(int UserID)
        {
            var list = new List<InvoiceClass>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
            SqlCommand cmd2 = new SqlCommand("Get1", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd2.Parameters.AddWithValue("@UserID", UserID);

                using (SqlDataReader reader = cmd2.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new InvoiceClass
                        {
                            InvoiceID = reader.GetInt32(0),
                            InvoiceNo = reader.GetInt32(1),
                            CustomerName = reader.GetString(2),
                            GSTNo = reader.GetString(3),
                            BillDate = reader.GetString(4),
                            DueDate = reader.GetString(5),
                            RemainingDays = reader.GetInt32(6),
                            Totalitem = reader.GetInt32(7),
                            TotalAmount = reader.GetInt32(8),
                            PaidAmount = reader.GetInt32(9),
                            RemainingAmount = reader.GetInt32(10),


                        };

                        list.Add(note);
                    }
                }
            }
            return list;
        }

        public ICollection<InvoiceClass> GetInvoiceListOfCustomer(CustomerPayment Customer)
        {
            var list = new List<InvoiceClass>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("GetInvoiceListOfCustomer", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd2.Parameters.AddWithValue("@UserID", Customer.UserID);
                cmd2.Parameters.AddWithValue("@CustomerName", Customer.Customername);


                using (SqlDataReader reader = cmd2.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new InvoiceClass
                        {
                            InvoiceID = reader.GetInt32(0),
                            InvoiceNo = reader.GetInt32(1),
                            CustomerName = reader.GetString(2),
                            GSTNo = reader.GetString(3),
                            BillDate = reader.GetString(4),
                            DueDate = reader.GetString(5),
                            RemainingDays = reader.GetInt32(6),
                            Totalitem = reader.GetInt32(7),
                            TotalAmount = reader.GetInt32(8),
                            PaidAmount = reader.GetInt32(9),
                            RemainingAmount = reader.GetInt32(10),


                        };

                        list.Add(note);
                    }
                }
            }
            return list;
        }

        public ICollection<InvoicePayment> GetInvoicePaymentForEdit(int PaymentID)
        {
            var list = new List<InvoicePayment>();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("InvoicePaymentList", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd2.Parameters.AddWithValue("@ID", PaymentID);

                using (SqlDataReader reader = cmd2.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var note = new InvoicePayment
                        {
                            ID = reader.GetInt32(0),
                            PaymentID = reader.GetInt32(1),
                            InvoiceID = reader.GetInt32(2),
                            InvoiceNo = reader.GetInt32(3),
                            CustomerName = reader.GetString(4),
                            TotalAmount = reader.GetInt32(5),
                            PaidAmount = reader.GetInt32(6),
                            RemainingAmount = reader.GetInt32(7),
                            SinglePaidAmount = reader.GetInt32(8),
                            


                        };

                        list.Add(note);
                    }
                }
            }
            return list;
        }

        public PaymentDetails GetPaymentDetailForEdit(int ID)
        {
            var data = new PaymentDetails();

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("PaymentDetailsForEdit", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd2.Parameters.AddWithValue("@ID", ID);

                using (SqlDataReader reader = cmd2.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        var billDate = DateTime.ParseExact(reader.GetString(4), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        var dueDate = DateTime.ParseExact(reader.GetString(5), "dd-MM-yyyy", CultureInfo.InvariantCulture);

                        var invdata = new PaymentDetails
                        {
                            ID = reader.GetInt32(0),
                            CustomerName = reader.GetString(1),
                            PaymentMode = reader.GetString(2),
                            ReferenceNo = reader.GetString(3),
                            PaymentDate = billDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                            ChequeDate = dueDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                            BankName = reader.GetString(6),
                            Amount = reader.GetInt32(7),
                        };
                        data= invdata;

                    }
                }
            }
            return data;
        }

        public InvoiceClass GetSinglePaymentdetail(int InvoiceID)
        {
            var Invoice = new InvoiceClass();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (var cmd4 = new SqlCommand("GetpaymentDetailOfsingleInvoice", con))
                {
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.Parameters.AddWithValue("@ID", InvoiceID);
                    con.Open();
                    using (var reader = cmd4.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           

                            var invdata = new InvoiceClass
                            {
                                InvoiceID = reader.GetInt32(0),
                                InvoiceNo = reader.GetInt32(1),
                                TotalAmount = reader.GetInt32(2),
                                PaidAmount = reader.GetInt32(3),
                                RemainingAmount = reader.GetInt32(4)

                            };
                            Invoice= invdata;
                        }
                    }
                }

            }
            return Invoice;
            }




    }
}

    
