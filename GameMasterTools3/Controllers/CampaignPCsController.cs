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
using GameMasterTools3.Models;

namespace GameMasterTools3.Controllers
{
    public class CampaignPCsController : ApiController
    {
        private DnDatabaseContext db = new DnDatabaseContext();

        // GET: api/CampaignPCs
        public IQueryable<CampaignPC> GetCampaignPC()
        {
            return db.CampaignPC;
        }

        // GET: api/CampaignPCs/5
        [ResponseType(typeof(CampaignPC))]
        public IHttpActionResult GetCampaignPC(int id)
        {
            CampaignPC campaignPC = db.CampaignPC.Find(id);
            if (campaignPC == null)
            {
                return NotFound();
            }

            return Ok(campaignPC);
        }

        // PUT: api/CampaignPCs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCampaignPC(int id, CampaignPC campaignPC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campaignPC.CampaignPCId)
            {
                return BadRequest();
            }

            db.Entry(campaignPC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignPCExists(id))
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

        // POST: api/CampaignPCs
        [ResponseType(typeof(CampaignPC))]
        public IHttpActionResult PostCampaignPC(CampaignPC campaignPC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CampaignPC.Add(campaignPC);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = campaignPC.CampaignPCId }, campaignPC);
        }

        // DELETE: api/CampaignPCs/5
        [ResponseType(typeof(CampaignPC))]
        public IHttpActionResult DeleteCampaignPC(int id)
        {
            CampaignPC campaignPC = db.CampaignPC.Find(id);
            if (campaignPC == null)
            {
                return NotFound();
            }

            db.CampaignPC.Remove(campaignPC);
            db.SaveChanges();

            return Ok(campaignPC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CampaignPCExists(int id)
        {
            return db.CampaignPC.Count(e => e.CampaignPCId == id) > 0;
        }
    }
}