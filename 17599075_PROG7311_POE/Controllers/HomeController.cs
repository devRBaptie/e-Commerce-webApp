using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17599075_PROG7311_POE.Controllers
{
    public class HomeController : Controller
    {

        private OleDbConnection dbConn;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult addShorts()
        {
            try
            {
                string sConnection;
                sConnection = "Data Source=DESKTOP-7ICH5MT/APRESS_DEV1;Initial Catalog=17599075_PROG7311_POE;Integrated Security=True";


                dbConn = new OleDbConnection(sConnection);
                dbConn.Open();

                //label1.Text = "Login Successful";

            }
            catch
            {
                //this.Hide();
                //MessageBox.Show("Connection Failed");

            }

            string sql;
            sql = "USE [17599075_PROG7311_POE] INSERT INTO CART(USERNAME, Price, Price, Cat) VALUES (" + @Session["userName"] + ", 2, 200, 2;";   // Note the two semicolons
            OleDbCommand dbCmd = new OleDbCommand();
            dbCmd.CommandText = sql;    // set command  SQL string
            dbCmd.Connection = dbConn; // dbConn is connection object 

            OleDbDataReader dr;
            dr = dbCmd.ExecuteReader();

            dbConn.Close();


            return View();

        }
        
        
    }
}