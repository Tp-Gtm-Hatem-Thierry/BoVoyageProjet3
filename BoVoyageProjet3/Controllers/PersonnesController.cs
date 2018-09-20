using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BoVoyageProjet3.Data;

namespace BoVoyageProjet3.Models
{
    public class PersonnesController : ApiController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: api/Personnes
        public IQueryable<Personne> GetPersonnes()
        {
            return db.Personnes;
        }

        // GET: api/Personnes/5
        [ResponseType(typeof(Personne))]
        public async Task<IHttpActionResult> GetPersonne(int id)
        {
            Personne personne = await db.Personnes.FindAsync(id);
            if (personne == null)
            {
                return NotFound();
            }

            return Ok(personne);
        }

        // PUT: api/Personnes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersonne(int id, Personne personne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personne.Id)
            {
                return BadRequest();
            }

            db.Entry(personne).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonneExists(id))
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

        // POST: api/Personnes
        [ResponseType(typeof(Personne))]
        public async Task<IHttpActionResult> PostPersonne(Personne personne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personnes.Add(personne);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = personne.Id }, personne);
        }

        // DELETE: api/Personnes/5
        [ResponseType(typeof(Personne))]
        public async Task<IHttpActionResult> DeletePersonne(int id)
        {
            Personne personne = await db.Personnes.FindAsync(id);
            if (personne == null)
            {
                return NotFound();
            }

            db.Personnes.Remove(personne);
            await db.SaveChangesAsync();

            return Ok(personne);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonneExists(int id)
        {
            return db.Personnes.Count(e => e.Id == id) > 0;
        }
    }
}