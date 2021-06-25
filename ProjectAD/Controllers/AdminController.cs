using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectAD.Models;

namespace ProjectAD.Controllers
{
    public class AdminController : Controller
    {
        private ADprojectEntities db = new ADprojectEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin admin)
        {
            ADprojectEntities dbModel = new ADprojectEntities();
            if (ModelState.IsValid)
            {
                var obj = dbModel.Admins.Where(a => a.adminname.Equals(admin.adminname) && a.adminpass.Equals(admin.adminpass)).FirstOrDefault();
                if (obj != null)
                {
                    Session["adminID"] = obj.adminid.ToString();
                    Session["adminName"] = obj.adminname.ToString();
                    if (obj.adminpass == obj.adminpass)
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                }
            }
            Response.Write("<script>alert('Please check your detail again');window.location = '/Home/Login';</script>");
            return View(admin);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderid,orderuserid,orderquantity,ordershipname,ordershipaddress,ordercontact,ordertracking,orderdate")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderid,orderuserid,orderquantity,ordershipname,ordershipaddress,ordercontact,ordertracking,orderdate")] Order order)
        {
            if (ModelState.IsValid)
            {
                //order.status = "Approve"
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OrderDetailsList()
        {
            return View(db.Order_Details.ToList());
        }

        public ActionResult PaymentList()
        {
            return View(db.Payments.ToList());
        }

        
        public ActionResult ApprovePayment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                payment.paymentstatus = "Approve";
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PaymentList");
            }
            return View();
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //public ActionResult ApprovePayment([Bind(Include = "paymentid,paymentuser,paymentfile,paymentdate")] Payment payment)
        //{
        //    Response.Write("<script>window.location.href='lol';</script>");
        //    if (ModelState.IsValid)
        //    {
        //        payment.paymentfile = "Approve";
        //        db.Entry(payment).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(payment);
        //}

        public ActionResult RejectPayment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                payment.paymentstatus = "Reject";
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PaymentList");
            }
            return View();
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //public ActionResult RejectPayment([Bind(Include = "paymentid,paymentuser,paymentfile,paymentdate")] Payment payment)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        payment.paymentfile = "Reject";
        //        db.Entry(payment).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("PaymentList");
        //    }
        //    return View(payment);
        //}

        //Parcel
        public ActionResult ParcelList()
        {
            return View(db.Parcels.ToList());
        }

        // GET: Parcel/Details/5
        //public ActionResult Details(int? id)
        //{
        //    using (ADprojectEntities db = new ADprojectEntities())
        //    {
        //        return View(db.Payments.Where(x => x.paymentuser == id).FirstOrDefault());
        //    }
        //}

        // GET: Parcel/CreateAddTrackNum
        public ActionResult AddTrackNum(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: Parcel/Create
        [HttpPost]
        public ActionResult AddTrackNum(int id, Parcel parcel)
        {
            using (ADprojectEntities db = new ADprojectEntities())
            {
                var obj = db.Parcels.Where(a => a.parcelpayment.Equals(parcel.parcelpayment) && a.parcelid.Equals(parcel.parcelid)).FirstOrDefault();
                parcel.parcelpayment = id;


                db.Parcels.Add(parcel);
                db.SaveChanges();
                return View("ParcelList");

            }
        }

        // GET: Parcel/Edit/5
        public ActionResult EditParcel(int id)
        {
            using (ADprojectEntities db = new ADprojectEntities())
            {
                ViewBag.id = id;
                return View(db.Parcels.Where(x => x.parcelid == id).FirstOrDefault());
            }
        }

        // POST: Parcel/Edit/5
        [HttpPost]
        public ActionResult EditParcel(int id, Parcel parcel)
        {
            using (ADprojectEntities db = new ADprojectEntities())
            {
                parcel.parcelpayment = id;

                db.Entry(parcel).State = EntityState.Modified;
                db.SaveChanges();

            }

            return RedirectToAction("ParcelList");
        }


        // GET: Parcel/Delete/5
        public ActionResult DeleteParcel(int id)
        {
            return View();
        }

        // POST: Parcel/Delete/5
        [HttpPost]
        public ActionResult DeleteParcel(int id, FormCollection collection)
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

        //Parcel End

        //Product
        public ActionResult ProductsList()
        {
            using (ADprojectEntities dbModel = new ADprojectEntities())
            {
                return View(dbModel.Products.ToList());

            }
        }

        // GET: Product/Details/5
        public ActionResult ProductsDetails(int? id)
        {
            using (ADprojectEntities dbModel = new ADprojectEntities())
            {
                return View(dbModel.Products.Where(x => x.productid == id).FirstOrDefault());
            }
        }

        // GET: Product/Create
        public ActionResult ProductsCreate()
        {
            return View();
        }

        public ActionResult ProductsAdd()
        {
            ViewBag.Product_Category = db.Product_Categories.ToList();
            return View();
        }
        // POST: image upload
        [HttpPost]
        public ActionResult ProductsAdd(Product imageModel, int category)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + imageModel.productcategory + extension;
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
                    db.Products.Add(imageModel);
                    db.SaveChanges();

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
        //Product End
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
