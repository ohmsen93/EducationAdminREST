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
    public class teachersController : ApiController
    {
        private roll_call_dbEntities db = new roll_call_dbEntities();

        // GET: api/teachers
        public IQueryable<teacher> Getteachers()
        {
            return db.teachers;
        }

        // GET: api/teachers/5
        [ResponseType(typeof(teacher))]
        public IHttpActionResult Getteacher(int id)
        {
            teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        // PUT: api/teachers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putteacher(int id, teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacher.id)
            {
                return BadRequest();
            }

            db.Entry(teacher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!teacherExists(id))
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

        // POST: api/teachers
        [ResponseType(typeof(teacher))]
        public IHttpActionResult Postteacher(teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.teachers.Add(teacher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teacher.id }, teacher);
        }

        // DELETE: api/teachers/5
        [ResponseType(typeof(teacher))]
        public IHttpActionResult Deleteteacher(int id)
        {
            teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            db.teachers.Remove(teacher);
            db.SaveChanges();

            return Ok(teacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool teacherExists(int id)
        {
            return db.teachers.Count(e => e.id == id) > 0;
        }
    }
}