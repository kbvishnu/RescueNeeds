﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RescueNeeds.Service;

namespace RescueNeeds.Controllers
{
    public class CampRequirementsController : Controller
    {
        private RescueNeedsEntities db = new RescueNeedsEntities();

        // GET: CampRequirements
        public ActionResult Index()
        {
            var campRequirements = db.CampRequirements.Include(c => c.Camp).Include(c => c.Item);
            return View(campRequirements.ToList());
        }

        // GET: CampRequirements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampRequirement campRequirement = db.CampRequirements.Find(id);
            if (campRequirement == null)
            {
                return HttpNotFound();
            }
            return View(campRequirement);
        }

        // GET: CampRequirements/Create
        public ActionResult Create()
        {
            ViewBag.CampsID = new SelectList(db.Camps, "CampsID", "Name");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            return View();
        }

        // POST: CampRequirements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampRequirementID,CampsID,ItemID,Need,Recieved")] CampRequirement campRequirement)
        {
            if (ModelState.IsValid)
            {
                db.CampRequirements.Add(campRequirement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampsID = new SelectList(db.Camps, "CampsID", "Name", campRequirement.CampsID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", campRequirement.ItemID);
            return View(campRequirement);
        }

        // GET: CampRequirements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampRequirement campRequirement = db.CampRequirements.Find(id);
            if (campRequirement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampsID = new SelectList(db.Camps, "CampsID", "Name", campRequirement.CampsID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", campRequirement.ItemID);
            return View(campRequirement);
        }

        // POST: CampRequirements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampRequirementID,CampsID,ItemID,Need,Recieved")] CampRequirement campRequirement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campRequirement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampsID = new SelectList(db.Camps, "CampsID", "Name", campRequirement.CampsID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", campRequirement.ItemID);
            return View(campRequirement);
        }

        // GET: CampRequirements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampRequirement campRequirement = db.CampRequirements.Find(id);
            if (campRequirement == null)
            {
                return HttpNotFound();
            }
            return View(campRequirement);
        }

        // POST: CampRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CampRequirement campRequirement = db.CampRequirements.Find(id);
            db.CampRequirements.Remove(campRequirement);
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