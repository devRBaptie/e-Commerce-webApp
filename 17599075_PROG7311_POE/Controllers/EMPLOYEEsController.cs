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
    public class EMPLOYEEsController : Controller
    {
        private Entities db = new Entities();

        // GET: EMPLOYEEs
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(_17599075_PROG7311_POE.Models.EMPLOYEE eMPLOYEE)
        {
            using (Entities en = new Entities())
            {
                try
                {
                    var userDetails = en.EMPLOYEES.Where(x => x.EmpUsername == eMPLOYEE.EmpUsername && x.EmpPassword == eMPLOYEE.EmpPassword).FirstOrDefault();

                    if (userDetails == null)
                    {
                        //stuMdbodel.LoginErrorMessage = "Wrong username or password";

                        return View("Index", eMPLOYEE);
                    }
                    else
                    {
                        Session["userName"] = userDetails.EmpUsername;

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
