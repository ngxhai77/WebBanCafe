﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quanlycafe.Models;

namespace Quanlycafe.Areas.Admin.Controllers
{
    public class SanphamsController : Controller
    {
        private QLbanhang db = new QLbanhang();

        // GET: Admin/Sanphams
        public ActionResult Index()
        {
            var sanphams = db.Sanpham.Include(s => s.Loaihang);
            return View(sanphams.ToList());
        }

        // GET: Admin/Sanphams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanpham.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Create
        public ActionResult Create()
        {
            Sanpham sp = new Sanpham();
            ViewBag.Mahang = new SelectList(db.Loaihang, "Mahang", "Tenhang");
            return View();
        }

        // POST: Admin/Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Masp,Tensp,Giatien,Soluong,Mota,Anhbia,Mahang")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Sanpham.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mahang = new SelectList(db.Loaihang, "Mahang", "Tenhang", sanpham.Mahang);
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanpham.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mahang = new SelectList(db.Loaihang, "Mahang", "Tenhang", sanpham.Mahang);
            return View(sanpham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Masp,Tensp,Giatien,Soluong,Mota,Anhbia,Mahang")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mahang = new SelectList(db.Loaihang, "Mahang", "Tenhang", sanpham.Mahang);
            return View(sanpham);
        }

        // GET: Admin/Sanphams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanpham sanpham = db.Sanpham.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: Admin/Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sanpham sanpham = db.Sanpham.Find(id);
            db.Sanpham.Remove(sanpham);
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
