using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult ManageEmployee()
        {
            var db = new ZeroHungerEntities();
            var employees = db.Employees.ToList();
            return View(employees);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var db = new ZeroHungerEntities();
            db.Employees.Add(employee);
            db.SaveChanges();
            TempData["message"] = "Employee Added";
            return RedirectToAction("Login");
        }
        public ActionResult Edit(int id)
        {
            var db = new ZeroHungerEntities();
            var ext = (from emp in db.Employees
                       where emp.Id == id
                       select emp).SingleOrDefault();
            return View(ext);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            var db = new ZeroHungerEntities();
            var ext = (from emp in db.Employees
                       where emp.Id == employee.Id
                       select emp).SingleOrDefault();
            ext.UserName = employee.UserName;
            ext.Password = employee.Password;
            ext.PhoneNumber = employee.PhoneNumber;
            ext.Email = employee.Email;
            ext.Date = employee.Date;
            ext.Address = employee.Address;
            db.SaveChanges();
            TempData["message"] = "Employee Updated.";
            return RedirectToAction("ManageEmployee");
        }
        public ActionResult Delete(int id)
        {
            var db = new ZeroHungerEntities();
            var ext = (from emp in db.Employees
                       where emp.Id == id
                       select emp).SingleOrDefault();

            db.Employees.Remove(ext);
            db.SaveChanges();
            TempData["message"] = "Employee Removed.";
            return RedirectToAction("ManageEmployee");
        }
        public ActionResult Login()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            var db = new ZeroHungerEntities();
            var logindata = (from emp in db.Employees
                             where emp.UserName == employee.UserName ||
                                   emp.Password == employee.Password
                             select emp).SingleOrDefault();
            if (logindata == null)
            {
                TempData["message"] = "Invalid User";
                return View();
            }
            else
            {
                if (logindata.UserName == employee.UserName && logindata.Password == employee.Password)
                {
                    Session["employee"] = logindata.UserName;
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
            Session.Remove("employee");
            return RedirectToAction("Login");
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Collection()
        {
            var db = new ZeroHungerEntities();
            var loggedEmp = Session["employee"].ToString();
            var ext = (from r in db.Foods
                       where r.AssignedEmployee == loggedEmp
                       select r).ToList();

            return View(ext);
        }
        public ActionResult Delivery(int id)
        {
            var db = new ZeroHungerEntities();
            var ext = (from cr in db.Foods
                       where cr.Id == id
                       select cr).SingleOrDefault();

            ext.Status = "collected";
            db.SaveChanges();
            return RedirectToAction("Collection");
        }

    }
}