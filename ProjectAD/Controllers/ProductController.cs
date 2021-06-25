using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectAD.Models;

namespace ProjectAD.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product/Index
        ADprojectEntities dbModel = new ADprojectEntities();
        public ActionResult Index()
        {
            using (ADprojectEntities dbModel = new ADprojectEntities())
            {
                return View(dbModel.Products.ToList());

            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            using (ADprojectEntities dbModel = new ADprojectEntities())
            {
                return View(dbModel.Products.Where(x => x.productid == id).FirstOrDefault());
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Product_Category = dbModel.Product_Categories.ToList();
            return View();
        }
        // POST: image upload
        [HttpPost]
        public ActionResult Add(Product imageModel, int category)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + imageModel.productcategory + extension ;
            imageModel.productimage = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);

            var lol = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            imageModel.productupdatedate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            imageModel.productcategory = category;

            
            if (ModelState.IsValid)
            {
                try
                {
                    dbModel.Products.Add(imageModel);
                    dbModel.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }


        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                using (ADprojectEntities dbModel = new ADprojectEntities())
                {
                    dbModel.Products.Add(product);
                    dbModel.SaveChanges();
                }
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

            using (ADprojectEntities dbModel = new ADprojectEntities())
            {
                return View(dbModel.Products.Where(x => x.productid == id).FirstOrDefault());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                using (ADprojectEntities dbModel = new ADprojectEntities())
                {
                    dbModel.Entry(product).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (ADprojectEntities dbModel = new ADprojectEntities())
            {
                return View(dbModel.Products.Where(x => x.productid == id).FirstOrDefault());
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (ADprojectEntities dbModel = new ADprojectEntities())
                {
                    Product product = dbModel.Products.Where(x => x.productid == id).FirstOrDefault();
                    dbModel.Products.Remove(product);
                    dbModel.SaveChanges();
                }
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
