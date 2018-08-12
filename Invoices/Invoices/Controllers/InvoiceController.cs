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
    public class InvoiceController : Controller
    {
        InvoiceDSL i = new InvoiceDSL();
        CustomerDSL c = new CustomerDSL();
        CommentDSL com = new CommentDSL();
        // GET: Invoice

        public ActionResult InvoiceIndex()
        {
           
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
        public ActionResult EditInvoice([Bind(Include = "InvoiceId,InvoiceNo,IssueDate,Amount,CollectDate,ActCollectDate,Suspended,Collected,Cus_id")] Invoice invoice)
        {
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
    }
}