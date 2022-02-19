using LabExam1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabExam1.Controllers
{
    public class ProductController : Controller
    {
        SqlConnection cn;
        public void Open()
        {
            cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=exam;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();
           // Console.WriteLine("connection open done");
        }
        // ProductDao prod = new ProductDao();
        // GET: Product
        public ActionResult Index()
        {
            List<Product> listProd = new List<Product>();
            Open();
            SqlCommand cmdFechAll = new SqlCommand();
            cmdFechAll.Connection = cn;
            cmdFechAll.CommandType = System.Data.CommandType.Text;
            cmdFechAll.CommandText = "Select * from Products";
            try
            {
                SqlDataReader dr = cmdFechAll.ExecuteReader();
                while (dr.Read())
                {
                    listProd.Add(new Product
                    {
                        ProductId = (int)dr["ProductId"],
                        ProductName = (string)dr["ProductName"],
                        Rate = (decimal)dr["Rate"],
                        Description = (string)dr["Description"],
                        CategoryName = (string)dr["CategoryName"]
                    });
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                cn.Close();
            }

            return View(listProd);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product prod)
        {
            Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = System.Data.CommandType.Text;
            cmdUpdate.CommandText = "update Products set ProductName=@ProductName,Rate=@Rate,Description=@Description,CategoryName=@CategoryName where ProductId=@id";


            cmdUpdate.Parameters.AddWithValue("@ProductId", prod.ProductId);
            cmdUpdate.Parameters.AddWithValue("@Rate", prod.Rate);
            cmdUpdate.Parameters.AddWithValue("@Description", prod.Description);
            cmdUpdate.Parameters.AddWithValue("@CategoryName", prod.CategoryName);

            try
            {
                cmdUpdate.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(id);
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
