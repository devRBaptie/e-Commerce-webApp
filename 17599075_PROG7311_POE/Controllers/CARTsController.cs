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
    public class CARTsController : Controller
    {
        private Entities db = new Entities();

        // GET: CARTs
        public ActionResult Index()
        {
            var cARTs = db.CARTs.Include(c => c.PRODUCT).Include(c => c.CUSTOMER);
            return View(cARTs.ToList());
        }

        // GET: CARTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CART cART = db.CARTs.Find(id);
            if (cART == null)
            {
                return HttpNotFound();
            }
            return View(cART);
        }

        // GET: CARTs/Create
        public ActionResult Create()
        {
            ViewBag.ProdID = new SelectList(db.PRODUCTS, "ProdID", "CatID");
            ViewBag.USERNAME = new SelectList(db.CUSTOMERS, "USERNAME", "PASSWORD");
            return View();
        }

        // POST: CARTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USERNAME,ProdID,Price,Cat")] CART cART)
        {
            if (ModelState.IsValid)
            {
                db.CARTs.Add(cART);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdID = new SelectList(db.PRODUCTS, "ProdID", "CatID", cART.ProdID);
            ViewBag.USERNAME = new SelectList(db.CUSTOMERS, "USERNAME", "PASSWORD", cART.USERNAME);
            return View(cART);
        }

        // GET: CARTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CART cART = db.CARTs.Find(id);
            if (cART == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdID = new SelectList(db.PRODUCTS, "ProdID", "CatID", cART.ProdID);
            ViewBag.USERNAME = new SelectList(db.CUSTOMERS, "USERNAME", "PASSWORD", cART.USERNAME);
            return View(cART);
        }

        // POST: CARTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USERNAME,ProdID,Price,Cat")] CART cART)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cART).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdID = new SelectList(db.PRODUCTS, "ProdID", "CatID", cART.ProdID);
            ViewBag.USERNAME = new SelectList(db.CUSTOMERS, "USERNAME", "PASSWORD", cART.USERNAME);
            return View(cART);
        }

        // GET: CARTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CART cART = db.CARTs.Find(id);
            if (cART == null)
            {
                return HttpNotFound();
            }
            return View(cART);
        }

        // POST: CARTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CART cART = db.CARTs.Find(id);
            db.CARTs.Remove(cART);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
