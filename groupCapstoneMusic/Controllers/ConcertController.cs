﻿using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            //var oneConcert = db.Concerts.Where(a => a.Id == foundConcert.Id).ToList();
            return View(foundConcert);
        }
       
        public ActionResult Details(int id, Concert concert)
        {
           
            var concertDetails = db.Concerts.Where(a => a.Id == id).FirstOrDefault();
            concert.apiMapCall = PrivateKeys.googleMap;
            db.SaveChanges();
            return View(concertDetails);
        }

        public ActionResult Create(Customer customer)
        {
            Concert concert = new Concert();
            return View(concert);
        }

        [HttpPost]
        public ActionResult Create(Concert concert)
        {
            try
            {
                //var userId = User.Identity.GetUserId();
                //concert.ApplicationId = userId;
                //db.Concerts.Add(concert);
                //db.SaveChanges();
                return RedirectToAction("GetLatNLngAsync", concert);
            }
            catch
            {
                return View();
            }
        }
        public async System.Threading.Tasks.Task<ActionResult> GetLatNLngAsync(Concert concert)
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
                var userId = User.Identity.GetUserId();
                e.ApplicationId = userId;
                db.Concerts.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
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
