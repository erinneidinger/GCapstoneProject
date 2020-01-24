using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{ 
    public class ReviewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Review
        public ActionResult Index(string id)//For Check Others Reviews
        {
            var reviews = db.Reviews.Where(r => r.ApplicationId == id).ToList();
            ViewBag.reviedId = id;
            if (User.IsInRole("Customer"))
            {
                    var musician = db.Musicians.Where(m => m.ApplicationId == id).FirstOrDefault();
                    ViewBag.musicianId = musician.ID;
            }
            return View(reviews);
        }

        // GET: Review/Details/5
        public ActionResult Details(string id) //For Checking Your Reviews
        {
            var reviews = db.Reviews.Where(r => r.ApplicationId == id).ToList();
            return View(reviews);
        }

        // GET: Review/Create
        public ActionResult Create(string id)
        {
            Review review = new Review();
            //ViewBag.reviewedId = id;
            return View(review);
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(string id, Review review)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.Where(u => u.Id == userId).FirstOrDefault();
                review.From = user.UserName;
                review.DatePosted = DateTime.Now;
                review.ApplicationId = id;
                db.Reviews.Add(review);
                db.SaveChanges();
                if (User.IsInRole("Customer"))
                {
                    return RedirectToAction("Index", "Customer");
                }
                if (User.IsInRole("Musician"))
                {
                    return RedirectToAction("Index", "Musician");
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Review/Edit/5
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

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Review/Delete/5
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
