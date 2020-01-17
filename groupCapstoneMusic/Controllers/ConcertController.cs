using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{
    public class ConcertController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var Id = User.Identity.GetUserId();
            var foundEvent = db.Concerts.Where(a => a.ApplicationId == Id).FirstOrDefault();
            var oneEvent = db.Concerts.Where(a => a.Id == foundEvent.Id).ToList();
            return View();
        }

        public ActionResult Details(int id)
        {
            var eventDetails = db.Concerts.Where(a => a.Id == id).FirstOrDefault();
            return View();
        }

        public ActionResult Create()
        {
            Concert concert = new Concert();
            return View(concert);
        }

        [HttpPost]
        public ActionResult Create(Concert concert)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                concert.ApplicationId = userId;
                db.Concerts.Add(concert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var foundConcert = db.Concerts.Where(a => a.Id == id).FirstOrDefault();
            return View(foundConcert);
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
}
