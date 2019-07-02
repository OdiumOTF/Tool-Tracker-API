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
    public class WorkshopsController : ApiController
    {
        private ToolRentalEntities db = new ToolRentalEntities();

        // GET: api/Workshops
        public IQueryable<Workshop> GetWorkshops()
        {
            return db.Workshops;
        }

        // GET: api/Workshops/5
        [ResponseType(typeof(Workshop))]
        public IHttpActionResult GetWorkshop(int id)
        {
            Workshop workshop = db.Workshops.Find(id);
            if (workshop == null)
            {
                return NotFound();
            }

            return Ok(workshop);
        }

        // PUT: api/Workshops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkshop(int id, Workshop workshop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workshop.WorkshopId)
            {
                return BadRequest();
            }

            db.Entry(workshop).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopExists(id))
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

        // POST: api/Workshops
        [ResponseType(typeof(Workshop))]
        public IHttpActionResult PostWorkshop(Workshop workshop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workshops.Add(workshop);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workshop.WorkshopId }, workshop);
        }

        // DELETE: api/Workshops/5
        [ResponseType(typeof(Workshop))]
        public IHttpActionResult DeleteWorkshop(int id)
        {
            Workshop workshop = db.Workshops.Find(id);
            if (workshop == null)
            {
                return NotFound();
            }

            db.Workshops.Remove(workshop);
            db.SaveChanges();

            return Ok(workshop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkshopExists(int id)
        {
            return db.Workshops.Count(e => e.WorkshopId == id) > 0;
        }
    }
}