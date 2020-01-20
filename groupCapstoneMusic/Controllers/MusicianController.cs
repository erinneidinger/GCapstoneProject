﻿using groupCapstoneMusic.Models;
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
    [Authorize]
    public class MusicianController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Musician
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var Musician = db.Musicians.Where(m => m.ApplicationId == userId).FirstOrDefault();
            return View(Musician);
        }

        // GET: Musician/Details/5
        public ActionResult Details(int id) //not viewing there own details, view customer or make another so they can see both
        {
            var musician = db.Musicians.Where(m => m.ID == id).Select(m => m).FirstOrDefault();

            return View();
        }

        // GET: Musician/Create
        public ActionResult Create()
        {
            Musician musician = new Musician();
            return View(musician); //this works
        }

        // POST: Musician/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Musician musician)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                musician.ApplicationId = userId;
                var email = db.Users.Where(e => e.Id == musician.ApplicationId).FirstOrDefault();
                musician.Email = email.Email;
                return RedirectToAction("GetLatNLngAsync", musician); //This works
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search()
        {
            var userID = User.Identity.GetUserId();
            CustomerMusiciansViewModel customerMusiciansViewModel = new CustomerMusiciansViewModel();
            customerMusiciansViewModel.ListOfGenres = new SelectList(new List<string> { "Folk", "Country", "Reggae", "Rap", "Classical", "Pop", "Jazz", "Blues", "Electronic", "Rock", "Metal", "Instrumental", "Gospel", "Bluegrass", "Ska", "Indie Rock", "Accapella", "R&B", "Symphony", "Cover Songs", "Sing-Along", "Polka" });
            var foundConcert = db.Concerts.Where(u => u.ApplicationId == userID).FirstOrDefault();
            customerMusiciansViewModel.musicians = db.Musicians.Where(u => u.City == foundConcert.City && u.State == foundConcert.State).ToList();
            
            return View(customerMusiciansViewModel); //Change it to ratings or something after
        }

        [HttpPost]
        public ActionResult Search(CustomerMusiciansViewModel customerMusiciansViewModel)
        {
            CustomerMusiciansViewModel customermusiciansViewModel = new CustomerMusiciansViewModel();
            customermusiciansViewModel.ListOfGenres = new SelectList(new List<string> { "Folk", "Country", "Reggae", "Rap", "Classical", "Pop", "Jazz", "Blues", "Electronic", "Rock", "Metal", "Instrumental", "Gospel", "Bluegrass", "Ska", "Indie Rock", "Accapella", "R&B", "Symphony", "Cover Songs", "Sing-Along", "Polka" });
            string selectGenre = customerMusiciansViewModel.selectGenre;
            var Id = User.Identity.GetUserId();
            var foundConcert = db.Concerts.Where(a => a.ApplicationId == Id).FirstOrDefault();
            customermusiciansViewModel.musicians = db.Musicians.Where(a => a.Genre == foundConcert.Genre && a.State == foundConcert.State && a.City == foundConcert.City).ToList();
            
            return View(customermusiciansViewModel);
        }

        public async System.Threading.Tasks.Task<ActionResult> GetLatNLngAsync(Musician musician)
        {
            var e = musician;
            string url = PrivateKeys.geoURLP1 + e.StreetAddress + ",+" + e.City + "+" + e.State + PrivateKeys.geoURLP2 + PrivateKeys.googleKey;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                GeoCode location = JsonConvert.DeserializeObject<GeoCode>(jsonResult);
                e.Lat = location.results[0].geometry.location.lat;
                e.Lng = location.results[0].geometry.location.lng;
                db.Musicians.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index"); //This works

            }
            return RedirectToAction("Index");
        }

        // GET: Musician/Edit/5
        public ActionResult Edit() // This works
        {
            var userId = User.Identity.GetUserId();
            var musician = db.Musicians.Where(m => m.ApplicationId == userId).FirstOrDefault();
            //var musician = db.Musicians.Where(m => m.ID == id).Select(m => m).FirstOrDefault();
            return View(musician);
        }

        // POST: Musician/Edit/5
        [HttpPost]
        public ActionResult Edit(Musician musician) //Need to make sure everything gets transferred in the edit.
        {
            try
            {
                // TODO: Add update logic here
                var newMusician = db.Musicians.Where(m => m.ID == musician.ID).Select(m => m).Single();
                newMusician.StreetAddress = musician.StreetAddress;
                newMusician.Rating = musician.Rating;
                newMusician.Genre = musician.Genre;
                newMusician.Bio = musician.Bio;
                newMusician.Zip = musician.Zip;
                newMusician.City = musician.City;
                newMusician.Email = musician.Email;
                newMusician.SetRate = musician.SetRate;
                newMusician.FirstName = musician.FirstName;
                newMusician.DatesAvailable = musician.DatesAvailable;
                newMusician.BandName = musician.BandName;
                newMusician.Lat = musician.Lat;
                newMusician.Lng = musician.Lng;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Musician/Delete/5
        public ActionResult Delete(int id) // Need to make sure a Musician can delete there profile
        {
            var musician = db.Musicians.Where(m => m.ID == id).Select(m => m).FirstOrDefault();
            return View(musician);
        }

        // POST: Musician/Delete/5
        [HttpPost]
        public ActionResult Delete(Musician musician) //Delete Profile
        {
            try
            {
                // TODO: Add delete logic here
                var newMusician = db.Musicians.Where(m => m.ID == musician.ID).Select(m => m).FirstOrDefault();
                db.Musicians.Remove(newMusician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult List(string musicianRating, string searchString)
        //{
        //    //bind the customer list in the dropdown list
        //    var MusicianList = new List<string>();
        //    var MusicianQuery = from d in db.Musicians
        //                        orderby d.Rating
        //                        select d.Rating;
        //    MusicianList.AddRange(MusicianQuery.Distinct());
        //    ViewBag.customerRating = new SelectList(MusicianList);

        //    //string searchString = id;
        //    var musics = from m in db.Musicians
        //                 select m;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        musics = musics.Where(m => m.FirstName.Contains(searchString));
        //    }
        //    if (!string.IsNullOrEmpty(musicianRating))
        //    {
        //        musics = musics.Where(m => m.Rating == musicianRating);
        //    }
        //    return PartialView("_List", musics.ToList());
        //}
        //[AcceptVerbs(HttpVerbs.Post)]
        //public JsonResult PostRating(int rating, int mid)
        //{
        //    //save data into the database
        //    StarRating rt = new StarRating();
        //    string ip = Request.ServerVariables["REMOTE_ADDR"];
        //    rt.Rate = rating;
        //    rt.IpAddress = ip;
        //    rt.MusicId = mid;

        //    //save into the database
        //    db.Stars.Add(rt);
        //    db.SaveChangesAsync();

        //    return Json("You rated this " + rating.ToString() + " star(s)");
        //}
        //public PartialViewResult Musician()
        //{
        //    return PartialView("_MusiRating");
        //}
    }
}        
