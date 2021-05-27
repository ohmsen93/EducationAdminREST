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
    public class networksController : ApiController
    {
        private roll_call_dbEntities db = new roll_call_dbEntities();

        // GET: api/networks
        public List<network> Getnetworks()
        {
            return db.networks.ToList();
        }

        // GET: api/networks/5
        [ResponseType(typeof(network))]
        public IHttpActionResult Getnetwork(int id)
        {
            network network = db.networks.Find(id);
            if (network == null)
            {
                return NotFound();
            }

            return Ok(network);
        }

        // PUT: api/networks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putnetwork(int id, network network)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != network.id)
            {
                return BadRequest();
            }

            db.Entry(network).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!networkExists(id))
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

        // POST: api/networks
        [ResponseType(typeof(network))]
        public IHttpActionResult Postnetwork(network network)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.networks.Add(network);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = network.id }, network);
        }

        // DELETE: api/networks/5
        [ResponseType(typeof(network))]
        public IHttpActionResult Deletenetwork(int id)
        {
            network network = db.networks.Find(id);
            if (network == null)
            {
                return NotFound();
            }

            db.networks.Remove(network);
            db.SaveChanges();

            return Ok(network);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool networkExists(int id)
        {
            return db.networks.Count(e => e.id == id) > 0;
        }
    }
}