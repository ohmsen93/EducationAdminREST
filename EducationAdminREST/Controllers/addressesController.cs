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
    public class addressesController : ApiController
    {
        private roll_call_dbEntities db = new roll_call_dbEntities();

        // GET: api/addresses
        public List<address> Getaddresses()
        {
            return db.addresses.ToList();
        }

        // GET: api/addresses/5
        [ResponseType(typeof(address))]
        public IHttpActionResult Getaddress(int id)
        {
            address address = db.addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaddress(int id, address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.id)
            {
                return BadRequest();
            }

            db.Entry(address).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!addressExists(id))
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

        // POST: api/addresses
        [ResponseType(typeof(address))]
        public IHttpActionResult Postaddress(address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.addresses.Add(address);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = address.id }, address);
        }

        // DELETE: api/addresses/5
        [ResponseType(typeof(address))]
        public IHttpActionResult Deleteaddress(int id)
        {
            address address = db.addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            db.addresses.Remove(address);
            db.SaveChanges();

            return Ok(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool addressExists(int id)
        {
            return db.addresses.Count(e => e.id == id) > 0;
        }
    }
}