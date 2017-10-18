using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarSystem.Models;

namespace CarSystem.Controllers
{
    public class CarRentalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarRentals
        public async Task<ActionResult> Index()
        {
            var carRentals = db.CarRentals.Include(c => c.Car).Include(c => c.Customer).Include(c => c.Employee);
            return View(await carRentals.ToListAsync());
        }

        // GET: CarRentals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental carRental = await db.CarRentals.FindAsync(id);
            if (carRental == null)
            {
                return HttpNotFound();
            }
            return View(carRental);
        }

        // GET: CarRentals/Create
        public ActionResult Create()
        {
            ViewBag.CarID = db.Cars.Select(car => new SelectListItem
            {
                Text = car.Make + " " + car.Model,
                Value = car.ID.ToString()
            });
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name");
            return View();
        }

        // POST: CarRentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CarID,CustomerID,EmployeeID,RentalDate,ReturnDate,PaidAmount,ActualReturnDate")] CarRental carRental)
        {
            if (ModelState.IsValid)
            {
                db.CarRentals.Add(carRental);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.Cars, "ID", "Make", carRental.CarID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", carRental.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", carRental.EmployeeID);
            return View(carRental);
        }

        // GET: CarRentals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental carRental = await db.CarRentals.FindAsync(id);
            if (carRental == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = db.Cars.Select(car => new SelectListItem
            {
                Text = car.Make + " " + car.Model,
                Value = car.ID.ToString()
            });
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", carRental.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", carRental.EmployeeID);
            return View(carRental);
        }

        // POST: CarRentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CarID,CustomerID,EmployeeID,RentalDate,ReturnDate,PaidAmount,ActualReturnDate")] CarRental carRental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carRental).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = db.Cars.Select(car => new SelectListItem
            {
                Text = car.Make + " " + car.Model,
                Value = car.ID.ToString()
            });
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", carRental.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", carRental.EmployeeID);
            return View(carRental);
        }

        // GET: CarRentals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarRental carRental = await db.CarRentals.FindAsync(id);
            if (carRental == null)
            {
                return HttpNotFound();
            }
            return View(carRental);
        }

        // POST: CarRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CarRental carRental = await db.CarRentals.FindAsync(id);
            db.CarRentals.Remove(carRental);
            await db.SaveChangesAsync();
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
