using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collection.DAL;
using System.Net;

namespace Invoices.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDSL c = new CustomerDSL();
        // GET: Customer
        public ActionResult CustomerIndex()
        {
            return View(c.GetCustomers());
        }
        public ActionResult CreateCustomer()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerName,Active")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                c.InsertCustomer(customer);
                c.CommitCustomer();
                return RedirectToAction("CustomerIndex");
            }

            return View(customer);
        }
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            Customer customer = c.GetCustomerByID(id);
            
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "CustomerId,CustomerNo,CustomerName,Active")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                c.UpdateCustomer(customer);
                c.CommitCustomer(); 
                return RedirectToAction("CustomerIndex");
            }
            return View();
        }

        // GET: Customers/Delete/5
        public ActionResult DeleteCustomer(int id)
        {
            
            Customer customer = c.GetCustomerByID(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
                c.DeleteCustomer(id);
                c.CommitCustomer();
                return RedirectToAction("CustomerIndex");
            
            
        }

    }
}