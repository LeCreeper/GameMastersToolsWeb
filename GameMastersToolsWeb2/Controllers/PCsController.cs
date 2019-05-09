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
using GameMastersToolsWeb2.Models;

namespace GameMastersToolsWeb2.Controllers
{
    public class PCsController : ApiController
    {
        private DnDatabaseContext db = new DnDatabaseContext();

        // GET: api/PCs
        public IQueryable<PC> GetPCs()
        {
            return db.PCs;
        }

        // GET: api/PCs/5
        [ResponseType(typeof(PC))]
        public IHttpActionResult GetPC(int id)
        {
            PC pC = db.PCs.Find(id);
            if (pC == null)
            {
                return NotFound();
            }

            return Ok(pC);
        }

        // PUT: api/PCs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPC(int id, PC pC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pC.PCId)
            {
                return BadRequest();
            }

            db.Entry(pC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PCExists(id))
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

        // POST: api/PCs
        [ResponseType(typeof(PC))]
        public IHttpActionResult PostPC(PC pC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PCs.Add(pC);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pC.PCId }, pC);
        }

        // DELETE: api/PCs/5
        [ResponseType(typeof(PC))]
        public IHttpActionResult DeletePC(int id)
        {
            PC pC = db.PCs.Find(id);
            if (pC == null)
            {
                return NotFound();
            }

            db.PCs.Remove(pC);
            db.SaveChanges();

            return Ok(pC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PCExists(int id)
        {
            return db.PCs.Count(e => e.PCId == id) > 0;
        }
    }
}