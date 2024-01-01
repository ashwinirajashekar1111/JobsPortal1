using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseAccessLayer;
using JobsPortal.Helper;

namespace JobsPortal.Controllers
{
    public class EmployeesTablesController : Controller
    {
        private JobsPortalDbEntities db = new JobsPortalDbEntities();
        

        // GET: EmployeesTables
        public ActionResult Index()
        {
            var employeesTables = db.EmployeesTables.Include(e => e.UserTable);
            return View(employeesTables.ToList());
        }

        // GET: EmployeesTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesTable employeesTable = db.EmployeesTables.Find(id);
            if (employeesTable == null)
            {
                return HttpNotFound();
            }
            return View(employeesTable);
        }

        // GET: EmployeesTables/Create
        public ActionResult Create()
        {
            
            ViewBag.UserId = new SelectList(db.UserTables, "UserID", "UserName");
            return View();
        }

        // POST: EmployeesTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,UserId,EmployeeName,DOB,Education,WorkExperience,Skills,EmailAddress,Gender,Photo,Qualification,PermanentAddress,JobReference,Description,Resume")] EmployeesTable employeesTable)
        {
           
            Console.WriteLine("name", employeesTable.EmployeeName);
            //Console.ReadKey();
            //Console.WriteLine("resume", employeesTable.Resume);
            if (ModelState.IsValid)
            {
                db.EmployeesTables.Add(employeesTable);
                db.SaveChanges();
                Email.Emailsend(employeesTable.EmailAddress, employeesTable.EmployeeName, "test",false);

                return RedirectToAction("Index");
            }

            

            ViewBag.UserId = new SelectList(db.UserTables, "UserID", "UserName", employeesTable.UserId);
            
            
            return View(employeesTable);
        }

        // GET: EmployeesTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesTable employeesTable = db.EmployeesTables.Find(id);
            if (employeesTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserTables, "UserID", "UserName", employeesTable.UserId);
            return View(employeesTable);
        }

        // POST: EmployeesTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,UserId,EmployeeName,DOB,Education,WorkExperience,Skills,EmailAddress,Gender,Photo,Qualification,PermanentAddress,JobReference,Description,Resume")] EmployeesTable employeesTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeesTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserTables, "UserID", "UserName", employeesTable.UserId);
            return View(employeesTable);
        }

        // GET: EmployeesTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesTable employeesTable = db.EmployeesTables.Find(id);
            if (employeesTable == null)
            {
                return HttpNotFound();
            }
            return View(employeesTable);
        }

        // POST: EmployeesTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeesTable employeesTable = db.EmployeesTables.Find(id);
            db.EmployeesTables.Remove(employeesTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
