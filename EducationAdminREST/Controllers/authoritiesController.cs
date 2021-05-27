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
    public class authoritiesController : ApiController
    {
        private roll_call_dbEntities db = new roll_call_dbEntities();

        // GET: api/authorities
        public IQueryable<authority> Getauthorities()
        {
            return db.authorities;
        }

        // GET: api/authorities/5
        [ResponseType(typeof(authority))]
        public IHttpActionResult Getauthority(string id)
        {
            authority authority = db.authorities.Find(id);
            if (authority == null)
            {
                return NotFound();
            }

            return Ok(authority);
        }

        // PUT: api/authorities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putauthority(string id, authority authority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authority.username)
            {
                return BadRequest();
            }

            db.Entry(authority).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!authorityExists(id))
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

        // POST: api/authorities
        [ResponseType(typeof(authority))]
        public IHttpActionResult Postauthority(authority authority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.authorities.Add(authority);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (authorityExists(authority.username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = authority.username }, authority);
        }

        // DELETE: api/authorities/5
        [ResponseType(typeof(authority))]
        public IHttpActionResult Deleteauthority(string id)
        {
            authority authority = db.authorities.Find(id);
            if (authority == null)
            {
                return NotFound();
            }

            db.authorities.Remove(authority);
            db.SaveChanges();

            return Ok(authority);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool authorityExists(string id)
        {
            return db.authorities.Count(e => e.username == id) > 0;
        }
    }
}