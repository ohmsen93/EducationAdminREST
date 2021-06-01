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
    public class lecturesController : ApiController
    {
        private roll_call_dbEntities db = new roll_call_dbEntities();

        // GET: api/lectures
        public List<lecture> Getlectures()
        {
            return db.lectures.ToList();
        }

        // GET: api/lectures/5
        [ResponseType(typeof(lecture))]
        public IHttpActionResult Getlecture(int id)
        {
            lecture lecture = db.lectures.Find(id);
            if (lecture == null)
            {
                return NotFound();
            }

            return Ok(lecture);
        }

        // PUT: api/lectures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putlecture(int id, lecture lecture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lecture.id)
            {
                return BadRequest();
            }

            db.Entry(lecture).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!lectureExists(id))
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

        // POST: api/lectures
        [ResponseType(typeof(lecture))]
        public IHttpActionResult Postlecture(lecture lecture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.lectures.Add(lecture);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lecture.id }, lecture);
        }

        // DELETE: api/lectures/5
        [ResponseType(typeof(lecture))]
        public IHttpActionResult Deletelecture(int id)
        {
            lecture lecture = db.lectures.Find(id);
            if (lecture == null)
            {
                return NotFound();
            }

            db.lectures.Remove(lecture);
            db.SaveChanges();

            return Ok(lecture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool lectureExists(int id)
        {
            return db.lectures.Count(e => e.id == id) > 0;
        }
    }
}