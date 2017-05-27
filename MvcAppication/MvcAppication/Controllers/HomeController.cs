using MvcAppication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppication.Controllers
{
    public class HomeController : Controller
    {
        CustomerDbEntities2 db = new CustomerDbEntities2();
        public static int CustomerId;

        public ActionResult Index()
        {
            List<CustomerModel> list = new List<CustomerModel>();
            var customers = db.Customers.ToList();
            customers.ToList().ForEach(item =>
            {
                CustomerModel obj = new CustomerModel();

                obj.Id = item.Id;
                obj.EmailId = item.EmaiId;
                obj.Name = item.Name;
                obj.PhoneNumber = item.PhoneNumber;

                list.Add(obj);
            });

            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {

            var Name = form["name"].ToString();
            var EmailId = form["emaiId"].ToString();
            var PhoneNumber = form["phonenumber"].ToString();
            var Name = form["radio"].ToString();
            Customer customer = new Customer();

            customer.EmaiId = EmailId;
            customer.Name = Name;
            customer.PhoneNumber = PhoneNumber;
            customer.Gender = true;

            db.Customers.Add(customer);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            CustomerId =Convert.ToInt32(id);
            var customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            CustomerModel model = new CustomerModel();

            if(customer !=null)
            {
                model.EmailId =customer != null? customer.EmaiId:null;
                model.Name = customer.Name;
                model.PhoneNumber = customer.PhoneNumber;
            }
            

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form, CustomerModel model)
        {
            var name =  form["Name"].ToString();
            var Email = form["EmailId"].ToString();
            var PhoneNumber = form["PhoneNumber"].ToString();

           var customer = db.Customers.Where(x => x.Id == CustomerId).FirstOrDefault();

            customer.EmaiId = Email;
            customer.PhoneNumber = PhoneNumber;
            customer.Name = name;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
          var cust =  db.Customers.Where(x => x.Id == id).FirstOrDefault();
            db.Customers.Remove(cust);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}