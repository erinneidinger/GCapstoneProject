using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return View();
            //var Id = User.Identity.GetUserId();
            //var foundCustomer = db.Customers.Where(a => a.ApplicationId == Id).FirstOrDefault();
            //var oneCustomer = db.Musicians.Where(a => a.City == foundCustomer.City).ToList();
            //return View(oneCustomer);
        }

        public ActionResult SearchParameters()
        {
            CustomerMusiciansViewModel customerMusiciansViewModel = new CustomerMusiciansViewModel();
            var userID = User.Identity.GetUserId();
            var customer = db.Customers.Where(u => u.ApplicationId == userID).FirstOrDefault();
            customerMusiciansViewModel.musicians = db.Musicians.Where(u => u.City == customer.City).ToList();
            return View(customerMusiciansViewModel); //Change it to ratings or something after
        }

        [HttpPost]
        public ActionResult SearchParameters(CustomerMusiciansViewModel customerMusiciansViewModel)
        {
            return View();
        }

        public ActionResult Details(int id)
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
        //public JsonResult SendRating(string r, string s, string id, string url)
        //{
        //    int autoId = 0;
        //    Int16 thisVote = 0;
        //    Int16 sectionId = 0;
        //    Int16.TryParse(s, out sectionId);
        //    Int16.TryParse(r, out thisVote);
        //    int.TryParse(id, out autoId);

        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return Json("Not authenticated!");
        //    }

        //    if (autoId.Equals(0))
        //    {
        //        return Json("Sorry, record to vote doesn't exists");
        //    }

        //    switch (s)
        //    {
        //        case "5": // user voting
        //                  // check if he has already voted
        //        var isIt = db.Votes.Where(v => v.SectionId == sectionId &&
        //            v.UserName.Equals(User.Identity.Name, StringComparison.CurrentCultureIgnoreCase) && v.VoteForId == autoId).FirstOrDefault();
        //        if (isIt != null)
        //        {
        //            // keep the voting flag to stop voting by this member
        //            HttpCookie cookie = new HttpCookie(url, "true");
        //            Response.Cookies.Add(cookie);
        //            return Json("<br />You have already rated this post, thanks !");
        //        }
        //        var customer = db.Customers.Where(sc => sc.CustomerId == autoId).FirstOrDefault();
        //        if (customer != null)
        //        {
        //            object obj = customer.Rating;

        //            string updatedVotes = string.Empty;
        //            string[] votes = null;
        //            if (obj != null && obj.ToString().Length > 0)
        //            {
        //                string currentVotes = obj.ToString(); // votes pattern will be 0,0,0,0,0
        //                votes = currentVotes.Split(',');
        //                // if proper vote data is there in the database
        //                if (votes.Length.Equals(5))
        //                {
        //                    // get the current number of vote count of the selected vote, always say -1 than the current vote in the array 
        //                    int currentNumberOfVote = int.Parse(votes[thisVote - 1]);
        //                    // increase 1 for this vote
        //                    currentNumberOfVote++;
        //                    // set the updated value into the selected votes
        //                    votes[thisVote - 1] = currentNumberOfVote.ToString();
        //                }
        //                else
        //                {
        //                    votes = new string[] { "0", "0", "0", "0", "0" };
        //                    votes[thisVote - 1] = "1";
        //                }
        //            }
        //            else
        //            {
        //                votes = new string[] { "0", "0", "0", "0", "0" };
        //                votes[thisVote - 1] = "1";
        //            }

        //            // concatenate all arrays now
        //            foreach (string ss in votes)
        //            {
        //                updatedVotes += ss + ",";
        //            }
        //            updatedVotes = updatedVotes.Substring(0, updatedVotes.Length - 1);

        //            db.Entry(customer).State = EntityState.Modified;
        //            customer.Rating = Convert.ToDouble(updatedVotes);
        //            db.SaveChangesAsync();

        //            VoteLog vl = new VoteLog()
        //            {
        //                Active = true,
        //                SectionId = Int16.Parse(s),
        //                UserName = User.Identity.Name,
        //                Rating = thisVote,
        //                VoteForId = autoId
        //            };

        //            db.Votes.Add(vl);

        //            db.SaveChangesAsync();

        //            // keep the voting flag to stop voting by this member
        //            HttpCookie cookie = new HttpCookie(url, "true");
        //            Response.Cookies.Add(cookie);
        //        }
        //        break;
        //        default:
        //        break;
        //    }
        //    return Json("<br />You rated " + r + " star(s), thanks !");
        //}
    }
}
