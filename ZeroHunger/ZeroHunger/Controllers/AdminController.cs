using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult RestaurantList()
        {
            var db = new ZeroHungerEntities();
            var restaurants = db.Restaurants.ToList();
            return View(restaurants);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            var db = new ZeroHungerEntities();
            db.Admins.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Login");

        }
    
        public ActionResult Login()
        {
            Admin admin = new Admin();
            return View(admin);
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var db = new ZeroHungerEntities();
            var logindata = (from a in db.Admins
                             where a.UserName == admin.UserName ||
                                   a.Password == admin.Password
                             select a).SingleOrDefault();
            if (logindata == null)
            {
                TempData["message"] = "Invalid User";
                return View();
            }
            else
            {
                if (logindata.UserName == admin.UserName && logindata.Password == admin.Password)
                {
                    Session["admin"] = logindata.UserName;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    TempData["message"] = "Incorrect Username or Password!";
                    return View();
                }
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("admin");
            return RedirectToAction("Login");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult CollectionRequest()
        {
            var db = new ZeroHungerEntities();
            var food = db.Foods.ToList();    
            return View(food);
        }
        public ActionResult AssignToEmployee(int id)
        {
            var db = new ZeroHungerEntities();
            var ext = (from fc in db.Foods
                       where fc.Id == id
                       select fc).SingleOrDefault();

            return View(ext);
        }
        [HttpPost]
        public ActionResult AssignToEmployee(int id, string AssignedEmployee)
        {
            var db = new ZeroHungerEntities();
            //Restaurant restaurant = new Restaurant();
            var ext = (from f in db.Foods
                       where f.Id == id
                       select f).SingleOrDefault();
            ext.AssignedEmployee = AssignedEmployee;
            db.SaveChanges();

            TempData["message"] = "Employee Assigned.";
            return RedirectToAction("CollectionRequest");
        }
    }
}


//@HttpContext.Current.Session["location"].ToString()