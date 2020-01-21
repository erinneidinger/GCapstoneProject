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
        public void mRate0(StarRating starrating, Musician musician)
        {
            var musiId = musician.ApplicationId;
            starrating.ApplicationId = musician.ApplicationId;
            //db.Entry(musician.Rating = "0").State = EntityState.Modified;
            db.SaveChanges();
        }
        public void mRate1(StarRating starrating, Musician musician)
        {
            var musiId = musician.ApplicationId;
            starrating.ApplicationId = musician.ApplicationId;
            //db.Entry(musician.Rating = "1").State = EntityState.Modified;
            db.SaveChanges();
        }
        public void mRate2(StarRating starrating, Musician musician)
        {
            var musiId = musician.ApplicationId;
            starrating.ApplicationId = musician.ApplicationId;
            //db.Entry(musician.Rating = "2").State = EntityState.Modified;
            db.SaveChanges();
        }
        public void mRate3(StarRating starrating, Musician musician)
        {
            var musiId = musician.ApplicationId;
            starrating.ApplicationId = musician.ApplicationId;
            //db.Entry(musician.Rating = "3").State = EntityState.Modified;
            db.SaveChanges();
        }
        public void mRate4(StarRating starrating, Musician musician)
        {
            var musiId = musician.ApplicationId;
            starrating.ApplicationId = musician.ApplicationId;
            //db.Entry(musician.Rating = "4").State = EntityState.Modified;
            db.SaveChanges();
        }
        public void mRate5(StarRating starrating, Musician musician)
        {
            var musiId = musician.ApplicationId;
            starrating.ApplicationId = musician.ApplicationId;
            //db.Entry(musician.Rating = "5").State = EntityState.Modified;
            db.SaveChanges();
        }
        public void cRate0(StarRating starrating, Customer customer)
        {
            var custId = customer.ApplicationId;
            starrating.ApplicationId = customer.ApplicationId;
            //db.Entry(customer.Rating = "0").State = EntityState.Modified;
            db.SaveChanges();
        }
        public void cRate1(StarRating starrating, Customer customer)
        {
            var custId = customer.ApplicationId;
            starrating.ApplicationId = customer.ApplicationId;
            //db.Entry(customer.Rating = "1").State = EntityState.Modified;
            db.SaveChanges();
        }
        public void cRate2(StarRating starrating, Customer customer)
        {
            var custId = customer.ApplicationId;
            starrating.ApplicationId = customer.ApplicationId;
            //db.Entry(customer.Rating = "2").State = EntityState.Modified;
            db.SaveChanges();
        }
        public void cRate3(StarRating starrating, Customer customer)
        {
            var custId = customer.ApplicationId;
            starrating.ApplicationId = customer.ApplicationId;
            //db.Entry(customer.Rating = "3").State = EntityState.Modified;
            db.SaveChanges();
        }
        public void cRate4(StarRating starrating, Customer customer)
        {
            var custId = customer.ApplicationId;
            starrating.ApplicationId = customer.ApplicationId;
            //db.Entry(customer.Rating = "4").State = EntityState.Modified;
            db.SaveChanges();
        }
        public void cRate5(StarRating starrating, Customer customer)
        {
            var custId = customer.ApplicationId;
            starrating.ApplicationId = customer.ApplicationId;
            //db.Entry(customer.Rating = "5").State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
