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
    public class CellsController : ApiController
    {
        private WendingContext db = new WendingContext();

        // GET: api/Cells
        public IQueryable<Cells> GetCells()
        {
            return db.Cells;
        }

        // GET: api/Cells/5
        [ResponseType(typeof(Cells))]
        public IHttpActionResult GetCells(int id)
        {
            //Cells cells = db.Cells.Find(id);
            Cells cells = db.Cells.Include(g => g.Good).SingleOrDefault(x => x.Id == id);
            if (cells == null)
            {
                return NotFound();
            }

            return Ok(cells);
        }

        // PUT: api/Cells/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCells(int id, Cells cells)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cells.Id)
            {
                return BadRequest();
            }

            db.Entry(cells).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CellsExists(id))
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

        // POST: api/Cells
        [ResponseType(typeof(Cells))]
        public IHttpActionResult PostCells(Cells cells)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cells.Add(cells);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cells.Id }, cells);
        }

        // DELETE: api/Cells/5
        [ResponseType(typeof(Cells))]
        public IHttpActionResult DeleteCells(int id)
        {
            Cells cells = db.Cells.Find(id);
            if (cells == null)
            {
                return NotFound();
            }

            db.Cells.Remove(cells);
            db.SaveChanges();

            return Ok(cells);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CellsExists(int id)
        {
            return db.Cells.Count(e => e.Id == id) > 0;
        }
    }
}