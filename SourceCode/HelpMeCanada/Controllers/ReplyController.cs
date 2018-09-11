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
    public class ReplyController : Controller
    { 
        // GET: /Reply/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET Reply/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.Replys.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Description), 
            Convert.ToString(c.Question_QuestionId.Title), 
            Convert.ToString(c.ParentId),
Convert.ToString(c.IsHeplfull), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /Reply/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /Reply/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply ObjReply = db.Replys.Find(id);
            if (ObjReply == null)
            {
                return HttpNotFound();
            }
            return View(ObjReply);
        }
        // GET: /Reply/Create
        public ActionResult Create()
        {
             ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Title");
ViewBag.ParentId = new SelectList(db.Replys, "Id", "Description");

             return View();
        }

        // POST: /Reply/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Reply ObjReply )
        {
            if (ModelState.IsValid)
            {


                db.Replys.Add(ObjReply);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Title", ObjReply.QuestionId);
ViewBag.ParentId = new SelectList(db.Replys, "Id", "Description", ObjReply.ParentId);

             return View(ObjReply);
        }
        // GET: /Reply/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply ObjReply = db.Replys.Find(id);
            if (ObjReply == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Title", ObjReply.QuestionId);
ViewBag.ParentId = new SelectList(db.Replys, "Id", "Description", ObjReply.ParentId);

            return View(ObjReply);
        }

        // POST: /Reply/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Reply ObjReply )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjReply).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Title", ObjReply.QuestionId);
ViewBag.ParentId = new SelectList(db.Replys, "Id", "Description", ObjReply.ParentId);

            return View(ObjReply);
        }
        // GET: /Reply/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reply ObjReply = db.Replys.Find(id);
            if (ObjReply == null)
            {
                return HttpNotFound();
            }
            return View(ObjReply);
        }

        // POST: /Reply/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reply ObjReply = db.Replys.Find(id);
            db.Replys.Remove(ObjReply);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /Reply/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            Reply ObjReply = db.Replys.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Title", ObjReply.QuestionId);
ViewBag.ParentId = new SelectList(db.Replys, "Id", "Description", ObjReply.ParentId);

            }
            
            return View(ObjReply);
        }

        // POST: /Reply/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(Reply ObjReply )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjReply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "Reply", new { id = ObjReply.Id });
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Title", ObjReply.QuestionId);
ViewBag.ParentId = new SelectList(db.Replys, "Id", "Description", ObjReply.ParentId);

            return View(ObjReply);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var Replys = db.Replys;
            return View(Replys.ToList());
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

