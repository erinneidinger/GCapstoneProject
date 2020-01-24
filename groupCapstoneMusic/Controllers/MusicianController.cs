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
        public ActionResult Details(int id) //Customer uses this to view Musicians Profile
        {
            var musicianDetails = db.Musicians.Where(a => a.ID == id).FirstOrDefault();
            ViewBag.URL = musicianDetails.iFrameUrl + musicianDetails.youtubeSearch;
            ViewBag.key = false;//Means the musician is hired so you can leave a review now
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
        public async Task<ActionResult> Create(Musician musician)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                musician.ApplicationId = userId;
                musician = await GetLatNLngAsync(musician);
                musician =  await GetYouTubeAddress(musician);
                var foundMusician = db.Users.Where(e => e.Id == musician.ApplicationId).FirstOrDefault();
                musician.Email = foundMusician.Email;
                db.Musicians.Add(musician);
                db.SaveChanges();
                return RedirectToAction("Index"); //this works A.N
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ConcertSearch()//Searches for all the concerts the musician has confirmed on
        {
            var userId = User.Identity.GetUserId();
            var musician = db.Musicians.Where(m => m.ApplicationId == userId).FirstOrDefault();
            var foundConcerts = db.Concerts.Where(m => m.MusicianId == musician.ID).ToList(); //Working on this come back to it.
            return View(foundConcerts);
        }

        public ActionResult ConcertDetailsForMusician(int id)//Gets the details of that specific concert
        {
            var concert = db.Concerts.Where(c => c.Id == id).FirstOrDefault();
            return View(concert);
        }

        public ActionResult CustomerProfileForMusician(string id)//Allows the musician to view that host of the concerts profile
        {
            var customer = db.Customers.Where(c => c.ApplicationId == id).FirstOrDefault();
            return View(customer);
        }//---------------------------------------------------------------------------------------

        public ActionResult FilteredSearch()
        {
            var userID = User.Identity.GetUserId();
            FilterViewModel filterView = new FilterViewModel();
            filterView.ListOfGenres = new SelectList(new List<string> { null, "Folk", "Country", "Reggae", "Rap", "Classical", "Pop", "Jazz", "Blues", "Electronic", "Rock", "Metal", "Instrumental", "Gospel", "Bluegrass", "Ska", "Indie Rock", "Accapella", "R&B", "Symphony", "Cover Songs", "Sing-Along", "Polka", "Other" });
            filterView.ListOfBudgetRanges = new SelectList(new List<string> { null, "Free", "$20.00 or less", "$20.00 to $50.00", "$50.00 to $100.00", "$100.00 to $150.00", "$150.00 to $200.00", "$200.00 to $250.00", "$250.00 to $300.00", "$300.00 to $350.00", "$350.00 to $400.00", "$400.00 to $500.00", "$500.00+" });
            filterView.SearchByLocation = new SelectList(new List<string> { null, "Search by Location" });
            var foundConcert = db.Concerts.Where(u => u.ApplicationId == userID).FirstOrDefault();
            filterView.musicians = db.Musicians.ToList();
            ViewBag.key = true;
            return View(filterView); //Change it to ratings or something after
        }

        [HttpPost]
        public ActionResult FilteredSearch(FilterViewModel FilterView)
        {
            FilterViewModel filterView = new FilterViewModel();
            filterView.ListOfGenres = new SelectList(new List<string> { null, "Folk", "Country", "Reggae", "Rap", "Classical", "Pop", "Jazz", "Blues", "Electronic", "Rock", "Metal", "Instrumental", "Gospel", "Bluegrass", "Ska", "Indie Rock", "Accapella", "R&B", "Symphony", "Cover Songs", "Sing-Along", "Polka", "Other" });
            filterView.ListOfBudgetRanges = new SelectList(new List<string> { null, "Free", "$20.00 or less", "$20.00 to $50.00", "$50.00 to $100.00", "$100.00 to $150.00", "$150.00 to $200.00", "$200.00 to $250.00", "$250.00 to $300.00", "$300.00 to $350.00", "$350.00 to $400.00", "$400.00 to $500.00", "$500.00+" });
            filterView.SearchByLocation = new SelectList(new List<string> { null, "Search by Location" });
            string selectGenre = FilterView.SelectedGenre;
            string selectBudget = FilterView.ConcertRate;
            string selectLocation = FilterView.LocationAnswer;
            var Id = User.Identity.GetUserId();

            var foundConcert = db.Concerts.Where(a => a.ApplicationId == Id).FirstOrDefault();
            if(selectLocation == "Search by Location" && selectGenre != null || selectLocation == "Search by Location" && selectBudget != null)
            {
                if (selectGenre == null)
                {
                    filterView.musicians = db.Musicians.Where(a => a.SetRate == selectBudget && a.City == foundConcert.City && a.State == foundConcert.State).ToList();
                }
                else if(selectBudget == null)
                {
                    filterView.musicians = db.Musicians.Where(a => a.SelectedGenre == selectGenre && a.City == foundConcert.City && a.State == foundConcert.State).ToList();
                }
                else
                {
                    filterView.musicians = db.Musicians.Where(a => a.SelectedGenre == selectGenre && a.SetRate == selectBudget && a.City == foundConcert.City && a.State == foundConcert.State).ToList();
                }
            }
            else if( selectLocation == null && selectGenre != null || selectLocation == null && selectBudget != null)
            {
                if(selectGenre == null)
                {
                    filterView.musicians = db.Musicians.Where(a => a.SetRate == selectBudget).ToList();
                }
                else if (selectBudget == null){
                    filterView.musicians = db.Musicians.Where(a => a.SelectedGenre == selectGenre).ToList();
                }
                else
                {
                    filterView.musicians = db.Musicians.Where(a => a.SelectedGenre == selectGenre && a.SetRate == selectBudget).ToList();
                }
            }
            else if (selectLocation == "Search by Location" && selectGenre == null && selectBudget == null)
            {
                filterView.musicians = db.Musicians.Where(a => a.City == foundConcert.City && a.State == foundConcert.State).ToList();
            }
            else
            {
                filterView.musicians = db.Musicians.ToList();
            }          
            ViewBag.key = true;
            return View(filterView);
        }

        public async System.Threading.Tasks.Task<Musician> GetLatNLngAsync(Musician musician)//when musician edits we will have to send them back here
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
                if(e.youtubeSearch != null)
                {
                   return e; //
                }
                return e; //this works A.N

            }
            return e;
        }

        public async System.Threading.Tasks.Task<Musician> GetYouTubeAddress(Musician musician)//when musician edits we will have to send them back here
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
                return e;//this works A.N
            }
            return e;
        }

        // GET: Musician/Edit/5
        public ActionResult Edit(int id) // This works
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var musician = db.Musicians.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);           
        }

        // POST: Musician/Edit/5

        [HttpPost]
        public async Task<ActionResult> Edit(Musician musician) //Need to make sure everything gets transferred in the edit.
        {
            if (ModelState.IsValid)
            {

                var userId = User.Identity.GetUserId();
                musician.ApplicationId = userId;
                musician = await GetLatNLngAsync(musician);
                musician = await GetYouTubeAddress(musician);
                db.Entry(musician).State = EntityState.Modified;
                db.SaveChanges();                
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Musician/Delete/5
        public ActionResult Delete(int id) // Need to make sure a Musician can delete there profile
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var musician = db.Musicians.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
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
