using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTraining.Models;

namespace MVCTraining.Controllers
{
    public class AddressBookController : Controller
    {
        private AddressBookEntities db = new AddressBookEntities();

        //
        // GET: /AddressBook/

        public ActionResult Index()
        {
            return View(db.Tables.ToList());
        }

        //
        // GET: /AddressBook/Details/5

        public ActionResult Details(int id = 0)
        {
            Table table = db.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        //
        // GET: /AddressBook/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AddressBook/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Table table)
        {
            if (ModelState.IsValid)
            {
                db.Tables.Add(table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table);
        }

        //
        // GET: /AddressBook/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Table table = db.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        //
        // POST: /AddressBook/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Table table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table);
        }

        //
        // GET: /AddressBook/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Table table = db.Tables.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        //
        // POST: /AddressBook/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table table = db.Tables.Find(id);
            db.Tables.Remove(table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}