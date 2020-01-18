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
            var foundConcert = db.Concerts.Where(a => a.ApplicationId == Id).FirstOrDefault();
            var oneConcert = db.Concerts.Where(a => a.Id == foundConcert.Id).ToList();
            return View(oneConcert);
        }
        public void GetLngAndLat(Customer customer)
        {


        }

        public ActionResult Details(int id)
        {
            var concertDetails = db.Concerts.Where(a => a.Id == id).FirstOrDefault();
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
                var userId = User.Identity.GetUserId();
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
        public ActionResult Edit(int id, Concert concert)
        {
            try
            {
                // TODO: Add update logic here
                var editedConcert = db.Concerts.Where(a => a.Id == id).FirstOrDefault();
                editedConcert.Venue = concert.Venue;
                editedConcert.Audience = concert.Audience;
                editedConcert.Genre = concert.Genre;
                editedConcert.StreetAddress = concert.StreetAddress;
                editedConcert.City = concert.City;
                editedConcert.State = concert.State;
                editedConcert.ConcertDate = concert.ConcertDate;
                editedConcert.ConcertTime = concert.ConcertTime;
                db.SaveChanges();
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
            var foundConcert = db.Concerts.Find(id);

            return View(foundConcert);
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Concert concert)
        {
            try
            {
                // TODO: Add delete logic here
                var foundConcert = db.Concerts.Find(id);
                db.Concerts.Remove(foundConcert);
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
