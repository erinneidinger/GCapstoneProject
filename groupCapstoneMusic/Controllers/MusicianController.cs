using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
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
            var Musician = db.Musicians;
            return View(Musician);
        }

        public void GetLngAndLat(Customer customer)
        {


        }
        // GET: Musician/Details/5
        public ActionResult Details(int id)
        {
            Musician musician = db.Musicians.Where(m => m.ID == id).Select(m => m).FirstOrDefault();

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
            var musician = db.Musicians.Where(m => m.ID == id).Select(m => m).FirstOrDefault();
            return View(musician);
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
                newMusician.Rating = musician.Rating;
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
        public ActionResult List(string musicianRating, string searchString)
        {
            //bind the customer list in the dropdown list
            var MusicianList = new List<string>();
            var MusicianQuery = from d in db.Musicians
                                orderby d.Rating
                                select d.Rating;
            MusicianList.AddRange(MusicianQuery.Distinct());
            ViewBag.customerRating = new SelectList(MusicianList);

            //string searchString = id;
            var musics = from m in db.Musicians
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                musics = musics.Where(m => m.FirstName.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(musicianRating))
            {
                musics = musics.Where(m => m.Rating == musicianRating);
            }
            return PartialView("_List", musics.ToList());
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult PostRating(int rating, int mid)
        {
            //save data into the database
            StarRating rt = new StarRating();
            string ip = Request.ServerVariables["REMOTE_ADDR"];
            rt.Rate = rating;
            rt.IpAddress = ip;
            rt.MusicId = mid;

            //save into the database
            db.Stars.Add(rt);
            db.SaveChangesAsync();

            return Json("You rated this " + rating.ToString() + " star(s)");
        }

        //public async System.Threading.Tasks.Task<ActionResult> VenueLocationAsync(int id)
        //{
        //    Concert concert = db.Concerts.Find(id);


        //    string url = "https://maps.googleapis.com/maps/api/geocode/json?address=++,++," + "&key=" + "AIzaSyBODztrEdGOpQ8GjPFCTYgWpPz_VHxXBBg";
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.VenueLocationAsync(url);
        //    string jsonResult = await response.Content.ReadAsStringAsync();
        //    if (response.IsSuccessStatusCode)
        //    {

        //    }
        //}
    }
}        
