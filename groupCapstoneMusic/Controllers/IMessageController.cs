using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{
    [Authorize]
    public class IMessageController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: IMessage
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var messages = db.Messages.Where(m => m.ReceiverId == userId || m.SenderId == userId).ToList();
            return View(messages);
        }

        // GET: IMessage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IMessage/Create
        public ActionResult Create(string id)
        {
            Message message = new Message();
            var userId = User.Identity.GetUserId();
            message.SenderId = userId;
            message.ReceiverId = id;
            return View(message);
        }

        // POST: IMessage/Create
        [HttpPost]
        public ActionResult Create(Message message)
        {
            try
            {
                message.DatePosted = DateTime.Now;
                db.Messages.Add(message);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: IMessage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IMessage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: IMessage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: IMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var message = db.Messages.Find(id);
                db.Messages.Remove(message);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
