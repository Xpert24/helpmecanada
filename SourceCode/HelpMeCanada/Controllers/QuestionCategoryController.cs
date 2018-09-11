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
    public class QuestionCategoryController : Controller
    { 
        // GET: /QuestionCategory/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET QuestionCategory/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.QuestionCategorys.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.ParentId),
 };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /QuestionCategory/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /QuestionCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionCategory ObjQuestionCategory = db.QuestionCategorys.Find(id);
            if (ObjQuestionCategory == null)
            {
                return HttpNotFound();
            }
            return View(ObjQuestionCategory);
        }
        // GET: /QuestionCategory/Create
        public ActionResult Create()
        {
             ViewBag.ParentId = new SelectList(db.QuestionCategorys, "Id", "Title");

             return View();
        }

        // POST: /QuestionCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(QuestionCategory ObjQuestionCategory )
        {
            if (ModelState.IsValid)
            {


                db.QuestionCategorys.Add(ObjQuestionCategory);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             ViewBag.ParentId = new SelectList(db.QuestionCategorys, "Id", "Title", ObjQuestionCategory.ParentId);

             return View(ObjQuestionCategory);
        }
        // GET: /QuestionCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionCategory ObjQuestionCategory = db.QuestionCategorys.Find(id);
            if (ObjQuestionCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.QuestionCategorys, "Id", "Title", ObjQuestionCategory.ParentId);

            return View(ObjQuestionCategory);
        }

        // POST: /QuestionCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(QuestionCategory ObjQuestionCategory )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjQuestionCategory).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            ViewBag.ParentId = new SelectList(db.QuestionCategorys, "Id", "Title", ObjQuestionCategory.ParentId);

            return View(ObjQuestionCategory);
        }
        // GET: /QuestionCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionCategory ObjQuestionCategory = db.QuestionCategorys.Find(id);
            if (ObjQuestionCategory == null)
            {
                return HttpNotFound();
            }
            return View(ObjQuestionCategory);
        }

        // POST: /QuestionCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionCategory ObjQuestionCategory = db.QuestionCategorys.Find(id);
            db.QuestionCategorys.Remove(ObjQuestionCategory);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /QuestionCategory/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            QuestionCategory ObjQuestionCategory = db.QuestionCategorys.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                ViewBag.ParentId = new SelectList(db.QuestionCategorys, "Id", "Title", ObjQuestionCategory.ParentId);

            }
            
            return View(ObjQuestionCategory);
        }

        // POST: /QuestionCategory/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(QuestionCategory ObjQuestionCategory )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjQuestionCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "QuestionCategory", new { id = ObjQuestionCategory.Id });
            }
            ViewBag.ParentId = new SelectList(db.QuestionCategorys, "Id", "Title", ObjQuestionCategory.ParentId);

            return View(ObjQuestionCategory);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var QuestionCategorys = db.QuestionCategorys;
            return View(QuestionCategorys.ToList());
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

