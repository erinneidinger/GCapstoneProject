using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{
    public class StarRatingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: StarRating
        public ActionResult Index()
        {
            return View();
            //var userId = User.Identity.GetUserId();
            //var Musician = db.Musicians.Where(m => m.ApplicationId == userId).FirstOrDefault();
            //return View(Musician);
        }

        // GET: StarRating/Details/5
        public ActionResult Details(int id)
        {
            var rater = db.Stars.Where(r => r.RateId == id).Select(m => m).FirstOrDefault();
            return View();
        }

        // GET: StarRating/Create
        public ActionResult Create(Customer customer, Musician musician)
        {
            StarRating starrating = new StarRating();
            if (User.IsInRole("Customer"))
            {
                return View(customer);
            }
            else if (User.IsInRole("Musician"))
            {
                return View(musician);
            }
            return View();
        }

        // POST: StarRating/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer, Musician musician, StarRating starrating)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;
                var email = db.Users.Where(e => e.Id == customer.ApplicationId).FirstOrDefault();
                customer.Email = email.Email;//this should grab the email from there registration and assign it to there profile so we don't have to ask them twice
                db.Customers.Add(customer);
                db.SaveChanges();


                return View("Index"); //This works
            }
            catch
            {
                return View();
            }
        }

        // GET: StarRating/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StarRating/Edit/5
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

        // GET: StarRating/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StarRating/Delete/5
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
        public void mRate0(StarRating starrating, Musician musician)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentMusician = db.Musicians.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(musician.Rating += 0).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void mRate1(StarRating starrating, Musician musician)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentMusician = db.Musicians.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(musician.Rating += 1).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void mRate2(StarRating starrating, Musician musician)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentMusician = db.Musicians.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(musician.Rating += 2).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void mRate3(StarRating starrating, Musician musician)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentMusician = db.Musicians.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(musician.Rating += 3).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void mRate4(StarRating starrating, Musician musician)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentMusician = db.Musicians.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(musician.Rating += 4).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void mRate5(StarRating starrating, Musician musician)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentMusician = db.Musicians.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(musician.Rating += 5).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void cRate0(StarRating starrating, Customer customer)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentCust = db.Customers.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(customer.Rating += 0).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void cRate1(StarRating starrating, Customer customer)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentCust = db.Customers.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(customer.Rating += 1).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void cRate2(StarRating starrating, Customer customer)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentCust = db.Customers.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(customer.Rating += 2).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void cRate3(StarRating starrating, Customer customer)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentCust = db.Customers.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(customer.Rating += 3).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void cRate4(StarRating starrating, Customer customer)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentCust = db.Customers.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(customer.Rating += 4).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void cRate5(StarRating starrating, Customer customer)
        {
            string currentUserId = User.Identity.GetUserId();
            var currentCust = db.Customers.Where(c => c.ApplicationId == currentUserId).SingleOrDefault();
            db.Entry(customer.Rating += 5).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
