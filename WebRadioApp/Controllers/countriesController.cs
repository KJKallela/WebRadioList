﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebRadioApp.Models;

namespace WebRadioApp.Controllers
{
    public class countriesController : Controller
    {
        private WebRadiosEntities db = new WebRadiosEntities();

        // GET: countries
        public ActionResult Index()
        {
            return View(db.country.ToList());
        }

        // GET: countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            country country = db.country.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] country country)
        {
            if (ModelState.IsValid)
            {
                db.country.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            country country = db.country.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            country country = db.country.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            country country = db.country.Find(id);
            db.country.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
