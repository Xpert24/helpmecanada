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
    public class RoleController : Controller
    { 
        // GET: /Role/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET Role/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Roles.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.RoleName), 
            Convert.ToString(c.IsActive), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Role/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role ObjRole = db.Roles.Find(id);
            if (ObjRole == null)
            {
                return HttpNotFound();
            }
            return View(ObjRole);
        }
        // GET: /Role/Create
        public ActionResult Create()
        {
             
             return View();
        }

        // POST: /Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Role ObjRole )
        {
            if (ModelState.IsValid)
            {


                db.Roles.Add(ObjRole);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             
             return View(ObjRole);
        }
        // GET: /Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role ObjRole = db.Roles.Find(id);
            if (ObjRole == null)
            {
                return HttpNotFound();
            }
            
            return View(ObjRole);
        }

        // POST: /Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Role ObjRole )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjRole).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            
            return View(ObjRole);
        }
        // GET: /Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role ObjRole = db.Roles.Find(id);
            if (ObjRole == null)
            {
                return HttpNotFound();
            }
            return View(ObjRole);
        }

        // POST: /Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role ObjRole = db.Roles.Find(id);
            db.Roles.Remove(ObjRole);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /Role/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Role ObjRole = db.Roles.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                
            }
            
            return View(ObjRole);
        }

        // POST: /Role/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Role ObjRole )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "Role", new { id = ObjRole.Id });
            }
            
            return View(ObjRole);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var Roles = db.Roles;
            return View(Roles.ToList());
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

