using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var Id = User.Identity.GetUserId();
            var foundCustomer = db.Customers.Where(a => a.ApplicationId == Id).FirstOrDefault();
            var oneCustomer = db.Customers.Where(a => a.CustomerId == foundCustomer.CustomerId).ToList();
            return View(oneCustomer);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            var user = User.Identity.GetUserId();
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
                // TODO: Add insert logic here

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
            var customer = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                var updatedCustomer = db.Customers.Where(c => c.CustomerId == customer.CustomerId).FirstOrDefault();
                updatedCustomer.ApplicationId = customer.ApplicationId;
                updatedCustomer.ApplicationUser = customer.ApplicationUser;
                updatedCustomer.Bio = customer.Bio;
                updatedCustomer.City = customer.City;
                updatedCustomer.CustomerId = customer.CustomerId;
                updatedCustomer.Email = customer.Email;
                updatedCustomer.events = customer.events;
                updatedCustomer.FirstName = customer.FirstName;
                updatedCustomer.LastName = customer.LastName;
                updatedCustomer.MaxBudget = customer.MaxBudget;
                updatedCustomer.MinBudget = customer.MinBudget;
                updatedCustomer.Rating = customer.Rating;
                updatedCustomer.State = customer.State;
                updatedCustomer.StreetAddress = customer.StreetAddress;
                updatedCustomer.ZipCode = customer.ZipCode;
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
            return View();
        }

        // POST: Customer/Delete/5
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
