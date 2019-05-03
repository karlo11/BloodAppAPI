using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIForBloodApp.App_Start;
using WebAPIForBloodApp.Models;

namespace WebAPIForBloodApp.Controllers
{

    public class UserDataController : ApiController
    {
        private DatabaseBloodAppDbContext db = new DatabaseBloodAppDbContext();

        // GET: api/UserData
        public IQueryable<User> GetUsers()
        {

            db.Configuration.ProxyCreationEnabled = false;

            return db.Users;
        }

        //// GET: api/UserAuth
        //[BasicAuthentication]
        //public User GetAuthUser()
        //{
        //    db.Configuration.ProxyCreationEnabled = false;

        //    var account = db.Users.Where(u => u.Email == User.Identity.Name)
        //        .ToList()
        //        .SingleOrDefault();

        //    return account;
        //}

        // GET: api/UserData/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/UserData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.ID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/UserData
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        // DELETE: api/UserData/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.ID == id) > 0;
        }
    }
}