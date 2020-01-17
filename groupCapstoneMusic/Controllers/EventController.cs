using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{
<<<<<<< HEAD
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
=======
    public class EventController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Event
        public ActionResult Index()
        {
            var Id = User.Identity.GetUserId();
            var foundCustomer = db.Customers.Where(a => a.ApplicationId == Id).FirstOrDefault();
            var oneCustomer = db.Customers.Where(a => a.CustomerId == foundCustomer.CustomerId).ToList();
            return View(oneCustomer);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var customerDetails = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
            return View();
        }
>>>>>>> 378d1b28283ac22d8f6960e1deae40f95dbeb83f

        // GET: Event/Create
        public ActionResult Create()
        {
            Event event = new Event();
            return View();
        }

<<<<<<< HEAD
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
=======
        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
>>>>>>> 378d1b28283ac22d8f6960e1deae40f95dbeb83f

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
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

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

<<<<<<< HEAD
//        return RedirectToAction("Index");
//    }
//    catch
//    {
//        return View();
//    }
//}
//    }
=======
        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
>>>>>>> 378d1b28283ac22d8f6960e1deae40f95dbeb83f
}
