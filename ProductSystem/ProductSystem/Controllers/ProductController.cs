using ProductSystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProductSystem.Controllers
{
    public class ProductController : Controller
    {
       
        // GET: Product
        public ActionResult Index()
        {
            var db = new ProductSystemEntities();
            var products = db.Products.ToList();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (product == null)
            {
                TempData["msg"] = "Inserted Failed";
                return View();
            }
            else
            {
                var db = new ProductSystemEntities();
                db.Products.Add(product);
                db.SaveChanges();
                TempData["msg"] = "Inserted Successfully";
                return RedirectToAction("Index");
            }
        }

        // GET: Product/Edit
        public ActionResult Edit(int ?id)
        {
            if (id == null)
            {
                TempData["msg"] = "Invalid Request";
                return View();
            }
            else
            {
                var db = new ProductSystemEntities();
                var ext = (from pr in db.Products
                           where pr.Id == id
                           select pr).SingleOrDefault();
                return View(ext);
            }
           
        }

        // POST: Product/Edit
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if(product==null)
            {
                TempData["msg"] = "Updated Failed";
                return View();
            }
            else
            {
                var db = new ProductSystemEntities();
                var ext = (from pr in db.Products
                           where pr.Id == product.Id
                           select pr).FirstOrDefault();
                ext.Name = product.Name;
                ext.Price = product.Price;
                ext.Quantity = product.Quantity;
                db.SaveChanges();
                TempData["msg"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
        }

        // GET: Product/Delete
        public ActionResult Delete(int ? id)
        {
            if (id == null)
            {
                TempData["msg"] = "Invalid Request";
                return View();
            }
            else
            {
                var db = new ProductSystemEntities();
                var ext = (from pr in db.Products
                           where pr.Id == id
                           select pr).SingleOrDefault();
                return View(ext);
            }
        }

        // POST: Product/Delete
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            if (product == null)
            {
                TempData["msg"] = "Deleted Failed";
                return View();
            }
            else
            {
                var db = new ProductSystemEntities();
                var ext = (from pr in db.Products
                           where pr.Id == product.Id
                           select pr).FirstOrDefault();
                db.Products.Remove(ext);
                db.SaveChanges();
                TempData["msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
        }

        // POST: Product/Add To Cart
        [HttpGet]
        public ActionResult AddToCart(int ? id)
        {
            if (id == null)
            {
                TempData["msg"] = "Invalid Request";
                return View();
            }
            else
            {
                if (Session["cart"] == null)
                {
                    var db = new ProductSystemEntities();
                    var ext = (from pr in db.Products
                               where pr.Id == id
                               select pr).SingleOrDefault();

                    List<Product> products = new List<Product>();
                    products.Add(ext);
                    string json = new JavaScriptSerializer().Serialize(products);
                    Session["cart"] = json;
                    ViewData["msg"] = "Product Added into cart";
                    //ViewBag.Products = products;
                    return View(products);

                }
                else
                {
                    var db = new ProductSystemEntities();
                    var ext = (from pr in db.Products
                               where pr.Id == id
                               select pr).SingleOrDefault();

                    string json = Session["cart"].ToString();
                    var d = new JavaScriptSerializer().Deserialize<List<Product>>(json);
                    d.Add(ext);
                    string data = new JavaScriptSerializer().Serialize(d);
                    Session["cart"] = data;
                    ViewData["msg"] = "Product Added into cart";
                    return View(d);
                }
            }
          
        }
        [HttpGet]
        public ActionResult CheckOut(int ? id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowProduct()
        {
            return View();
        }

    }
}
