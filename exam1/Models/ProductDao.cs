//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace LabExam1.Models
//{
//    public class ProductDao
//    {
//        SqlConnection cn;
//        public void Open()
//        {
//            cn = new SqlConnection();
//            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=exam;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//            cn.Open();
//            Console.WriteLine("connection open done");
//        }

//        public List<Product> GetAllProducts()
//        {
//            List<Product> listProd = new List<Product>();
//            Open();
//            SqlCommand cmdFechAll = new SqlCommand();
//            cmdFechAll.Connection = cn;
//            cmdFechAll.CommandType = System.Data.CommandType.Text;
//            cmdFechAll.CommandText = "Select * from Products";
//            try
//            {
//                SqlDataReader dr = cmdFechAll.ExecuteReader();
//                while (dr.Read())
//                {
//                    listProd.Add(new Product
//                    { ProductId = (int)dr["ProductId"],
//                        ProductName = (string)dr["ProductName"],
//                        Rate = (decimal)dr["Rate"],
//                        Description = (string)dr["Description"],
//                        CategoryName = (string)dr["CategoryName"]
//                    });
//                }
//            }

//            catch(Exception ex)
//            {
//                Console.WriteLine(ex.Message);

//            }
//            finally
//            {
//                cn.Close();
//            }
//            return listProd;
//        }
//        public void ProductUpdate(int id, Product prod)
//        {
//        Open();

//        SqlCommand cmdUpdate = new SqlCommand();
//            cmdUpdate.Connection = cn;
//            cmdUpdate.CommandType = System.Data.CommandType.Text;
//            cmdUpdate.CommandText = "update Products set ProductName=@ProductName,Rate=@Rate,Description=@Description,CategoryName=@CategoryName";


//            cmdUpdate.Parameters.AddWithValue("@ProductId",prod.ProductId);
//            cmdUpdate.Parameters.AddWithValue("@Rate", prod.Rate);
//            cmdUpdate.Parameters.AddWithValue("@Description", prod.Description);
//            cmdUpdate.Parameters.AddWithValue("@CategoryName", prod.CategoryName);

//            try
//            {
//                cmdUpdate.ExecuteNonQuery();
//            }
//            catch(Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                cn.Close();
//            }

//    }
//    }
//}