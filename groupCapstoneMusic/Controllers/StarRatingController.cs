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

        public ActionResult mRate(int rating, string id)
        {
            musician = db.Musicians.Where(c => c.ApplicationId == id).SingleOrDefault();
            musician.MusicianRating = rating;
            db.Entry(musician).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        
        public ActionResult cRate(int rating, string id)
        {
           
            customer = db.Customers.Where(c => c.ApplicationId == id).SingleOrDefault();
            customer.CustomerRating = rating;
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Musician");
        }
    }
}
