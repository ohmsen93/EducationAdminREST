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
    public class iclassesController : ApiController
    {
        private roll_call_dbEntities db = new roll_call_dbEntities();

        // GET: api/iclasses
        public List<iclass> Geticlasses()
        {
            return db.iclasses.ToList();
        }

        // GET: api/iclasses/5
        [ResponseType(typeof(iclass))]
        public IHttpActionResult Geticlass(int id)
        {
            iclass iclass = db.iclasses.Find(id);
            if (iclass == null)
            {
                return NotFound();
            }

            return Ok(iclass);
        }

        // PUT: api/iclasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puticlass(int id, iclass iclass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iclass.id)
            {
                return BadRequest();
            }

            db.Entry(iclass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!iclassExists(id))
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

        // POST: api/iclasses
        [ResponseType(typeof(iclass))]
        public IHttpActionResult Posticlass(iclass iclass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.iclasses.Add(iclass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = iclass.id }, iclass);
        }

        // DELETE: api/iclasses/5
        [ResponseType(typeof(iclass))]
        public IHttpActionResult Deleteiclass(int id)
        {
            iclass iclass = db.iclasses.Find(id);
            if (iclass == null)
            {
                return NotFound();
            }

            db.iclasses.Remove(iclass);
            db.SaveChanges();

            return Ok(iclass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool iclassExists(int id)
        {
            return db.iclasses.Count(e => e.id == id) > 0;
        }
    }
}