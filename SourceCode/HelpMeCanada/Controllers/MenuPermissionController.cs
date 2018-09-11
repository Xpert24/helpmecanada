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
    public class MenuPermissionController : Controller
    { 
        // GET: /MenuPermission/
        public ActionResult Index()
        {
            return ModelBind();
        }
        
        // GET MenuPermission/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.MenuPermissions.ToArray();
             
            var result = from c in tak select new string[] { c.Id.ToString(), Convert.ToString(c.Id), 
            Convert.ToString(c.Menu_MenuId !=null?c.Menu_MenuId.MenuText:""), 
            Convert.ToString(c.Role_RoleId.RoleName), 
            Convert.ToString(c.ApplicationUser_UserId !=null?c.ApplicationUser_UserId.Username:""), 
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /MenuPermission/ModelBindIndex
        public ActionResult ModelBindIndex()
        {
            return ModelBind();
        }
        // GET: /MenuPermission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPermission ObjMenuPermission = db.MenuPermissions.Find(id);
            if (ObjMenuPermission == null)
            {
                return HttpNotFound();
            }
            return View(ObjMenuPermission);
        }
        // GET: /MenuPermission/Create
        public ActionResult Create()
        {
             ViewBag.MenuId = new SelectList(db.Menus, "Id", "MenuText");
ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName");
ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username");

             return View();
        }

        // POST: /MenuPermission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(MenuPermission ObjMenuPermission )
        {
            if (ModelState.IsValid)
            {


                db.MenuPermissions.Add(ObjMenuPermission);
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
             ViewBag.MenuId = new SelectList(db.Menus, "Id", "MenuText", ObjMenuPermission.MenuId);
ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", ObjMenuPermission.RoleId);
ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username", ObjMenuPermission.UserId);

             return View(ObjMenuPermission);
        }
        // GET: /MenuPermission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPermission ObjMenuPermission = db.MenuPermissions.Find(id);
            if (ObjMenuPermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "MenuText", ObjMenuPermission.MenuId);
ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", ObjMenuPermission.RoleId);
ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username", ObjMenuPermission.UserId);

            return View(ObjMenuPermission);
        }

        // POST: /MenuPermission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(MenuPermission ObjMenuPermission )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjMenuPermission).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(TempData["ThisUrl"].ToString());
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "MenuText", ObjMenuPermission.MenuId);
ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", ObjMenuPermission.RoleId);
ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username", ObjMenuPermission.UserId);

            return View(ObjMenuPermission);
        }
        // GET: /MenuPermission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuPermission ObjMenuPermission = db.MenuPermissions.Find(id);
            if (ObjMenuPermission == null)
            {
                return HttpNotFound();
            }
            return View(ObjMenuPermission);
        }

        // POST: /MenuPermission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuPermission ObjMenuPermission = db.MenuPermissions.Find(id);
            db.MenuPermissions.Remove(ObjMenuPermission);
            db.SaveChanges();
            return Redirect(TempData["ThisUrl"].ToString());
        }
        // GET: /MenuPermission/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        { 
            MenuPermission ObjMenuPermission = db.MenuPermissions.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = 1;
                ViewBag.MenuId = new SelectList(db.Menus, "Id", "MenuText", ObjMenuPermission.MenuId);
ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", ObjMenuPermission.RoleId);
ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username", ObjMenuPermission.UserId);

            }
            
            return View(ObjMenuPermission);
        }

        // POST: /MenuPermission/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(MenuPermission ObjMenuPermission )
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(ObjMenuPermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultiViewIndex", "MenuPermission", new { id = ObjMenuPermission.Id });
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "MenuText", ObjMenuPermission.MenuId);
ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", ObjMenuPermission.RoleId);
ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Username", ObjMenuPermission.UserId);

            return View(ObjMenuPermission);
        }

        private SIContext db = new SIContext();
		
		private ActionResult ModelBind()
        {
            var MenuPermissions = db.MenuPermissions;
            return View(MenuPermissions.ToList());
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

