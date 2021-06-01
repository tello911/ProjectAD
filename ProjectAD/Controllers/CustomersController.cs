using ProjectAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ProjectAD.Controllers
{
    public class CustomersController : Controller
    {
        ADprojectEntities db = new ADprojectEntities();
        // GET: Customers
        public ActionResult Index()
        {
            using(var db = new ADprojectEntities())
            {
                var data = db.Products.ToList();
                return View(data);
            }
                
            
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id=0)
        {
            if (id == 0)
            {
                //return this.RedirectToAction("Index", "Home");
                Response.Write("<script>alert('No detail found');window.location = '/Customers';</script>");
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
            // GET: Customers/Create
            public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
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

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
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
