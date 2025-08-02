﻿using CarMaintenance.Data;
using CarMaintenance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CarMaintenance.Controllers
{
    public class CustomersController : Controller
    {
        private AppDbContext db;

        public CustomersController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            var data = db.Tbl_Customers.Include(x => x.Cars).ToList();
            return View(data);
        }

        public IActionResult AddCustomer()
        {
            // Load Cars for DropDown
            ViewBag.Cars = new SelectList(db.Tbl_Cars.ToList(), "CarID", "CarNumber");

            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Customers.Add(customers);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // Load Cars for DropDown
            ViewBag.Cars = new SelectList(db.Tbl_Cars.ToList(), "CarID", "CarNumber");

            return View();
        }

        public IActionResult EditCustomer(int Id)
        {
            // Load Cars for DropDown
            ViewBag.Cars = new SelectList(db.Tbl_Cars.ToList(), "CarID", "CarNumber");

            var data = db.Tbl_Customers.Find(Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Customers.Update(customers);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // Load Cars for DropDown
            ViewBag.Cars = new SelectList(db.Tbl_Cars.ToList(), "CarID", "CarNumber");

            return View();
        }

        public IActionResult DeleteCustomer(int Id)
        {
            var data = db.Tbl_Customers.Find(Id);

            if (data != null)
            {
                db.Tbl_Customers.Remove(data);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

    }
}
