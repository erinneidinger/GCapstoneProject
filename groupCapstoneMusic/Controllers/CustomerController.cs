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
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
            //var Id = User.Identity.GetUserId();
            //var foundCustomer = db.Customers.Where(a => a.ApplicationId == Id).FirstOrDefault();
            //var oneCustomer = db.Musicians.Where(a => a.City == foundCustomer.City).ToList();
            //return View(oneCustomer);
            //---------------By default what should the customer see upon logging in?-----------------
            //put it here
        }

        public ActionResult CreateConcert()
        {
            var userID = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationId == userID).FirstOrDefault();
            return RedirectToAction("Create", "Concert", customer);
        }

        public ActionResult Search()
        {
            CustomerMusiciansViewModel customerMusiciansViewModel = new CustomerMusiciansViewModel();
            var userID = User.Identity.GetUserId();
            var customer = db.Customers.Where(u => u.ApplicationId == userID).FirstOrDefault();
            customerMusiciansViewModel.musicians = db.Musicians.Where(u => u.City == customer.City).ToList();
            return View(customerMusiciansViewModel); //Change it to ratings or something after
        }

        [HttpPost]
        public ActionResult Search(CustomerMusiciansViewModel customerMusiciansViewModel)
        {
            return View();
        }

        public ActionResult Details(int id) //view musicians information
        {
            return View();
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
                var userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;
                var email = db.Users.Where(e => e.Id == customer.ApplicationId).FirstOrDefault();
                customer.Email = email.Email;//this should grab the email from there registration and assign it to there profile so we don't have to ask them twice
                db.Customers.Add(customer);
                db.SaveChanges();
                // TODO: Add insert logic here

                return View("Index"); //This works
            }
            catch
            {
                return View();
            }
        }
        // GET: Customer/Edit/5
        public ActionResult Edit() //Edit Profile
        {
            var userId = User.Identity.GetUserId();
            var customer = db.Customers.Where(a => a.ApplicationId == userId).FirstOrDefault();
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
        public ActionResult List(string customerRating, string searchString)
        {
            //bind the customer list in the dropdown list
            var CustomerList = new List<string>();
            var CustomerQuery = from d in db.Customers
                              orderby d.Rating
                              select d.Rating;
            CustomerList.AddRange(CustomerQuery.Distinct());
            ViewBag.customerRating = new SelectList(CustomerList);

            //string searchString = CustomerId;
            var custys = from c in db.Customers
                         select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                custys = custys.Where(c => c.FirstName.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(customerRating))
            {
                custys = custys.Where(c => c.Rating == customerRating);
            }
            return PartialView("_List", custys.ToList());
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult PostRating(int rating, int mid)
        {
            //save data into the database
            StarRating rt = new StarRating();
            string ip = Request.ServerVariables["REMOTE_ADDR"];
            rt.Rate = rating;
            rt.IpAddress = ip;
            rt.CustId = mid;

            //save into the database
            db.Stars.Add(rt);
            db.SaveChangesAsync();

            return Json("You rated this " + rating.ToString() + " star(s)");
        }
    }
}
