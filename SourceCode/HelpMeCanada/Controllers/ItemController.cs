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
    public class ItemController : Controller
    { 
        // GET: /Item/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET Item/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Items.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.Description), 
            Convert.ToString(c.ItemCategory_ItemCategoryId.Title), 
            Convert.ToString(c.ItemType_ItemTypeId.Title), 
            Convert.ToString(c.ApplicationUser_AddedBy !=null?c.ApplicationUser_AddedBy.Username:""), 
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.ModifiedBy), 
            Convert.ToString(c.DateModied), 
            Convert.ToString(c.DealClosed), 
            Convert.ToString(c.Email), 
            Convert.ToString(c.Phone), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Item/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item ObjItem = db.Items.Find(id);
            if (ObjItem == null)
            {
                return HttpNotFound();
            }
            return View(ObjItem);
        }
        // GET: /Item/Create
        public ActionResult Create()
        {
             ViewBag.ItemCategoryId = new SelectList(db.ItemCategorys, "Id", "Title");
ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "Id", "Title");

             return View();
        }

        // POST: /Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Item ObjItem )
        {
            if (ModelState.IsValid)
            {


                db.Items.Add(ObjItem);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             ViewBag.ItemCategoryId = new SelectList(db.ItemCategorys, "Id", "Title", ObjItem.ItemCategoryId);
ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "Id", "Title", ObjItem.ItemTypeId);

             return View(ObjItem);
        }
        // GET: /Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item ObjItem = db.Items.Find(id);
            if (ObjItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategorys, "Id", "Title", ObjItem.ItemCategoryId);
ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "Id", "Title", ObjItem.ItemTypeId);

            return View(ObjItem);
        }

        // POST: /Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Item ObjItem )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjItem).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategorys, "Id", "Title", ObjItem.ItemCategoryId);
ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "Id", "Title", ObjItem.ItemTypeId);

            return View(ObjItem);
        }
        // GET: /Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item ObjItem = db.Items.Find(id);
            if (ObjItem == null)
            {
                return HttpNotFound();
            }
            return View(ObjItem);
        }

        // POST: /Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item ObjItem = db.Items.Find(id);
            db.Items.Remove(ObjItem);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /Item/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Item ObjItem = db.Items.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                ViewBag.ItemCategoryId = new SelectList(db.ItemCategorys, "Id", "Title", ObjItem.ItemCategoryId);
ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "Id", "Title", ObjItem.ItemTypeId);

            }
            
            return View(ObjItem);
        }

        // POST: /Item/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Item ObjItem )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "Item", new { id = ObjItem.Id });
            }
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategorys, "Id", "Title", ObjItem.ItemCategoryId);
ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "Id", "Title", ObjItem.ItemTypeId);

            return View(ObjItem);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var Items = db.Items;
            return View(Items.ToList());
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

