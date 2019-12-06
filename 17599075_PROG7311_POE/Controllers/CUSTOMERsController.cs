using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _17599075_PROG7311_POE.Models;

namespace _17599075_PROG7311_POE.Controllers
{
    public class CUSTOMERsController : Controller
    {
       
        // GET: CUSTOMERs
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Autherize(_17599075_PROG7311_POE.Models.CUSTOMER cUSTOMER)
        {
            using (Entities en = new Entities())
            {
                try
                {
                    var userDetails = en.CUSTOMERS.Where(x => x.USERNAME == cUSTOMER.USERNAME && x.PASSWORD == cUSTOMER.PASSWORD).FirstOrDefault();

                    if (userDetails == null)
                    {
                        //stuMdbodel.LoginErrorMessage = "Wrong username or password";

                        return View("Index", cUSTOMER);
                    }
                    else
                    {
                        Session["userName"] = userDetails.USERNAME;

                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}
