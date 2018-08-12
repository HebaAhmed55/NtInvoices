using Collection.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collection.DAL;


namespace Invoices.Controllers
{
    public class CommentController : Controller
    {
        CommentDSL com = new CommentDSL();
        InvoiceDSL i = new InvoiceDSL();
        UserDSL u = new UserDSL();

        // GET: Comments
        public ActionResult CommentIndex()
        {
            return View(com.GetComments());
        }

        // GET: Comments/Create
        public ActionResult CreateComment()
        {
            ViewBag.CommentId = new SelectList(i.GetInvoices(), "InvoiceId", "InvoiceId");
            ViewBag.User_id = new SelectList(u.GetUsers(), "UserId", "Name");
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,Comment1,Invoice_id,User_id")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                com.InsertComment(comment);
                com.CommitComment();
                return RedirectToAction("CommentIndex");
            }

            ViewBag.CommentId = new SelectList(i.GetInvoices(), "InvoiceId", "InvoiceId", comment.CommentId);
            ViewBag.User_id = new SelectList(u.GetUsers(), "UserId", "Name", comment.User_id);
            return View(comment);
        }

        
    }
}