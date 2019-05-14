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
    public class NPCsController : ApiController
    {
        private DnDatabaseContext db = new DnDatabaseContext();

        // GET: api/NPCs
        public IQueryable<NPC> GetNPCs()
        {
            return db.NPCs;
        }

        // GET: api/NPCs/5
        [ResponseType(typeof(NPC))]
        public IHttpActionResult GetNPC(int id)
        {
            NPC nPC = db.NPCs.Find(id);
            if (nPC == null)
            {
                return NotFound();
            }

            return Ok(nPC);
        }

        // PUT: api/NPCs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNPC(int id, NPC nPC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nPC.NPCId)
            {
                return BadRequest();
            }

            db.Entry(nPC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NPCExists(id))
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

        // POST: api/NPCs
        [ResponseType(typeof(NPC))]
        public IHttpActionResult PostNPC(NPC nPC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NPCs.Add(nPC);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nPC.NPCId }, nPC);
        }

        // DELETE: api/NPCs/5
        [ResponseType(typeof(NPC))]
        public IHttpActionResult DeleteNPC(int id)
        {
            NPC nPC = db.NPCs.Find(id);
            if (nPC == null)
            {
                return NotFound();
            }

            db.NPCs.Remove(nPC);
            db.SaveChanges();

            return Ok(nPC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NPCExists(int id)
        {
            return db.NPCs.Count(e => e.NPCId == id) > 0;
        }
    }
}