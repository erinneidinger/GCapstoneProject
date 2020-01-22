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
        Musician musician;
        Customer customer;
        // GET: StarRating
        public ActionResult Index()
        {
            StarRating sRating = new StarRating();
            //sRating.customers = db.Customers.ToList();
            //sRating.musicians = db.Musicians.ToList();
            if (User.IsInRole("Customer"))
            {
                return PartialView("_MusiRating");
            }
            else if (User.IsInRole("Musician"))
            {
                return PartialView("_CustRating");
            }
            return View();
        }

        // GET: StarRating/Details/5
        public ActionResult Details(int id)
        {
            var rater = db.Stars.Where(r => r.RateId == id).Select(m => m).FirstOrDefault();
            return View();
        }

        // GET: StarRating/Create
        public ActionResult Create()
        {
            StarRating sRating = new StarRating();
            if (User.IsInRole("Customer"))
            {
                return PartialView("_MusiRating");
            }
            else if (User.IsInRole("Musician"))
            {
                return PartialView("_CustRating");
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
                if (User.IsInRole("Customer"))
                {
                    var custId = customer.ApplicationId;
                    starrating.ApplicationId = customer.ApplicationId;
                    //db.Customers.Add();
                    //db.Stars.Add(starrating);
                    db.SaveChanges();
                    return PartialView("_MusiRating");
                }
                else if (User.IsInRole("Musician"))
                {
                    var musiId = musician.ApplicationId;
                    starrating.ApplicationId = musician.ApplicationId;
                    //db.Musicians.Add(musician.Rating);
                    //db.Stars.Add(starrating.Rating);
                    return PartialView("_CustRating");
                }
                return View(); //This works
            }
            catch
            {
                return View();
            }
        }

        // GET: StarRating/Edit/5
        public ActionResult Edit()
        {
            var rateId = User.Identity.GetUserId();

            if (User.IsInRole("Customer"))
            {
                var musician = db.Musicians.Where(m => m.ApplicationId == rateId).FirstOrDefault();
                return View(musician);
                //return PartialView("_MusiRating");
            }
            else if (User.IsInRole("Musician"))
            {
                var custy = db.Customers.Where(m => m.ApplicationId == rateId).FirstOrDefault();
                return View(custy);
                //return PartialView("_CustRating");
            }
            return View();
        }

        // POST: StarRating/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer, Musician musician, StarRating starrating)
        {
            try
            {
                var rateId = User.Identity.GetUserId();

                if (User.IsInRole("Customer"))
                {
                    //var updatedRate = db.Musicians.Where(m => m.ApplicationId == rateId).FirstOrDefault();
                    //updatedRate.Rating = musician.Rating;
                    //db.SaveChanges();
                    //updatedRate.Rating = starrating.Rating;
                    //db.SaveChanges();                  
                }
                else if (User.IsInRole("Musician"))
                {
                    //var updatedRate = db.Customers.Where(m => m.ApplicationId == rateId).FirstOrDefault();
                    //updatedRate.Rating = customer.Rating;
                    //db.SaveChanges();
                    //updatedRate.Rating = starrating.Rating;
                    //db.SaveChanges();
                }

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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public void mRate(int rating, Musician musician)
        {
            var userId = User.Identity.GetUserId();
            musician = db.Musicians.Where(c => c.ApplicationId == userId).SingleOrDefault();
            musician.MusicianRating = rating;
            db.Entry(musician).State = EntityState.Modified;
            db.SaveChanges();
        }
        
        public void cRate(int rating, Customer customer)
        {
            var userId = User.Identity.GetUserId();
            customer = db.Customers.Where(c => c.ApplicationId == userId).SingleOrDefault();
            customer.CustomerRating = rating;
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
