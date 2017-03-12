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
using wending1.Models;
using wending1.Models.DAL;

namespace wending1.Controllers
{
    public class UserWalletsController : ApiController
    {
        private WendingContext db = new WendingContext();

        // GET: api/UserWallets
        public IQueryable<UserWallets> GetUser()
        {
            return db.User;
        }

        // GET: api/UserWallets/5
        [ResponseType(typeof(UserWallets))]
        public IHttpActionResult GetUserWallets(int id)
        {
            UserWallets userWallets = db.User.Find(id);
            if (userWallets == null)
            {
                return NotFound();
            }

            return Ok(userWallets);
        }

        // PUT: api/UserWallets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserWallets(int id, UserWallets userWallets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userWallets.Id)
            {
                return BadRequest();
            }

            db.Entry(userWallets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserWalletsExists(id))
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

        // POST: api/UserWallets
        [ResponseType(typeof(UserWallets))]
        public IHttpActionResult PostUserWallets(UserWallets userWallets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User.Add(userWallets);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userWallets.Id }, userWallets);
        }

        // DELETE: api/UserWallets/5
        [ResponseType(typeof(UserWallets))]
        public IHttpActionResult DeleteUserWallets(int id)
        {
            UserWallets userWallets = db.User.Find(id);
            if (userWallets == null)
            {
                return NotFound();
            }

            db.User.Remove(userWallets);
            db.SaveChanges();

            return Ok(userWallets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserWalletsExists(int id)
        {
            return db.User.Count(e => e.Id == id) > 0;
        }
    }
}