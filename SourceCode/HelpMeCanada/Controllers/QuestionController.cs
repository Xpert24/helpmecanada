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
    public class QuestionController : Controller
    { 
        // GET: /Question/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET Question/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Questions.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Title), 
            Convert.ToString(c.Desciption), 
            Convert.ToString(c.ApplicationUser_UserId.Username), 
            Convert.ToString(c.QuestionCategory_QuestionCategoryId.Title), 
            Convert.ToString(c.AddedBy), 
            Convert.ToString(c.DateAdded), 
            Convert.ToString(c.ModifiedBy), 
            Convert.ToString(c.DateModied), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Question/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /Question/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question ObjQuestion = db.Questions.Find(id);
            if (ObjQuestion == null)
            {
                return HttpNotFound();
            }
            return View(ObjQuestion);
        }
        // GET: /Question/Create
        public ActionResult Create()
        {
             ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username");
ViewBag.QuestionCategoryId = new SelectList(db.QuestionCategorys, "Id", "Title");

             return View();
        }

        // POST: /Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Question ObjQuestion )
        {
            if (ModelState.IsValid)
            {


                db.Questions.Add(ObjQuestion);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username", ObjQuestion.UserId);
ViewBag.QuestionCategoryId = new SelectList(db.QuestionCategorys, "Id", "Title", ObjQuestion.QuestionCategoryId);

             return View(ObjQuestion);
        }
        // GET: /Question/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question ObjQuestion = db.Questions.Find(id);
            if (ObjQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username", ObjQuestion.UserId);
ViewBag.QuestionCategoryId = new SelectList(db.QuestionCategorys, "Id", "Title", ObjQuestion.QuestionCategoryId);

            return View(ObjQuestion);
        }

        // POST: /Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Question ObjQuestion )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username", ObjQuestion.UserId);
ViewBag.QuestionCategoryId = new SelectList(db.QuestionCategorys, "Id", "Title", ObjQuestion.QuestionCategoryId);

            return View(ObjQuestion);
        }
        // GET: /Question/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question ObjQuestion = db.Questions.Find(id);
            if (ObjQuestion == null)
            {
                return HttpNotFound();
            }
            return View(ObjQuestion);
        }

        // POST: /Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question ObjQuestion = db.Questions.Find(id);
            db.Questions.Remove(ObjQuestion);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /Question/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Question ObjQuestion = db.Questions.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username", ObjQuestion.UserId);
ViewBag.QuestionCategoryId = new SelectList(db.QuestionCategorys, "Id", "Title", ObjQuestion.QuestionCategoryId);

            }
            
            return View(ObjQuestion);
        }

        // POST: /Question/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Question ObjQuestion )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "Question", new { id = ObjQuestion.Id });
            }
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username", ObjQuestion.UserId);
ViewBag.QuestionCategoryId = new SelectList(db.QuestionCategorys, "Id", "Title", ObjQuestion.QuestionCategoryId);

            return View(ObjQuestion);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var Questions = db.Questions;
            return View(Questions.ToList());
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

