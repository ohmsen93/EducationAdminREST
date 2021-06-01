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
    public class classroomsController : ApiController
    {
        private roll_call_dbEntities db = new roll_call_dbEntities();

        // GET: api/classrooms
        public List<classroom> Getclassrooms()
        {
            return db.classrooms.ToList();
        }

        // GET: api/classrooms/5
        [ResponseType(typeof(classroom))]
        public IHttpActionResult Getclassroom(int id)
        {
            classroom classroom = db.classrooms.Find(id);
            if (classroom == null)
            {
                return NotFound();
            }

            return Ok(classroom);
        }

        // PUT: api/classrooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putclassroom(int id, classroom classroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classroom.id)
            {
                return BadRequest();
            }

            db.Entry(classroom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!classroomExists(id))
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

        // POST: api/classrooms
        [ResponseType(typeof(classroom))]
        public IHttpActionResult Postclassroom(classroom classroom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.classrooms.Add(classroom);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = classroom.id }, classroom);
        }

        // DELETE: api/classrooms/5
        [ResponseType(typeof(classroom))]
        public IHttpActionResult Deleteclassroom(int id)
        {
            classroom classroom = db.classrooms.Find(id);
            if (classroom == null)
            {
                return NotFound();
            }

            db.classrooms.Remove(classroom);
            db.SaveChanges();

            return Ok(classroom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool classroomExists(int id)
        {
            return db.classrooms.Count(e => e.id == id) > 0;
        }
    }
}