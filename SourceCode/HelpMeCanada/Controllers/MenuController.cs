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
    public class MenuController : Controller
    { 
        // GET: /Menu/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET Menu/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Menus.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.MenuText), 
            Convert.ToString(c.MenuURL), 
            Convert.ToString(c.ParentId),
 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Menu/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /Menu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu ObjMenu = db.Menus.Find(id);
            if (ObjMenu == null)
            {
                return HttpNotFound();
            }
            return View(ObjMenu);
        }
        // GET: /Menu/Create
        public ActionResult Create()
        {
             ViewBag.ParentId = new SelectList(db.Menus, "Id", "MenuText");

             return View();
        }

        // POST: /Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Menu ObjMenu )
        {
            if (ModelState.IsValid)
            {


                db.Menus.Add(ObjMenu);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             ViewBag.ParentId = new SelectList(db.Menus, "Id", "MenuText", ObjMenu.ParentId);

             return View(ObjMenu);
        }
        // GET: /Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu ObjMenu = db.Menus.Find(id);
            if (ObjMenu == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.Menus, "Id", "MenuText", ObjMenu.ParentId);

            return View(ObjMenu);
        }

        // POST: /Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Menu ObjMenu )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjMenu).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            ViewBag.ParentId = new SelectList(db.Menus, "Id", "MenuText", ObjMenu.ParentId);

            return View(ObjMenu);
        }
        // GET: /Menu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu ObjMenu = db.Menus.Find(id);
            if (ObjMenu == null)
            {
                return HttpNotFound();
            }
            return View(ObjMenu);
        }

        // POST: /Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu ObjMenu = db.Menus.Find(id);
            db.Menus.Remove(ObjMenu);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /Menu/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Menu ObjMenu = db.Menus.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                ViewBag.ParentId = new SelectList(db.Menus, "Id", "MenuText", ObjMenu.ParentId);

            }
            
            return View(ObjMenu);
        }

        // POST: /Menu/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Menu ObjMenu )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "Menu", new { id = ObjMenu.Id });
            }
            ViewBag.ParentId = new SelectList(db.Menus, "Id", "MenuText", ObjMenu.ParentId);

            return View(ObjMenu);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var Menus = db.Menus;
            return View(Menus.ToList());
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

