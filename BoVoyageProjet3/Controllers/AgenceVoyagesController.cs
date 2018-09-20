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
    public class AgenceVoyagesController : ApiController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: api/AgenceVoyages
        public IQueryable<AgenceVoyage> GetAgenceVoyages()
        {
            return db.AgenceVoyages;
        }

        // GET: api/AgenceVoyages/5
        [ResponseType(typeof(AgenceVoyage))]
        public async Task<IHttpActionResult> GetAgenceVoyage(int id)
        {
            AgenceVoyage agenceVoyage = await db.AgenceVoyages.FindAsync(id);
            if (agenceVoyage == null)
            {
                return NotFound();
            }

            return Ok(agenceVoyage);
        }

        // PUT: api/AgenceVoyages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAgenceVoyage(int id, AgenceVoyage agenceVoyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agenceVoyage.Id)
            {
                return BadRequest();
            }

            db.Entry(agenceVoyage).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenceVoyageExists(id))
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

        // POST: api/AgenceVoyages
        [ResponseType(typeof(AgenceVoyage))]
        public async Task<IHttpActionResult> PostAgenceVoyage(AgenceVoyage agenceVoyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AgenceVoyages.Add(agenceVoyage);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = agenceVoyage.Id }, agenceVoyage);
        }

        // DELETE: api/AgenceVoyages/5
        [ResponseType(typeof(AgenceVoyage))]
        public async Task<IHttpActionResult> DeleteAgenceVoyage(int id)
        {
            AgenceVoyage agenceVoyage = await db.AgenceVoyages.FindAsync(id);
            if (agenceVoyage == null)
            {
                return NotFound();
            }

            db.AgenceVoyages.Remove(agenceVoyage);
            await db.SaveChangesAsync();

            return Ok(agenceVoyage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgenceVoyageExists(int id)
        {
            return db.AgenceVoyages.Count(e => e.Id == id) > 0;
        }
    }
}