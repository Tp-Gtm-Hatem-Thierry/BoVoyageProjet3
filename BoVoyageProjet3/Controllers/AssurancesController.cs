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
using BoVoyageProjet3.Data;
using BoVoyageProjet3.Models;

namespace BoVoyageProjet3.Controllers
{
    public class AssurancesController : ApiController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: api/Assurances
        public IQueryable<Assurance> GetAssurances()
        {
            return db.Assurances;
        }

        // GET: api/Assurances/5
        [ResponseType(typeof(Assurance))]
        public IHttpActionResult GetAssurance(int id)
        {
            Assurance assurance = db.Assurances.Find(id);
            if (assurance == null)
            {
                return NotFound();
            }

            return Ok(assurance);
        }

        // PUT: api/Assurances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssurance(int id, Assurance assurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assurance.Id)
            {
                return BadRequest();
            }

            db.Entry(assurance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssuranceExists(id))
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

        // POST: api/Assurances
        [ResponseType(typeof(Assurance))]
        public IHttpActionResult PostAssurance(Assurance assurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Assurances.Add(assurance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assurance.Id }, assurance);
        }

        // DELETE: api/Assurances/5
        [ResponseType(typeof(Assurance))]
        public IHttpActionResult DeleteAssurance(int id)
        {
            Assurance assurance = db.Assurances.Find(id);
            if (assurance == null)
            {
                return NotFound();
            }

            db.Assurances.Remove(assurance);
            db.SaveChanges();

            return Ok(assurance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssuranceExists(int id)
        {
            return db.Assurances.Count(e => e.Id == id) > 0;
        }
    }
}