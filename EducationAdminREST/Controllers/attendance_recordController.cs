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
    public class attendance_recordController : ApiController
    {
        private roll_call_dbEntities db = new roll_call_dbEntities();

        // GET: api/attendance_record
        public IQueryable<attendance_record> Getattendance_record()
        {
            return db.attendance_record;
        }

        // GET: api/attendance_record/5
        [ResponseType(typeof(attendance_record))]
        public IHttpActionResult Getattendance_record(int id)
        {
            attendance_record attendance_record = db.attendance_record.Find(id);
            if (attendance_record == null)
            {
                return NotFound();
            }

            return Ok(attendance_record);
        }

        // PUT: api/attendance_record/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putattendance_record(int id, attendance_record attendance_record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendance_record.student_id)
            {
                return BadRequest();
            }

            db.Entry(attendance_record).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!attendance_recordExists(id))
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

        // POST: api/attendance_record
        [ResponseType(typeof(attendance_record))]
        public IHttpActionResult Postattendance_record(attendance_record attendance_record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.attendance_record.Add(attendance_record);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (attendance_recordExists(attendance_record.student_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = attendance_record.student_id }, attendance_record);
        }

        // DELETE: api/attendance_record/5
        [ResponseType(typeof(attendance_record))]
        public IHttpActionResult Deleteattendance_record(int id)
        {
            attendance_record attendance_record = db.attendance_record.Find(id);
            if (attendance_record == null)
            {
                return NotFound();
            }

            db.attendance_record.Remove(attendance_record);
            db.SaveChanges();

            return Ok(attendance_record);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool attendance_recordExists(int id)
        {
            return db.attendance_record.Count(e => e.student_id == id) > 0;
        }
    }
}