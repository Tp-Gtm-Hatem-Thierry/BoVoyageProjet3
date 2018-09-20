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
    public class DossierReservationsController : ApiController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: api/DossierReservations
        public IQueryable<DossierReservation> GetDossierReservations()
        {
            return db.DossierReservations;
        }

        // GET: api/DossierReservations/5
        [ResponseType(typeof(DossierReservation))]
        public async Task<IHttpActionResult> GetDossierReservation(int id)
        {
            DossierReservation dossierReservation = await db.DossierReservations.FindAsync(id);
            if (dossierReservation == null)
            {
                return NotFound();
            }

            return Ok(dossierReservation);
        }

        // PUT: api/DossierReservations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDossierReservation(int id, DossierReservation dossierReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dossierReservation.Id)
            {
                return BadRequest();
            }

            db.Entry(dossierReservation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DossierReservationExists(id))
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

        // POST: api/DossierReservations
        [ResponseType(typeof(DossierReservation))]
        public async Task<IHttpActionResult> PostDossierReservation(DossierReservation dossierReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DossierReservations.Add(dossierReservation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dossierReservation.Id }, dossierReservation);
        }

        // DELETE: api/DossierReservations/5
        [ResponseType(typeof(DossierReservation))]
        public async Task<IHttpActionResult> DeleteDossierReservation(int id)
        {
            DossierReservation dossierReservation = await db.DossierReservations.FindAsync(id);
            if (dossierReservation == null)
            {
                return NotFound();
            }

            db.DossierReservations.Remove(dossierReservation);
            await db.SaveChangesAsync();

            return Ok(dossierReservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DossierReservationExists(int id)
        {
            return db.DossierReservations.Count(e => e.Id == id) > 0;
        }
    }
}