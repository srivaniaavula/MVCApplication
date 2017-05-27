using MvcAppication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppication.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDbEntities2 db = new CustomerDbEntities2();
        // GET: Customer
        public ActionResult Index()
        {
            var list = CustomerList();
            return View(list);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerModel model)
        {
            Customer cust = new Customer();
            cust.EmailId = model.EmailId;
            cust.UserName = model.Name;

            db.Customers.Add(cust);
            db.SaveChanges();

            Address address = new Address();

            address.FirstName = model.FirstName;
            address.LastName = model.LastName;
            address.PhoneNumber = model.PhoneNumber;
            address.CustomerId = cust.Id;

            db.Addresses.Add(address);
            db.SaveChanges();
            return View();
        }

        public ActionResult Edit(int? id)
        {
            var cust = db.Customers.Where(x => x.Id == id).FirstOrDefault();

            CustomerModel model = new CustomerModel();
            model.Id = cust.Id;
            model.EmailId = cust.EmailId;
            model.Name = cust.UserName;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel model)
        {
            var cust = db.Customers.Where(x => x.Id == model.Id).FirstOrDefault();
            cust.UserName = model.Name;
            cust.EmailId = model.EmailId;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [NonAction]
        public List<CustomerModel> CustomerList()
        {
            List<CustomerModel> custmodel = new List<CustomerModel>
            {
                new CustomerModel {Id=1,Name="Name1",EmailId="EmailId1",PhoneNumber="9959808544" },
                new CustomerModel {Id=2,Name="Name2",EmailId="EmailId2",PhoneNumber="99598085443" },
                new CustomerModel {Id=3,Name="Name3",EmailId="EmailId3",PhoneNumber="99598085444" },
                new CustomerModel {Id=4,Name="Name4",EmailId="EmailId4",PhoneNumber="99598085445" },
            };

            return custmodel;
        }

        public void method()
        {

        }

        public ActionResult Addresses(int? customerId)
        {
            var addresses = db.Addresses.Where(x => x.CustomerId == customerId).ToList();

            AddressModel list = new AddressModel();
            foreach (var item in addresses)
            {
                AddressModel.address obj = new AddressModel.address();

                obj.FirstName = item.FirstName;
                obj.LastName = item.LastName;
                obj.PhoneNumber = item.PhoneNumber;
                obj.Id = item.Id;

                list.addresses.Add(obj);
            }

            return View(list);
        }
        //[HttpPost]
        //public ActionResult Addresses(int? customerId,AddressModel model)
        //{
        //    var addresses = db.Addresses.Where(x => x.CustomerId == customerId).ToList();
            
           
        //    return View();
        //}

    }
}