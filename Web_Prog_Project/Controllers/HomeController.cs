using Web_Prog_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Prog_Project.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Indexuser()
        {
            return View();
        }


        public ActionResult Indexadmin()
        {
            return View();
        }

        Model1 db = new Model1();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin a)
        {
            int r = db.Admins.Where(x => x.Admin_Email == a.Admin_Email && x.Admin_Password == a.Admin_Password).Count();

            if (r == 1)
            {
                return RedirectToAction("Indexadmin", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid credentials";
                return View();
            }


        }


        public ActionResult About()
        {

            return View();
        }


        public ActionResult Cart()
        {
            using(Model1 db = new Model1()) { }

            return View(db);
        }

        public ActionResult AddtoCart(int id)
        {
            List<Product> lst;
            if (Session["Cart"] == null)
            { lst = new List<Product>(); }
            else { lst = (List<Product>)Session["Cart"]; }

            lst.Add(db.Products.Where(p => p.Product_ID == id).FirstOrDefault());
            lst[lst.Count - 1].qty = 1;
            Session["Cart"] = lst;
            return RedirectToAction("Cart");
        }
        public ActionResult Minus(int RowNo)
        {
            List<Product> lst = (List<Product>)Session["Cart"];
            lst[RowNo].qty--;
            Session["Cart"] = lst;
            return RedirectToAction("Cart");
        }
        public ActionResult Plus(int RowNo)
        {
            List<Product> lst = (List<Product>)Session["Cart"];
            lst[RowNo].qty++;
            Session["Cart"] = lst;
            return RedirectToAction("Cart");
        }
        public ActionResult Trash(int RowNo)
        {
            List<Product> lst = (List<Product>)Session["Cart"];
            lst.RemoveAt(RowNo);
            Session["Cart"] = lst;
            return RedirectToAction("Cart");
        }
        public ActionResult shop(int? id)
        {
            shopmodel s = new shopmodel();
            s.cat = db.Catagories.ToList();
            if (id == null)
                s.prod = db.Products.ToList();
            else
                s.prod = db.Products.Where(p => p.Catagory_F_ID == id).ToList();
            return View(s);
        }

        public ActionResult Feedback()
        {

            return View();
        }
         
        public ActionResult Contact()
        {


            return View();
        }




    }
}