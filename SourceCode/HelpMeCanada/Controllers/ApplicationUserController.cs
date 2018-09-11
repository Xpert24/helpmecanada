using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HelpMeCanada.Models;

namespace HelpMeCanada.Controllers
{
    public class ApplicationUserController : Controller
    { 
        // GET: /ApplicationUser/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET ApplicationUser/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.ApplicationUsers.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Username), 
            Convert.ToString(c.Password), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /ApplicationUser/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /ApplicationUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser ObjApplicationUser = db.ApplicationUsers.Find(id);
            if (ObjApplicationUser == null)
            {
                return HttpNotFound();
            }
            return View(ObjApplicationUser);
        }
        // GET: /ApplicationUser/Create
        public ActionResult Create()
        {
             
             return View();
        }

        // POST: /ApplicationUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ApplicationUser ObjApplicationUser )
        {
            if (ModelState.IsValid)
            {


                db.ApplicationUsers.Add(ObjApplicationUser);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             
             return View(ObjApplicationUser);
        }
        // GET: /ApplicationUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser ObjApplicationUser = db.ApplicationUsers.Find(id);
            if (ObjApplicationUser == null)
            {
                return HttpNotFound();
            }
            
            return View(ObjApplicationUser);
        }

        // POST: /ApplicationUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ApplicationUser ObjApplicationUser )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjApplicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            
            return View(ObjApplicationUser);
        }
        // GET: /ApplicationUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser ObjApplicationUser = db.ApplicationUsers.Find(id);
            if (ObjApplicationUser == null)
            {
                return HttpNotFound();
            }
            return View(ObjApplicationUser);
        }

        // POST: /ApplicationUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicationUser ObjApplicationUser = db.ApplicationUsers.Find(id);
            db.ApplicationUsers.Remove(ObjApplicationUser);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /ApplicationUser/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            ApplicationUser ObjApplicationUser = db.ApplicationUsers.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                
            }
            
            return View(ObjApplicationUser);
        }

        // POST: /ApplicationUser/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(ApplicationUser ObjApplicationUser )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjApplicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "ApplicationUser", new { id = ObjApplicationUser.Id });
            }
            
            return View(ObjApplicationUser);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var ApplicationUsers = db.ApplicationUsers;
            return View(ApplicationUsers.ToList());
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

