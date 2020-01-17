using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Event
        public ActionResult Index()
        {
            var Id = User.Identity.GetUserId();
            var foundEvent = db.Events.Where(a => a.ApplicationId == Id).FirstOrDefault();
            var oneEvent = db.Events.Where(a => a.Id == foundEvent.Id).ToList();
            return View();
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var eventDetails = db.Events.Where(a => a.Id == id).FirstOrDefault();
            return View(eventDetails);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            Event event = new Event();
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(Event event)
        {
            try
            {
                // TODO: Add insert logic here
                string userId = User.Identity.GetUserId();
                event.ApplicationId = userId;
                db.Events.Add(event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
             }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            var foundEvent = db.Events.Where(a => a.EventId == id).FirstOrDefault();
            return View(foundEvent);
        }

// POST: Event/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, Event event)
    {
    try
    {
        // TODO: Add update logic here
        try
        {
            var foundCustomer = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
            var editedEvent = db.Events.Where(a => a.ApplicationId == foundCustomer.ApplicationId).FirstOrDefault();
            editedEvent.Genre = event.Genre;
            editedEvent.Venue = event.Venue;
            editedEvent.Audience = event.Audience;
            editedEvent.EventDate = event.EventDate;
            editedEvent.EventTime = event.EventTime;
            editedEvent.StreetAddress = event.StreetAddress;
            editedEvent.City = event.City;
            editedEvent.State = event.State;
            editedEvent.ZipCode = event.ZipCode;
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
    return View();
    }

// POST: Event/Delete/5
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
