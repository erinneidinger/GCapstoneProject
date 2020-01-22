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
    [Authorize]
    public class MusicianController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Musician
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var foundMusician = db.Musicians.Where(m => m.ApplicationId == userId).FirstOrDefault();
            ViewBag.URL = foundMusician.iFrameUrl + foundMusician.youtubeSearch;
            return View(foundMusician);
        }

        // GET: Musician/Details/5
        public ActionResult Details(int id) //not viewing there own details, view customer or make another so they can see both
        {
            var musicianDetails = db.Musicians.Where(a => a.ID == id).FirstOrDefault();
            ViewBag.URL = musicianDetails.iFrameUrl + musicianDetails.youtubeSearch;
            return View(musicianDetails);//this works A.N
        }

        // GET: Musician/Create
        public ActionResult Create()
        {
            Musician musician = new Musician();
            return View(musician); //this works A.N
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
                return RedirectToAction("GetLatNLngAsync", musician); //this works A.N
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult ConcertSearch()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var musician = db.Musicians.Where(m => m.ApplicationId == userId).FirstOrDefault();
        //    var foundConcerts = db.Concerts.Where(m => m.Genre == musician.Genre && m.State == musician.State).ToList();---------- //Working on this come back to it.
        //    return View(foundConcerts);
        //}

        public ActionResult FilteredSearch(int id)
        {
            var userID = User.Identity.GetUserId();
            Musician filteredMusician = new Musician();
            filteredMusician.ListOfGenres = new SelectList(new List<string> { "Folk", "Country", "Reggae", "Rap", "Classical", "Pop", "Jazz", "Blues", "Electronic", "Rock", "Metal", "Instrumental", "Gospel", "Bluegrass", "Ska", "Indie Rock", "Accapella", "R&B", "Symphony", "Cover Songs", "Sing-Along", "Polka" });
            var foundConcert = db.Concerts.Where(u => u.ApplicationId == userID).FirstOrDefault();
            filteredMusician.musicians = db.Musicians.Where(u => u.City == foundConcert.City && u.State == foundConcert.State).ToList();
            
            return View(filteredMusician); //Change it to ratings or something after
        }

        [HttpPost]
        public ActionResult FilteredSearch(Musician filteredMusician)
        {
            Musician filteredmusician = new Musician();
            filteredmusician.ListOfGenres = new SelectList(new List<string> { "Folk", "Country", "Reggae", "Rap", "Classical", "Pop", "Jazz", "Blues", "Electronic", "Rock", "Metal", "Instrumental", "Gospel", "Bluegrass", "Ska", "Indie Rock", "Accapella", "R&B", "Symphony", "Cover Songs", "Sing-Along", "Polka" });
            string selectGenre = filteredMusician.SelectedGenre;
            var Id = User.Identity.GetUserId();
            var foundConcert = db.Concerts.Where(a => a.ApplicationId == Id).FirstOrDefault();
            filteredmusician.musicians = db.Musicians.Where(a => a.SelectedGenre == foundConcert.Genre && a.State == foundConcert.State && a.City == foundConcert.City).ToList();
            return View(filteredmusician);
        }

        public async System.Threading.Tasks.Task<ActionResult> GetLatNLngAsync(Musician musician)//when musician edits we will have to send them back here
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
                return RedirectToAction("GetYouTubeAddress", e); //this works A.N

            }
            return RedirectToAction("GetYouTubeAddress", e);
        }

        public async System.Threading.Tasks.Task<ActionResult> GetYouTubeAddress(Musician musician)//when musician edits we will have to send them back here
        {
            var e = musician;
            string url = PrivateKeys.youtubeURL1 + e.youtubeVideoName + PrivateKeys.youtubeURL2 + PrivateKeys.googleKey;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                YoutubeJSON youtube = JsonConvert.DeserializeObject<YoutubeJSON>(jsonResult);
                e.youtubeSearch = youtube.items[0].id.videoId;
                db.Musicians.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index");//this works A.N
            }
            return RedirectToAction("Index");
        }

        // GET: Musician/Edit/5
        public ActionResult Edit() // This works
        {
            var userId = User.Identity.GetUserId();
            var musician = db.Musicians.Where(m => m.ApplicationId == userId).FirstOrDefault();
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
                newMusician.SelectedGenre = musician.SelectedGenre;
                newMusician.Bio = musician.Bio;
                newMusician.Zip = musician.Zip;
                newMusician.City = musician.City;
                newMusician.Email = musician.Email;
                newMusician.SetRate = musician.SetRate;
                newMusician.FirstName = musician.FirstName;
                newMusician.LastName = musician.LastName;
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
            var foundMusician = db.Musicians.Find(id);
            return View(foundMusician);
        }

        // POST: Musician/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Musician musician) //Delete Profile
        {
            try
            {
                // TODO: Add delete logic here
                var foundMusician = db.Musicians.Find(id);
                db.Musicians.Remove(foundMusician);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public PartialViewResult Musician()
        //{
        //    return PartialView("_MusiRating");
        //}
    }
}        
