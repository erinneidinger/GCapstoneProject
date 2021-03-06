﻿using groupCapstoneMusic.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace groupCapstoneMusic.Controllers
{
    [Authorize]
    public class IMessageController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: IMessage
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var messages = db.Messages.Where(m => m.ReceiverId == userId).ToList();//Inbox showing only message sent to the user
            return View(messages);
        }

        public ActionResult SentMail()
        {
            var userId = User.Identity.GetUserId();
            var sentMessages = db.Messages.Where(m => m.SenderId == userId).ToList();
            return View(sentMessages); //Shows the user mail they sent
        }

        public ActionResult Details(int id)
        {
            var message = db.Messages.Where(m => m.Id == id).FirstOrDefault();
            var userId = User.Identity.GetUserId();
            if (message.SenderId == userId)
            {
                return View(message);
            }
            message.UnRead = false;//Changes the bool not show a checkmark
            db.SaveChanges();
            return View(message);
        }

        // GET: IMessage/Create
        public ActionResult Create(string id)
        {
            Message message = new Message();
            return View(message);
        }

        // POST: IMessage/Create
        [HttpPost]
        public ActionResult Create(Message message, string id)
        {
            try
            {               
                var userId = User.Identity.GetUserId();
                var userSender = db.Users.Where(u => u.Id == userId).FirstOrDefault();
                var userReceiver = db.Users.Where(u => u.Id == id).FirstOrDefault();
                string userNameSender = userSender.UserName;
                string userNameReceiver = userReceiver.UserName;
                message.SenderId = userId;
                message.ReceiverId = id;
                message.DatePosted = DateTime.Now;
                message.From = userNameSender;
                message.To = userNameReceiver;
                message.UnRead = true;
                db.Messages.Add(message);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: IMessage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IMessage/Edit/5
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

        // GET: IMessage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            try
            {
                db.Messages.Remove(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }
        }   
    }
}
