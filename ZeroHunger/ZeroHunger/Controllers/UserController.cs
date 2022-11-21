using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
           // User u = new User();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Restaurant i)
        {
            var db = new ZeroHungerEntities();
           

            return View("Index");
        }

        // GET: User/Details/5
        public ActionResult Restaurant()
        {
            return View();
        }

        // GET: User/Create

        // POST: User/Create
        [HttpPost]
        public ActionResult Create()
        {
            return null;
        }

        // GET: User/Edit/5
        public ActionResult Admin()
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Employee()
        {
            return View();
        }

        // POST: User/Delete/5
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
//@HttpContext.Current.Session["restaurant"].ToString()
//@HttpContext.Current.Session["admin"].ToString()
//@HttpContext.Current.Session["employee"].ToString()