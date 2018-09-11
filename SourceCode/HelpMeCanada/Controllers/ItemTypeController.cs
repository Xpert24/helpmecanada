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
    public class ItemTypeController : Controller
    { 
        // GET: /ItemType/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET ItemType/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.ItemTypes.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /ItemType/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /ItemType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemType ObjItemType = db.ItemTypes.Find(id);
            if (ObjItemType == null)
            {
                return HttpNotFound();
            }
            return View(ObjItemType);
        }
        // GET: /ItemType/Create
        public ActionResult Create()
        {
             
             return View();
        }

        // POST: /ItemType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ItemType ObjItemType )
        {
            if (ModelState.IsValid)
            {


                db.ItemTypes.Add(ObjItemType);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             
             return View(ObjItemType);
        }
        // GET: /ItemType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemType ObjItemType = db.ItemTypes.Find(id);
            if (ObjItemType == null)
            {
                return HttpNotFound();
            }
            
            return View(ObjItemType);
        }

        // POST: /ItemType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ItemType ObjItemType )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjItemType).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            
            return View(ObjItemType);
        }
        // GET: /ItemType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemType ObjItemType = db.ItemTypes.Find(id);
            if (ObjItemType == null)
            {
                return HttpNotFound();
            }
            return View(ObjItemType);
        }

        // POST: /ItemType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemType ObjItemType = db.ItemTypes.Find(id);
            db.ItemTypes.Remove(ObjItemType);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /ItemType/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            ItemType ObjItemType = db.ItemTypes.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                
            }
            
            return View(ObjItemType);
        }

        // POST: /ItemType/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(ItemType ObjItemType )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjItemType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "ItemType", new { id = ObjItemType.Id });
            }
            
            return View(ObjItemType);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var ItemTypes = db.ItemTypes;
            return View(ItemTypes.ToList());
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

