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
    public class facultiesController : ApiController
    {
        private roll_call_dbEntities db = new roll_call_dbEntities();

        // GET: api/faculties
        public IQueryable<faculty> Getfaculties()
        {
            return db.faculties;
        }

        // GET: api/faculties/5
        [ResponseType(typeof(faculty))]
        public IHttpActionResult Getfaculty(int id)
        {
            faculty faculty = db.faculties.Find(id);
            if (faculty == null)
            {
                return NotFound();
            }

            return Ok(faculty);
        }

        // PUT: api/faculties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfaculty(int id, faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faculty.id)
            {
                return BadRequest();
            }

            db.Entry(faculty).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!facultyExists(id))
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

        // POST: api/faculties
        [ResponseType(typeof(faculty))]
        public IHttpActionResult Postfaculty(faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.faculties.Add(faculty);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = faculty.id }, faculty);
        }

        // DELETE: api/faculties/5
        [ResponseType(typeof(faculty))]
        public IHttpActionResult Deletefaculty(int id)
        {
            faculty faculty = db.faculties.Find(id);
            if (faculty == null)
            {
                return NotFound();
            }

            db.faculties.Remove(faculty);
            db.SaveChanges();

            return Ok(faculty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool facultyExists(int id)
        {
            return db.faculties.Count(e => e.id == id) > 0;
        }
    }
}