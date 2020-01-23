using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user  = db.Users.Where(c => c.Id == userId).FirstOrDefault();
            var customer = db.Customers.Where(c => c.ApplicationId == userId).FirstOrDefault();
            return View(customer);
        }

        public ActionResult CreateConcert()
        {
            var userID = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationId == userID).FirstOrDefault();
            return RedirectToAction("Create", "Concert", customer);
        }

        public ActionResult Details(int id) //view musicians information
        {
            Customer customerDetails = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;
                var foundCustomer = db.Users.Where(e => e.Id == customer.ApplicationId).FirstOrDefault();
                customer.Email = foundCustomer.Email;//this should grab the email from there registration and assign it to there profile so we don't have to ask them twice
                db.Customers.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index"); //This works
            }
            catch
            {
                return RedirectToAction("Index"); //This works
            }
        }
        // GET: Customer/Edit/5
        [Authorize(Roles = "Customer")]
        public ActionResult Edit(int id) //Edit Profile
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Customer/Delete/5
        [Authorize(Roles = "Customer")]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = db.Musicians.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Delete/5
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                var foundCustomer = db.Customers.Find(id);
                db.Customers.Remove(foundCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public PartialViewResult Customer()
        //{
        //    return PartialView("_CustRating");
        //}
    }
}
