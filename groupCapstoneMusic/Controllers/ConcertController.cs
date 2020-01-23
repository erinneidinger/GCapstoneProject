using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
            var foundConcert = db.Concerts.Where(a => a.ApplicationId == Id).ToList();
            return View(foundConcert);
        }
       
        public ActionResult Details(int id, Concert concert, string customer)
        {
           
            var concertDetails = db.Concerts.Where(a => a.Id == id).FirstOrDefault();
            concert.apiMapCall = PrivateKeys.googleMap;
            db.SaveChanges();
            if (User.IsInRole("Musician"))
            {
                ViewBag.CID = customer;
            }
            return View(concertDetails);
        }
        public ActionResult MusicianConfirmation(string id)
        {
            var concerts = db.Concerts.Where(c => c.ApplicationId == id).ToList(); //Musician comes here and finds a list of concerts connected to Customer who messaged them
            ViewBag.CID = id;
            return View(concerts);
        }

        public ActionResult EditConfirm(int id)
        {
            var foundConcert = db.Concerts.Where(a => a.Id == id).FirstOrDefault(); //Musician clicks on comfirm for the venue
            return View(foundConcert);
        }

        [HttpPost]
        public ActionResult EditConfirm(int id, Concert concert)
        {
            try
            {
                // TODO: Add update logic here
                var editedConcert = db.Concerts.Where(a => a.Id == id).FirstOrDefault();
                editedConcert.ConfirmationOfMusician = concert.ConfirmationOfMusician;
                if(editedConcert.ConfirmationOfMusician == true)
                {
                    var userId = User.Identity.GetUserId();
                    var musician = db.Musicians.Where(u => u.ApplicationId == userId).FirstOrDefault(); //Confirmation is confirmed and band name is assigned to venu
                    editedConcert.Musician = musician.BandName;
                    db.SaveChanges();
                    return RedirectToAction("Index", "IMessage");
                }
                db.SaveChanges();
                return RedirectToAction("Index", "IMessage");
            }
            catch
            {
                return RedirectToAction("Index", "IMessage");
            }
        }

        public ActionResult Create(Customer customer)
        {
            Concert concert = new Concert();
            return View(concert);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Concert concert)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                concert.ApplicationId = userId;
                concert = await GetLatNLngAsync(concert);
                db.Concerts.Add(concert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public async System.Threading.Tasks.Task<Concert> GetLatNLngAsync(Concert concert)
        {
            var e = concert;
            string url = PrivateKeys.geoURLP1 + e.StreetAddress + ",+" + e.City + "+" + e.State + PrivateKeys.geoURLP2 + PrivateKeys.googleKey;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                GeoCode location = JsonConvert.DeserializeObject<GeoCode>(jsonResult);
                e.Lat = location.results[0].geometry.location.lat;
                e.Lng = location.results[0].geometry.location.lng;
                return e;
            }
           
            db.Concerts.Add(e);
            db.SaveChanges();
            return e;
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var concert = db.Concerts.Find(id);
            if (concert == null)
            {
                return HttpNotFound();
            }
            return View(concert);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Concert concert)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                var userId = User.Identity.GetUserId();
                concert.ApplicationId = userId;
                concert = await GetLatNLngAsync(concert);
                db.Entry(concert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

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
