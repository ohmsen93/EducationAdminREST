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
    [Authorize]
    public class campusController : ApiController
    {
        private roll_call_dbEntities db = new roll_call_dbEntities();

        // GET: api/campus
        public List<campu> Getcampus()
        {
            return db.campus.ToList();
        }

        // GET: api/campus/5
        [ResponseType(typeof(campu))]
        public IHttpActionResult Getcampu(int id)
        {
            campu campu = db.campus.Find(id);
            if (campu == null)
            {
                return NotFound();
            }

            return Ok(campu);
        }

        // PUT: api/campus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcampu(int id, campu campu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campu.id)
            {
                return BadRequest();
            }

            db.Entry(campu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!campuExists(id))
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

        // POST: api/campus
        [ResponseType(typeof(campu))]
        public IHttpActionResult Postcampu(campu campu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.campus.Add(campu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = campu.id }, campu);
        }

        // DELETE: api/campus/5
        [ResponseType(typeof(campu))]
        public IHttpActionResult Deletecampu(int id)
        {
            campu campu = db.campus.Find(id);
            if (campu == null)
            {
                return NotFound();
            }

            db.campus.Remove(campu);
            db.SaveChanges();

            return Ok(campu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool campuExists(int id)
        {
            return db.campus.Count(e => e.id == id) > 0;
        }
    }
}