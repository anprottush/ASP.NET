using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult ManageRestaurant()
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
        public ActionResult Create(Restaurant restaurant)
        {
            var db = new ZeroHungerEntities();
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
            TempData["message"] = "Restaurant Added";
            return RedirectToAction("ManageRestaurant");
            
        }
        public ActionResult Edit(int id)
        {
            var db = new ZeroHungerEntities();
            var ext = (from restaurant in db.Restaurants
                       where restaurant.Id == id
                       select restaurant).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            var db = new ZeroHungerEntities();
            var ext = (from r in db.Restaurants
                       where r.Id == restaurant.Id
                       select r).SingleOrDefault();
            ext.Name = restaurant.Name;
            ext.UserName = restaurant.UserName;
            ext.Password = restaurant.Password;
            ext.Location = restaurant.Location;
            ext.PhoneNumber = restaurant.PhoneNumber;
            db.SaveChanges();
            TempData["message"] = "Restaurant Updated";
            return RedirectToAction("ManageRestaurant");
        }
        public ActionResult Delete(int id)
        {
            var db = new ZeroHungerEntities();
            var ext = (from r in db.Restaurants
                       where r.Id == id
                       select r).SingleOrDefault();

            db.Restaurants.Remove(ext);
            db.SaveChanges();
            TempData["message"] = "Restaurant Deleted.";
            return RedirectToAction("ManageRestaurant");
        }
        public ActionResult Login()
        {
            Restaurant restaurant = new Restaurant();
            return View(restaurant);
        }

        [HttpPost]
        public ActionResult Login(Restaurant restaurant)
        {
            var db = new ZeroHungerEntities();
            var logindata = (from r in db.Restaurants
                       where r.UserName == restaurant.UserName || 
                             r.Password == restaurant.Password
                       select r).SingleOrDefault();
            if (logindata == null)
            {
                TempData["message"] = "Invalid User";
                return View();
            }
            else
            {
                if (logindata.UserName == restaurant.UserName && logindata.Password == restaurant.Password)
                {
                    Session["restaurant"] = logindata.Name;
                    Session["username"] = logindata.UserName;
                    Session["location"] = logindata.Location;
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
            //Session.Remove("username");
            Session.RemoveAll();
            Session.Clear();
            TempData["message"] = "Session Destroyed";
            return RedirectToAction("Login");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult CreateRequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRequest(Food food)
        {
            var db = new ZeroHungerEntities();

            Food f = new Food();
            f.Type = food.Type;
            f.Quantity = food.Quantity;
            f.RequestedRestaurant = Session["restaurant"].ToString();
            f.Status = "pending";
            db.Foods.Add(f);
            db.SaveChanges();
            TempData["message"] = "Collection Request Added";
            return RedirectToAction("CollectionRequest");
        }
        public ActionResult CollectionRequest()
        {
            var db = new ZeroHungerEntities();
            var login = Session["restaurant"].ToString();
            var ext = (from cr in db.Foods
                       where cr.RequestedRestaurant == login
                       select cr).ToList();

            return View(ext);
        }
        public ActionResult DeleteFood(int id)
        {
            var db = new ZeroHungerEntities();
            var ext = (from f in db.Foods
                       where f.Id == id
                       select f).SingleOrDefault();

            db.Foods.Remove(ext);
            db.SaveChanges();
            TempData["message"] = "Collection Request Removed!.";
            return RedirectToAction("CollectionRequest");
        }

    }
}