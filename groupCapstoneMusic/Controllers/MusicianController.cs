using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{
    [Authorize]
    public class MusicianController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Musician
        public ActionResult Index()
        {
            var Musician = db.Musicians;
            return View(Musician);
        }

        // GET: Musician/Details/5
        public ActionResult Details(int id)
        {
            Musician musician = db.Musicians.Where(m => m.ID == id)
                .Select(m => m).FirstOrDefault();

            return View();
        }

        // GET: Musician/Create
        public ActionResult Create()
        {
            Musician musician = new Musician();
            return View(musician);
        }

        // POST: Musician/Create
        [HttpPost]
        public ActionResult Create(Musician musician)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                musician.ApplicationId = userId;
                db.Musicians.Add(musician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Musician/Edit/5
        public ActionResult Edit(int id)
        {
            Musician musician = db.Musicians.Where(m => m.ID == id)
                .Select(m => m).FirstOrDefault();

            return View();
        }

        // POST: Musician/Edit/5
        [HttpPost]
        public ActionResult Edit(Musician musician)
        {
            try
            {
                // TODO: Add update logic here
                var newMusician = db.Musicians.Where(m => m.ID == musician.ID).Select(m => m).Single();
                newMusician.StreetAddress = musician.StreetAddress;
                newMusician.rating = musician.rating;
                newMusician.Genre = musician.Genre;
                newMusician.Bio = musician.Bio;
                newMusician.Zip = musician.Zip;
                newMusician.City = musician.City;
                newMusician.Email = musician.Email;
                newMusician.SetRate = musician.SetRate;
                newMusician.FirstName = musician.FirstName;
                newMusician.DatesAvailable = musician.DatesAvailable;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Musician/Delete/5
        public ActionResult Delete(int id)
        {
            Musician musician = db.Musicians.Where(m => m.ID == id)
                .Select(m => m).FirstOrDefault();

            return View(musician);
        }

        // POST: Musician/Delete/5
        [HttpPost]
        public ActionResult Delete(Musician musician)
        {
            try
            {
                // TODO: Add delete logic here
                Musician newMusician = db.Musicians.Where(m => m.ID == musician.ID)
                    .Select(m => m).FirstOrDefault();

                db.Musicians.Remove(newMusician);
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
