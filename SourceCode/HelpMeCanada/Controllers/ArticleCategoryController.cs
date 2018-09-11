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
    public class ArticleCategoryController : Controller
    { 
        // GET: /ArticleCategory/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET ArticleCategory/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.ArticleCategorys.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.ParentId),
 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /ArticleCategory/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /ArticleCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleCategory ObjArticleCategory = db.ArticleCategorys.Find(id);
            if (ObjArticleCategory == null)
            {
                return HttpNotFound();
            }
            return View(ObjArticleCategory);
        }
        // GET: /ArticleCategory/Create
        public ActionResult Create()
        {
             ViewBag.ParentId = new SelectList(db.ArticleCategorys, "Id", "Title");

             return View();
        }

        // POST: /ArticleCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ArticleCategory ObjArticleCategory )
        {
            if (ModelState.IsValid)
            {


                db.ArticleCategorys.Add(ObjArticleCategory);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             ViewBag.ParentId = new SelectList(db.ArticleCategorys, "Id", "Title", ObjArticleCategory.ParentId);

             return View(ObjArticleCategory);
        }
        // GET: /ArticleCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleCategory ObjArticleCategory = db.ArticleCategorys.Find(id);
            if (ObjArticleCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.ArticleCategorys, "Id", "Title", ObjArticleCategory.ParentId);

            return View(ObjArticleCategory);
        }

        // POST: /ArticleCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ArticleCategory ObjArticleCategory )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjArticleCategory).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            ViewBag.ParentId = new SelectList(db.ArticleCategorys, "Id", "Title", ObjArticleCategory.ParentId);

            return View(ObjArticleCategory);
        }
        // GET: /ArticleCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleCategory ObjArticleCategory = db.ArticleCategorys.Find(id);
            if (ObjArticleCategory == null)
            {
                return HttpNotFound();
            }
            return View(ObjArticleCategory);
        }

        // POST: /ArticleCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleCategory ObjArticleCategory = db.ArticleCategorys.Find(id);
            db.ArticleCategorys.Remove(ObjArticleCategory);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /ArticleCategory/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            ArticleCategory ObjArticleCategory = db.ArticleCategorys.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                ViewBag.ParentId = new SelectList(db.ArticleCategorys, "Id", "Title", ObjArticleCategory.ParentId);

            }
            
            return View(ObjArticleCategory);
        }

        // POST: /ArticleCategory/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(ArticleCategory ObjArticleCategory )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjArticleCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "ArticleCategory", new { id = ObjArticleCategory.Id });
            }
            ViewBag.ParentId = new SelectList(db.ArticleCategorys, "Id", "Title", ObjArticleCategory.ParentId);

            return View(ObjArticleCategory);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var ArticleCategorys = db.ArticleCategorys;
            return View(ArticleCategorys.ToList());
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

