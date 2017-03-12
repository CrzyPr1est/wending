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
    public class GoodsController : ApiController
    {
        private WendingContext db = new WendingContext();

        // GET: api/Goods
        public IQueryable<Cells> GetGoods()
        {
            return db.Cells.Include(g => g.Good);
        }

        // GET: api/Goods/5
        [ResponseType(typeof(Goods))]
        public IHttpActionResult GetGoods(int id)
        {
            Goods goods = db.Goods.Find(id);
            if (goods == null)
            {
                return NotFound();
            }

            return Ok(goods);
        }

        // PUT: api/Goods/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGoods(int id, Goods goods)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != goods.Id)
            {
                return BadRequest();
            }

            db.Entry(goods).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodsExists(id))
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

        // POST: api/Goods
        [ResponseType(typeof(Goods))]
        public IHttpActionResult PostGoods(Goods goods)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Goods.Add(goods);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = goods.Id }, goods);
        }

        // DELETE: api/Goods/5
        [ResponseType(typeof(Goods))]
        public IHttpActionResult DeleteGoods(int id)
        {
            Goods goods = db.Goods.Find(id);
            if (goods == null)
            {
                return NotFound();
            }

            db.Goods.Remove(goods);
            db.SaveChanges();

            return Ok(goods);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GoodsExists(int id)
        {
            return db.Goods.Count(e => e.Id == id) > 0;
        }
    }
}