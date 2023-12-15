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
using api.Entities;
using api.Models;

namespace api.Controllers
{
    public class merchesController : ApiController
    {
        private DVDmagazinEntities1 db = new DVDmagazinEntities1();

        // GET: api/merches
        [ResponseType(typeof(List<ResponseMerch>))]
        public IHttpActionResult Getmerches()
        {
            return Ok(db.merch.ToList().ConvertAll(p => new ResponseMerch(p)));
        }

        // GET: api/merches/5
        [ResponseType(typeof(merch))]
        public IHttpActionResult Getmerch(int id)
        {
            merch merch = db.merch.Find(id);
            if (merch == null)
            {
                return NotFound();
            }

            return Ok(merch);
        }

        // PUT: api/merches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmerch(int id, merch merch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != merch.id)
            {
                return BadRequest();
            }

            db.Entry(merch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!merchExists(id))
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

        // POST: api/merches
        [ResponseType(typeof(merch))]
        public IHttpActionResult Postmerch(merch merch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.merch.Add(merch);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = merch.id }, merch);
        }

        // DELETE: api/merches/5
        [ResponseType(typeof(merch))]
        public IHttpActionResult Deletemerch(int id)
        {
            merch merch = db.merch.Find(id);
            if (merch == null)
            {
                return NotFound();
            }

            db.merch.Remove(merch);
            db.SaveChanges();

            return Ok(merch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool merchExists(int id)
        {
            return db.merch.Count(e => e.id == id) > 0;
        }
    }
}