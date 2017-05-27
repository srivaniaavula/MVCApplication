using MvcAppication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppication.Controllers
{
    public class ScaffoldController : Controller
    {
        CustomerDbEntities2 db = new CustomerDbEntities2();
        // GET: Scaffold
        public ActionResult Index()
        {
           var data = db.Customers.ToList();
            return View(data);
        }

        // GET: Scaffold/Details/5
        public ActionResult Details(int id)
        {
            CustomerModel model = new CustomerModel();
            return View(model);
        }

        // GET: Scaffold/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Scaffold/Create
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

        // GET: Scaffold/Edit/5
        public ActionResult Edit(int? id)
        {
            var cust = db.Customers.Where(x => x.Id == id).FirstOrDefault();

            Customer model = new Customer();
            model.Id = cust.Id;
            model.EmailId = cust.EmailId;
            model.UserName = cust.UserName;
            return View(model);
        }

        // POST: Scaffold/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, FormCollection collection,Customer model)
        {
            try
            {
               
                var Email = collection["EmailId"].ToString();
                var Uname = collection["UserName"].ToString();
                var customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
                customer.EmailId= Email;
                 customer.UserName= Uname;
                db.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Scaffold/Delete/5
        public ActionResult Delete(int id)
        {
            var cust = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            return View(cust);
        }

        // POST: Scaffold/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {


                var cust = db.Customers.Where(x => x.Id == id).FirstOrDefault();

                var custaddresses = db.Addresses.Where(x => x.CustomerId == id).ToList();
                if(custaddresses != null)
                {
                    foreach (var item in custaddresses)
                    {
                        db.Addresses.Remove(item);
                        db.SaveChanges();
                    }
                }
                db.Customers.Remove(cust);
                db.SaveChanges();

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
