using System.Diagnostics;
using CarMaintenance.Data;
using CarMaintenance.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenance.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db;

        public HomeController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            ViewData["TotalCars"] = db.Tbl_Cars.Count();
            ViewData["TotalCustomers"] = db.Tbl_Customers.Count();
            ViewData["TotalServices"] = db.Tbl_Services.Count();
            ViewData["TotalUsers"] = db.Tbl_Users.Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
