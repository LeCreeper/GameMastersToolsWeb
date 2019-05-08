﻿using System;
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
    public class CampaignsController : ApiController
    {
        private DnDatabaseContext db = new DnDatabaseContext();

        // GET: api/Campaigns
        public IQueryable<Campaign> GetCampaigns()
        {
            return db.Campaigns;
        }

        // GET: api/Campaigns/5
        [ResponseType(typeof(Campaign))]
        public IHttpActionResult GetCampaign(int id)
        {
            Campaign campaign = db.Campaigns.Find(id);
            if (campaign == null)
            {
                return NotFound();
            }

            return Ok(campaign);
        }

        // PUT: api/Campaigns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCampaign(int id, Campaign campaign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campaign.CampaignId)
            {
                return BadRequest();
            }

            db.Entry(campaign).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignExists(id))
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

        // POST: api/Campaigns
        [ResponseType(typeof(Campaign))]
        public IHttpActionResult PostCampaign(Campaign campaign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Campaigns.Add(campaign);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = campaign.CampaignId }, campaign);
        }

        // DELETE: api/Campaigns/5
        [ResponseType(typeof(Campaign))]
        public IHttpActionResult DeleteCampaign(int id)
        {
            Campaign campaign = db.Campaigns.Find(id);
            if (campaign == null)
            {
                return NotFound();
            }

            db.Campaigns.Remove(campaign);
            db.SaveChanges();

            return Ok(campaign);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CampaignExists(int id)
        {
            return db.Campaigns.Count(e => e.CampaignId == id) > 0;
        }
    }
}