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
    public class ItemCategoryController : Controller
    { 
        // GET: /ItemCategory/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET ItemCategory/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.ItemCategorys.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.ParentId),
 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /ItemCategory/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /ItemCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory ObjItemCategory = db.ItemCategorys.Find(id);
            if (ObjItemCategory == null)
            {
                return HttpNotFound();
            }
            return View(ObjItemCategory);
        }
        // GET: /ItemCategory/Create
        public ActionResult Create()
        {
             ViewBag.ParentId = new SelectList(db.ItemCategorys, "Id", "Title");

             return View();
        }

        // POST: /ItemCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ItemCategory ObjItemCategory )
        {
            if (ModelState.IsValid)
            {


                db.ItemCategorys.Add(ObjItemCategory);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             ViewBag.ParentId = new SelectList(db.ItemCategorys, "Id", "Title", ObjItemCategory.ParentId);

             return View(ObjItemCategory);
        }
        // GET: /ItemCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory ObjItemCategory = db.ItemCategorys.Find(id);
            if (ObjItemCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.ItemCategorys, "Id", "Title", ObjItemCategory.ParentId);

            return View(ObjItemCategory);
        }

        // POST: /ItemCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ItemCategory ObjItemCategory )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjItemCategory).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            ViewBag.ParentId = new SelectList(db.ItemCategorys, "Id", "Title", ObjItemCategory.ParentId);

            return View(ObjItemCategory);
        }
        // GET: /ItemCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory ObjItemCategory = db.ItemCategorys.Find(id);
            if (ObjItemCategory == null)
            {
                return HttpNotFound();
            }
            return View(ObjItemCategory);
        }

        // POST: /ItemCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemCategory ObjItemCategory = db.ItemCategorys.Find(id);
            db.ItemCategorys.Remove(ObjItemCategory);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /ItemCategory/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            ItemCategory ObjItemCategory = db.ItemCategorys.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                ViewBag.ParentId = new SelectList(db.ItemCategorys, "Id", "Title", ObjItemCategory.ParentId);

            }
            
            return View(ObjItemCategory);
        }

        // POST: /ItemCategory/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(ItemCategory ObjItemCategory )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjItemCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "ItemCategory", new { id = ObjItemCategory.Id });
            }
            ViewBag.ParentId = new SelectList(db.ItemCategorys, "Id", "Title", ObjItemCategory.ParentId);

            return View(ObjItemCategory);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var ItemCategorys = db.ItemCategorys;
            return View(ItemCategorys.ToList());
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

