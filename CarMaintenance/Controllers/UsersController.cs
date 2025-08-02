using CarMaintenance.Data;
using CarMaintenance.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarMaintenance.Controllers
{
    public class UsersController : Controller
    {
        private AppDbContext db;

        public UsersController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            var data = db.Tbl_Users;
            return View(data);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(Users users)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Users.Add(users);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult EditUser(int Id)
        {
            var data = db.Tbl_Users.Find(Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditUser(Users users)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Users.Update(users);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteUser(int Id)
        {
            var data = db.Tbl_Users.Find(Id);

            if (data != null)
            {
                db.Tbl_Users.Remove(data);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

    }
}
