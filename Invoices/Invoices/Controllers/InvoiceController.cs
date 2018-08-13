using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DSL;
using Collection.DAL;
using System.Net;
using Invoices.ViewModels;
using Newtonsoft.Json;

namespace Invoices.Controllers
{
    public class InvoiceController : Controller
    {
        InvoiceDSL i = new InvoiceDSL();
        CustomerDSL c = new CustomerDSL();
        CommentDSL com = new CommentDSL();
        // GET: Invoice

        public ActionResult InvoiceIndex()
        {
           
            return View(i.GetInvoices());
            var list = com.GetComments();
            ViewData["CommentList"] = list;
            return View(i.GetInvoices());
        }


        //GET: Invoices/Create
        public ActionResult CreateInvoice()
        {
            ViewBag.InvoiceId = new SelectList(com.GetComments(), "CommentId", "Comment1");
            ViewBag.Cus_id = new SelectList(c.GetCustomers(), "CustomerId", "CustomerName");
            
            return View();
        }

        // POST: Invoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IssueDate,Amount,CollectDate,ActCollectDate,Suspended,Collected,Cus_id")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                i.InsertInvoice(invoice);
                i.CommitInvoice();
                return RedirectToAction("InvoiceIndex");
            }

            ViewBag.InvoiceId = new SelectList(com.GetComments(), "CommentId", "Comment1", invoice.InvoiceId);
            ViewBag.Cus_id = new SelectList(c.GetCustomers(), "CustomerId", "CustomerName", invoice.Cus_id);
            return View(invoice);
        }


        // GET: Invoices/Edit/5
        public ActionResult EditInvoice(int id)
        {

            
            Invoice invoice = i.GetInvoiceByID(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceId = new SelectList(com.GetComments(), "CommentId", "Comment1", invoice.InvoiceId);
            ViewBag.Cus_id = new SelectList(c.GetCustomers(), "CustomerId", "CustomerName", invoice.Cus_id);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInvoice([Bind(Include = "InvoiceId,InvoiceNo,IssueDate,Amount,CollectDate,ActCollectDate,Suspended,Collected,Cus_id")] Invoice invoice , string check1,string check2)
        {
            if (check1 == "on")
            {
                invoice.Suspended = true;
            }
            else { invoice.Suspended = false; }

            if (check2 == "on")
            {
                invoice.Collected = true;
            }
            else { invoice.Collected = false; }

            if (ModelState.IsValid)
            {
                i.UpdateInvoice(invoice);
                i.CommitInvoice();
                return RedirectToAction("InvoiceIndex");
            }
            ViewBag.InvoiceId = new SelectList(com.GetComments(), "CommentId", "Comment1", invoice.InvoiceId);
            ViewBag.Cus_id = new SelectList(c.GetCustomers(), "CustomerId", "CustomerName", invoice.Cus_id);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult DeleteInvoice(int id)
        {
            
            Invoice invoice = i.GetInvoiceByID(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            i.DeleteInvoice(id);
            i.CommitInvoice();
            return RedirectToAction("InvoiceIndex");

        }

        ////////////////////////////////////////////////////////////////////////
        public string addcoment( string invoiceId, string comment)
        {
            string userid = Session["UserId"].ToString();
            Comment c = new Comment();
            c.Comment1 = comment;
            c.User_id = Convert.ToInt32(userid);
            c.Invoice_id = Convert.ToInt32(invoiceId);
            com.InsertComment(c);
            com.CommitComment();
            return "Comment Added";

        }
        
        //////////////////////////////////////////////////////////////////

        public ActionResult Search()
        {
            
            
            var invoice = i.GetInvoices();
            var customers = c.GetCustomers();
            InvoiceViewModel vm = new InvoiceViewModel { Invoices = invoice, Customers = customers };

            return View(vm);
        }
        public string SearchResult(string issueT, string issueF, string collectF, string collectT, string name)
        {
            
            DateTime D = new DateTime(2018, 6, 6);

            var invoice = i.GetInvoices();
            //var customers = c.GetCustomers();
            var sorted = new List<Invoice>();
            DateTime issuefrom = CreateDateTime(issueF);
            DateTime issueto = CreateDateTime(issueT);
            //DateTime collectfrom = CreateDateTime(collectF);
            // DateTime collectto = CreateDateTime(collectT);


            foreach (var i in invoice)
            {
                if (i.IssueDate <= issueto && i.IssueDate >= issuefrom && (i.Customer.CustomerName == name || name == "0"))
                {
                    sorted.Add(i);
                }
            }

            var a = JsonConvert.SerializeObject(sorted, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            return a;

        }



        public DateTime CreateDateTime(string a)
        {
            int year = Convert.ToInt32((a.Split('-'))[0]); // Splits the value of the string on the '/' into month , day and year
            int month = Convert.ToInt32((a.Split('-'))[1]);
            int day = Convert.ToInt32((a.Split('-'))[2]);

            DateTime A = new DateTime(year, month, day);
            return A;

        }

        

    }
}