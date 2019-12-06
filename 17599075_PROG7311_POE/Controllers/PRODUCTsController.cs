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
    public class PRODUCTsController : Controller
    {
        public Entities db = new Entities();

        // GET: PRODUCTs
        public ActionResult Index()
        {
            var pRODUCTS = db.PRODUCTS.Include(p => p.CATEGORY);
            var cART = db.PRODUCTS.Include(i => i.CARTs);
            return View(pRODUCTS.ToList());
        }

        // GET: PRODUCTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Create
        /*public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(db.CATEGORies, "CatID", "CatName");
            return View();
        }*/

        // POST: PRODUCTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdID,CatID,ProdName,Price")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                var user = @Session["userName"];
                var id = pRODUCT.ProdID;
                var price = pRODUCT.Price;
                var cat = pRODUCT.CatID;
                                              

                CART c = new CART();
                c.USERNAME = user.ToString();
                c.ProdID = id;
                c.Price = price;
                c.Cat = cat;

                db.CARTs.Add(c);


                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatID = new SelectList(db.CATEGORies, "CatID", "CatName", pRODUCT.CatID);
            return View("Index", "CARTs");
        }


        // GET: PRODUCTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatID = new SelectList(db.CATEGORies, "CatID", "CatName", pRODUCT.CatID);
            return View(pRODUCT);
        }

        // POST: PRODUCTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdID,CatID,ProdName,Price")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatID = new SelectList(db.CATEGORies, "CatID", "CatName", pRODUCT.CatID);
            return View(pRODUCT);
        }

        // GET: PRODUCTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: PRODUCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            db.PRODUCTS.Remove(pRODUCT);
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
