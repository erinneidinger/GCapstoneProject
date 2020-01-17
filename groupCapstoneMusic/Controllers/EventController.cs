using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{
//    public class EventController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();
//        // GET: Event
//        public ActionResult Index()
//        {
//            var Id = User.Identity.GetUserId();
//            var foundEvent = db.Events.Where(a => a.ApplicationId == Id).FirstOrDefault();
//            var oneEvent = db.Events.Where(a => a.Id == foundEvent.Id).ToList();
//            return View();
//        }

//        // GET: Event/Details/5
//        public ActionResult Details(int id)
//        {
//            var eventDetails = db.Events.Where(a => a.Id == id).FirstOrDefault();
//            return View(eventDetails);
//        }

//        // GET: Event/Create
//        public ActionResult Create()
//        {
//            Event event = new Event();
//            return View(event);
//        }

//        // POST: Event/Create
//        [HttpPost]
//        public ActionResult Create(Event event)
//        {
//            try
//            {
//                // TODO: Add insert logic here
//                string userId = User.Identity.GetUserId();
//                event.ApplicationId = userId;
//                db.Events.Add(event);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//    }
//            catch
//            {
//                return View(); 
//}
//        }

//        // GET: Event/Edit/5
//        public ActionResult Edit(int id)
//{
//    var foundEvent = db.Events.Where(a => a.EventId == id).FirstOrDefault();
//    return View(foundEvent);
//}

//// POST: Event/Edit/5
//[HttpPost]
//public ActionResult Edit(int id, FormCollection collection)
//{
//    try
//    {
//        // TODO: Add update logic here

//        return RedirectToAction("Index");
//    }
//    catch
//    {
//        return View();
//    }
//}

//// GET: Event/Delete/5
//public ActionResult Delete(int id)
//{
//    return View();
//}

//// POST: Event/Delete/5
//[HttpPost]
//public ActionResult Delete(int id, FormCollection collection)
//{
//    try
//    {
//        // TODO: Add delete logic here

//        return RedirectToAction("Index");
//    }
//    catch
//    {
//        return View();
//    }
//}
//    }
}
