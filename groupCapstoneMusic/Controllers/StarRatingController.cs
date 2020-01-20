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
    public class StarRatingController : Controller
    {
        ApplicationDbContext db;
        // GET: StarRating
        public ActionResult Index()
        {
            return View();
        }

        // GET: StarRating/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StarRating/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: StarRating/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StarRating/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StarRating/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StarRating/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StarRating/Delete/5
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
        public void mRate0()
        {

        }
        public void mRate1()
        {

        }
        public void mRate2()
        {

        }
        public void mRate3()
        {

        }
        public void mRate4()
        {

        }
        public void mRate5()
        {

        }
        public void cRate0()
        {

        }
        public void cRate1()
        {

        }
        public void cRate2()
        {

        }
        public void cRate3()
        {

        }
        public void cRate4()
        {

        }
        public void cRate5()
        {

        }
    }
}
