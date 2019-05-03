using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIForBloodApp.Models;

namespace WebAPIForBloodApp.Controllers
{
    public class BloodUnitDataController : ApiController
    {
        private DatabaseBloodAppDbContext db = new DatabaseBloodAppDbContext();

        // GET: api/BloodUnitData
        public IQueryable<BloodUnit> GetBloodUnits()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.BloodUnits;
        }

        // GET: api/BloodUnitData/5
        [ResponseType(typeof(BloodUnit))]
        public IHttpActionResult GetBloodUnit(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            BloodUnit bloodUnit = db.BloodUnits.Find(id);
            if (bloodUnit == null)
            {
                return NotFound();
            }

            return Ok(bloodUnit);
        }

        // PUT: api/BloodUnitData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBloodUnit(int id, BloodUnit bloodUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bloodUnit.ID)
            {
                return BadRequest();
            }

            db.Entry(bloodUnit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodUnitExists(id))
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

        // POST: api/BloodUnitData
        [ResponseType(typeof(BloodUnit))]
        public IHttpActionResult PostBloodUnit(BloodUnit bloodUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BloodUnits.Add(bloodUnit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bloodUnit.ID }, bloodUnit);
        }

        // DELETE: api/BloodUnitData/5
        [ResponseType(typeof(BloodUnit))]
        public IHttpActionResult DeleteBloodUnit(int id)
        {
            BloodUnit bloodUnit = db.BloodUnits.Find(id);
            if (bloodUnit == null)
            {
                return NotFound();
            }

            db.BloodUnits.Remove(bloodUnit);
            db.SaveChanges();

            return Ok(bloodUnit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BloodUnitExists(int id)
        {
            return db.BloodUnits.Count(e => e.ID == id) > 0;
        }
    }
}