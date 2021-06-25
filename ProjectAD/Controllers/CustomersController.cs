using ProjectAD.Models.ViewModels;
using ProjectAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;
using System.Data.Entity;


namespace ProjectAD.Controllers
{
    public class CustomersController : Controller
    {
        ADprojectEntities db = new ADprojectEntities();
        ListCart carts = new ListCart();
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

        //Add to Cart Part
        //--START--
        public ActionResult ShowCarts()
        {
            ViewBag.Count = carts.carts.Count;
            ViewBag.Limit = db.Products.ToList();
            return View(carts.carts);
        }

        

        [HttpGet]
        public ActionResult AddToCart()
        {
            ViewBag.CategoryList = db.Product_Categories.ToList();
            return View(db.Products.ToList());
        }

        public ActionResult Category(string category)
        {
            Session["category"] = category;
            return RedirectToAction("AddToCart");
        }

        [HttpPost]
        public ActionResult AddToCart(int k,string productname,int count)
        {
            var cartItem = carts.carts.SingleOrDefault(c => c.Id == k);
            if (cartItem == null)
            {
                Cart t = new Cart(k, productname,count);
                carts.carts.Add(t);
                //Response.Write("<script>window.location.href='../Home'</script>");
            }
            else
            {
                cartItem.Count += count;
            }
            //lt.tests.Add(new Test(id,name));
            return RedirectToAction("ShowCarts");
        }
        public ActionResult DeleteCart(int id)
        {
            var cartItem = carts.carts.SingleOrDefault(c => c.Id == id);
            if (cartItem == null)
            {
                Response.Write("<script>window.location.href='../../../Customers/AddToCart';alert('')</script>");
                //return RedirectToAction("Index");
            }
            else
            {
                carts.carts.Remove(cartItem);
                Response.Write("<script>window.location.href='../../../Customers/AddToCart';alert('The item have already been deleted')</script>");
            }
            //lt.tests.Add(new Test(id,name));

            return View();
        }
        //Add To Cart
        //--END--

        [HttpPost]
        public ActionResult Lol(int[] count)
        {
            ViewBag.count = count;
            return View();
        }
        public ActionResult AddPayment(int id)
        {
            ViewBag.Id = id;
            
            return View();
        }

        // POST: image upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPayment(Payment imageModel,int id)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.paymentfile = "~/Image/Payment/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Payment/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);

            imageModel.paymentuser = 1;
            imageModel.paymentstatus = "No Payment";
            imageModel.paymentorderdetails = id;
            if (ModelState.IsValid)
            {
                try
                {
                    var obj = db.Payments.Where(a => a.paymentorderdetails == id).FirstOrDefault();
                    if(obj == null)
                    {
                        db.Payments.Add(imageModel);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("PaymentList");
                }
                catch
                {
                    return View();
                }
            }
            return View();

        }

        public ActionResult OrderDetailsList()
        {
            return View(db.Order_Details.ToList());
        }

        public ActionResult PaymentList()
        {
            return View(db.Payments.ToList());
        }

        //public ActionResult ApprovePayment(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ApprovePayment([Bind(Include = "orderid,orderuserid,orderquantity,ordershipname,ordershipaddress,ordercontact,ordertracking,orderdate")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //order.status = "Approve"
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(order);
        //}

        //public ActionResult RejectPayment(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// POST: Admin/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult RejectPayment([Bind(Include = "orderid,orderuserid,orderquantity,ordershipname,ordershipaddress,ordercontact,ordertracking,orderdate")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //order.status = "Reject"
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(order);
        //}
    }
}
