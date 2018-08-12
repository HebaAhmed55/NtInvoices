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
    public class UserController : Controller
    {

        UserDSL u = new UserDSL();
        TypeDSL t = new TypeDSL();

        // GET: Users
        public ActionResult UserIndex()
        {
            
            return View(u.GetUsers());
        }

       
        // GET: Users/Create
        public ActionResult CreateUser()
        {
            ViewBag.Type_id = new SelectList(t.GetTypes(), "Id", "type1");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Active,Name,UserName,Password,Type_id")] User user)
        {
            if (ModelState.IsValid)
            {

                u.InsertUser(user);
               u.CommitUser();
                return RedirectToAction("UserIndex");
            }

            ViewBag.Type_id = new SelectList(t.GetTypes(), "Id", "type1", user.Type_id);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult EditUser(int id)
        {
            User user = u.GetUserByID(id); ;
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type_id = new SelectList(t.GetTypes(), "Id", "type1", user.Type_id);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser([Bind(Include = "UserId,UserNo,Active,Name,UserName,Password,Type_id")] User user)
        {
            if (ModelState.IsValid)
            {
                u.UpdateUser(user);
                u.CommitUser();
                return RedirectToAction("UserIndex");
            }
            ViewBag.Type_id = new SelectList(t.GetTypes(), "Id", "type1", user.Type_id);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult DeleteUser(int id)
        {
            User user = u.GetUserByID(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
       
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            u.DeleteUser(id);
            u.CommitUser();
            return RedirectToAction("UserIndex");
        }
    }
}