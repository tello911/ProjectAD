using ProjectAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAD.Controllers
{
    public class HomeController : Controller
    {
        ADprojectEntities db = new ADprojectEntities();
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
            IEnumerable<User> data = db.Users.ToList();

            return View(data);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var obj = db.Users.Where(a => a.username.Equals(user.username) && a.userpass.Equals(user.userpass)).FirstOrDefault();
                if(obj != null)
                {
                    Session["userID"] = Convert.ToInt32(obj.userid);
                    Session["userName"] = obj.username.ToString();
                    
                        return RedirectToAction("Index", "Customers");
                    
                }
            }
            Response.Write("<script>alert('Please check your detail again');window.location = '/Home/Login';</script>");
            return View(user);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            User obj = new User();
            obj.username = model.username;
            //obj.userpassword = model.userpassword;
            obj.useremail = model.useremail;
            obj.usercontact = model.usercontact;
            obj.useraddress = model.useraddress;


            try
            {
                using (ADprojectEntities dbObj = new ADprojectEntities())
                {
                    dbObj.Users.Add(obj);
                    dbObj.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }

            catch
            {
                ViewBag.SuccessMessage = "Registration Successful";
                return View("Register", new User());
            }


        }
    }
}