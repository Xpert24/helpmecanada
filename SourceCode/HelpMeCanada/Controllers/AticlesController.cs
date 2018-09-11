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
    public class AticlesController : Controller
    { 
        // GET: /Aticles/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET Aticles/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Aticless.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.Description), 
            Convert.ToString(c.ArticleCategory_ArticleCategoryId.Title), 
            Convert.ToString(c.AddedBy), 
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.ModifiedBy), 
            Convert.ToString(c.DateModied), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Aticles/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /Aticles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aticles ObjAticles = db.Aticless.Find(id);
            if (ObjAticles == null)
            {
                return HttpNotFound();
            }
            return View(ObjAticles);
        }
        // GET: /Aticles/Create
        public ActionResult Create()
        {
             ViewBag.ArticleCategoryId = new SelectList(db.ArticleCategorys, "Id", "Title");

             return View();
        }

        // POST: /Aticles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Aticles ObjAticles )
        {
            if (ModelState.IsValid)
            {


                db.Aticless.Add(ObjAticles);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             ViewBag.ArticleCategoryId = new SelectList(db.ArticleCategorys, "Id", "Title", ObjAticles.ArticleCategoryId);

             return View(ObjAticles);
        }
        // GET: /Aticles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aticles ObjAticles = db.Aticless.Find(id);
            if (ObjAticles == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleCategoryId = new SelectList(db.ArticleCategorys, "Id", "Title", ObjAticles.ArticleCategoryId);

            return View(ObjAticles);
        }

        // POST: /Aticles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Aticles ObjAticles )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjAticles).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            ViewBag.ArticleCategoryId = new SelectList(db.ArticleCategorys, "Id", "Title", ObjAticles.ArticleCategoryId);

            return View(ObjAticles);
        }
        // GET: /Aticles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aticles ObjAticles = db.Aticless.Find(id);
            if (ObjAticles == null)
            {
                return HttpNotFound();
            }
            return View(ObjAticles);
        }

        // POST: /Aticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aticles ObjAticles = db.Aticless.Find(id);
            db.Aticless.Remove(ObjAticles);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /Aticles/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Aticles ObjAticles = db.Aticless.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                ViewBag.ArticleCategoryId = new SelectList(db.ArticleCategorys, "Id", "Title", ObjAticles.ArticleCategoryId);

            }
            
            return View(ObjAticles);
        }

        // POST: /Aticles/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Aticles ObjAticles )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjAticles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "Aticles", new { id = ObjAticles.Id });
            }
            ViewBag.ArticleCategoryId = new SelectList(db.ArticleCategorys, "Id", "Title", ObjAticles.ArticleCategoryId);

            return View(ObjAticles);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var Aticless = db.Aticless;
            return View(Aticless.ToList());
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

