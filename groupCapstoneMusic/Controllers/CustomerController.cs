using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            var Id = User.Identity.GetUserId();
            var foundCustomer = db.Customers.Where(a => a.ApplicationId == Id).FirstOrDefault();
            var oneCustomer = db.Customers.Where(a => a.CustomerId == foundCustomer.CustomerId).ToList();
            return View(oneCustomer);
        }

        //GET: Customer/Edit/5
        public ActionResult CreateEvent(int id)
        {
            var foundCustomer = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
            return View(foundCustomer);
        }

        //POST: Customer/Edit/5
        //public ActionResult CreateEvent(int id, Event event, Customer customer)

        //try
        //{
        //var foundCustomer = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
        //var editedEvent = db.Events.Where(a => a.ApplicationId == foundCustomer.ApplicationId).FirstOrDefault();
        //editedEvent.Genre = event.Genre;
        //editedEvent.Venue = event.Venue;
        //editedEvent.Audience = event.Audience;
        //editedEvent.EventDate = event.EventDate;
        //editedEvent.EventTime = event.EventTime;
        //editedEvent.StreetAddress = event.StreetAddress;
        //editedEvent.City = event.City;
        //editedEvent.State = event.State;
        //editedEvent.ZipCode = event.ZipCode;
        //db.SaveChanges();
        //return View(index);
        //}

        //catch
        //{
        //return View();
        //}

        public void GetLngAndLat(Customer customer)
        {
            

        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customerDetails = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
            return View(customerDetails);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;
                db.Customers.Add(customer);
                db.SaveChanges();
                
                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var foundCustomer = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
            return View(foundCustomer);
            
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                var foundCustomer = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
                foundCustomer.FirstName = customer.FirstName;
                foundCustomer.LastName = customer.LastName;
                foundCustomer.Email = customer.Email;
                foundCustomer.Bio = customer.Bio;
                foundCustomer.MaxBudget = customer.MaxBudget;
                foundCustomer.MinBudget = customer.MinBudget;
                foundCustomer.StreetAddress = customer.StreetAddress;
                foundCustomer.City = customer.City;
                foundCustomer.State = customer.State;
                foundCustomer.ZipCode = customer.ZipCode;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer foundCustomer = db.Customers.Find(id);
            return View(foundCustomer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                Customer foundCustomer = db.Customers.Find(id);
                db.Customers.Remove(foundCustomer);
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
