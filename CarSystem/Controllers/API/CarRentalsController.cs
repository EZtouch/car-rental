using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CarSystem.Models;

namespace CarSystem.Controllers.API
{
    public class CarRentalsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CarRentals
        public IQueryable<CarRental> GetCarRentals()
        {
            return db.CarRentals;
        }

        // GET: api/CarRentals/5
        [ResponseType(typeof(CarRental))]
        public async Task<IHttpActionResult> GetCarRental(int id)
        {
            CarRental carRental = await db.CarRentals.FindAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }

            return Ok(carRental);
        }

        // PUT: api/CarRentals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCarRental(int id, CarRental carRental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carRental.ID)
            {
                return BadRequest();
            }

            db.Entry(carRental).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarRentalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CarRentals
        [ResponseType(typeof(CarRental))]
        public async Task<IHttpActionResult> PostCarRental(CarRental carRental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarRentals.Add(carRental);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = carRental.ID }, carRental);
        }

        // DELETE: api/CarRentals/5
        [ResponseType(typeof(CarRental))]
        public async Task<IHttpActionResult> DeleteCarRental(int id)
        {
            CarRental carRental = await db.CarRentals.FindAsync(id);
            if (carRental == null)
            {
                return NotFound();
            }

            db.CarRentals.Remove(carRental);
            await db.SaveChangesAsync();

            return Ok(carRental);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarRentalExists(int id)
        {
            return db.CarRentals.Count(e => e.ID == id) > 0;
        }
    }
}