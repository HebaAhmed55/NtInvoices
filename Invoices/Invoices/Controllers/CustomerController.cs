using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collection.DAL;

namespace Invoices.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDSL c = new CustomerDSL();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}