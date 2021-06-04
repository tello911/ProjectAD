using ProjectAD.Models.ViewModels;
using ProjectAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;


namespace ProjectAD.Controllers
{
    public class TestController : Controller
    {
        public ADprojectEntities ADprojectEntities = new ADprojectEntities();
        public int key = 0;
        public ListTest lt = new ListTest();

        // GET: Test
        public ActionResult Index()
        {
            return View(lt.tests);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Test t = new Test();
            return View(t);
        }
        [HttpPost]
        public ActionResult Add(Test k)
        {
            var cartItem = lt.tests.SingleOrDefault(c => c.Id == k.Id);
            if(cartItem == null)
            {
                Test t = new Test(k.Id, k.Name, k.Count);
                lt.tests.Add(t);
                //Response.Write("<script>window.location.href='../Home'</script>");
            }
            else
            {
                cartItem.Count += k.Count;
            }
            //lt.tests.Add(new Test(id,name));
            return View();
        }

        public ActionResult Delete(int id)
        {
            var cartItem = lt.tests.SingleOrDefault(c => c.Id == id);
            if (cartItem == null)
            {
                Response.Write("<script>window.location.href='../../../Test/Index';alert('')</script>");
                //return RedirectToAction("Index");
            }
            else
            {
                lt.tests.Remove(cartItem);
                Response.Write("<script>window.location.href='../../../Test/Index';alert('The item have already been deleted')</script>");
            }
            //lt.tests.Add(new Test(id,name));

            return View();
        }
       

    }
}