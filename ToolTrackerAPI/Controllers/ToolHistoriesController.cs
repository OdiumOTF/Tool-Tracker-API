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
using ToolTrackerAPI.Models;

namespace ToolTrackerAPI.Controllers
{
    public class ToolHistoriesController : ApiController
    {
        private ToolRentalEntities db = new ToolRentalEntities();

        // GET: api/ToolHistories
        public IQueryable<ToolHistory> GetToolHistories()
        {
            return db.ToolHistories;
        }

        // GET: api/ToolHistories/5
        [ResponseType(typeof(ToolHistory))]
        public IHttpActionResult GetToolHistory(int id)
        {
            ToolHistory toolHistory = db.ToolHistories.Find(id);
            if (toolHistory == null)
            {
                return NotFound();
            }

            return Ok(toolHistory);
        }

        // PUT: api/ToolHistories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToolHistory(int id, ToolHistory toolHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toolHistory.ToolHistoryId)
            {
                return BadRequest();
            }

            db.Entry(toolHistory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToolHistoryExists(id))
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

        // POST: api/ToolHistories
        [ResponseType(typeof(ToolHistory))]
        public IHttpActionResult PostToolHistory(ToolHistory toolHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ToolHistories.Add(toolHistory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = toolHistory.ToolHistoryId }, toolHistory);
        }

        // DELETE: api/ToolHistories/5
        [ResponseType(typeof(ToolHistory))]
        public IHttpActionResult DeleteToolHistory(int id)
        {
            ToolHistory toolHistory = db.ToolHistories.Find(id);
            if (toolHistory == null)
            {
                return NotFound();
            }

            db.ToolHistories.Remove(toolHistory);
            db.SaveChanges();

            return Ok(toolHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToolHistoryExists(int id)
        {
            return db.ToolHistories.Count(e => e.ToolHistoryId == id) > 0;
        }
    }
}