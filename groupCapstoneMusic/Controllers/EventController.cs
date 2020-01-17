using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{

    //public class EventController : Controller
    //{
    //    private ApplicationDbContext db = new ApplicationDbContext();
    //    // GET: Event
    //    public ActionResult Index()
    //    {
    //        var Id = User.Identity.GetUserId();
    //        var foundCustomer = db.Customers.Where(a => a.ApplicationId == Id).FirstOrDefault();
    //        var oneCustomer = db.Customers.Where(a => a.CustomerId == foundCustomer.CustomerId).ToList();
    //        return View(oneCustomer);
    //    }

    //    // GET: Event/Details/5
    //    public ActionResult Details(int id)
    //    {
    //        var customerDetails = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
    //        return View();
    //    }


    //    // GET: Event/Create
    //    public ActionResult Create()
    //    {
    //        Event event = new Event();
    //        return View();
    //    }


    //    // POST: Event/Create
    //    [HttpPost]
    //    public ActionResult Create(FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add insert logic here


    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    // GET: Event/Edit/5
    //    public ActionResult Edit(int id)
    //    {
    //        return View();
    //    }

    //    // POST: Event/Edit/5
    //    [HttpPost]
    //    public ActionResult Edit(int id, FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add update logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    // GET: Event/Delete/5
    //    public ActionResult Delete(int id)
    //    {
    //        return View();
    //    }


    //    // POST: Event/Delete/5
    //    [HttpPost]
    //    public ActionResult Delete(int id, FormCollection collection)
    //    {
    //        try
    //        {
    //            // TODO: Add delete logic here

    //            return RedirectToAction("Index");
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    //}

}
