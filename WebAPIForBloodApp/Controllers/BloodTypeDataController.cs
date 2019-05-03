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
    public class BloodTypeDataController : ApiController
    {
        private DatabaseBloodAppDbContext db = new DatabaseBloodAppDbContext();

        // GET: api/BloodTypeData
        public IQueryable<BloodType> GetBloodTypes()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.BloodTypes;
        }

        // GET: api/BloodTypeData/5
        [ResponseType(typeof(BloodType))]
        public IHttpActionResult GetBloodType(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            BloodType bloodType = db.BloodTypes.Find(id);
            if (bloodType == null)
            {
                return NotFound();
            }

            return Ok(bloodType);
        }

        // PUT: api/BloodTypeData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBloodType(int id, BloodType bloodType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bloodType.ID)
            {
                return BadRequest();
            }

            db.Entry(bloodType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodTypeExists(id))
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

        // POST: api/BloodTypeData
        [ResponseType(typeof(BloodType))]
        public IHttpActionResult PostBloodType(BloodType bloodType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BloodTypes.Add(bloodType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bloodType.ID }, bloodType);
        }

        // DELETE: api/BloodTypeData/5
        [ResponseType(typeof(BloodType))]
        public IHttpActionResult DeleteBloodType(int id)
        {
            BloodType bloodType = db.BloodTypes.Find(id);
            if (bloodType == null)
            {
                return NotFound();
            }

            db.BloodTypes.Remove(bloodType);
            db.SaveChanges();

            return Ok(bloodType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BloodTypeExists(int id)
        {
            return db.BloodTypes.Count(e => e.ID == id) > 0;
        }
    }
}