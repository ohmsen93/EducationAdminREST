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
using EducationAdminREST.Models;

namespace EducationAdminREST.Controllers
{
    public class gps_coordinatesController : ApiController
    {
        private roll_call_dbEntities db = new roll_call_dbEntities();

        // GET: api/gps_coordinates
        public IQueryable<gps_coordinates> Getgps_coordinates()
        {
            return db.gps_coordinates;
        }

        // GET: api/gps_coordinates/5
        [ResponseType(typeof(gps_coordinates))]
        public IHttpActionResult Getgps_coordinates(int id)
        {
            gps_coordinates gps_coordinates = db.gps_coordinates.Find(id);
            if (gps_coordinates == null)
            {
                return NotFound();
            }

            return Ok(gps_coordinates);
        }

        // PUT: api/gps_coordinates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgps_coordinates(int id, gps_coordinates gps_coordinates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gps_coordinates.id)
            {
                return BadRequest();
            }

            db.Entry(gps_coordinates).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gps_coordinatesExists(id))
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

        // POST: api/gps_coordinates
        [ResponseType(typeof(gps_coordinates))]
        public IHttpActionResult Postgps_coordinates(gps_coordinates gps_coordinates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.gps_coordinates.Add(gps_coordinates);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gps_coordinates.id }, gps_coordinates);
        }

        // DELETE: api/gps_coordinates/5
        [ResponseType(typeof(gps_coordinates))]
        public IHttpActionResult Deletegps_coordinates(int id)
        {
            gps_coordinates gps_coordinates = db.gps_coordinates.Find(id);
            if (gps_coordinates == null)
            {
                return NotFound();
            }

            db.gps_coordinates.Remove(gps_coordinates);
            db.SaveChanges();

            return Ok(gps_coordinates);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gps_coordinatesExists(int id)
        {
            return db.gps_coordinates.Count(e => e.id == id) > 0;
        }
    }
}