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
using GestionEmploi.Models;

namespace GestionEmploi.Controllers
{
    public class TravailleursController : ApiController
    {
        private DBIG3A8Entities db = new DBIG3A8Entities();

        // GET: api/Travailleurs 
        public IQueryable<Travailleur> GetTravailleur()
        {           
            return db.Travailleur;
        }

        // GET: api/Travailleurs/5
        [ResponseType(typeof(Travailleur))]
        public IHttpActionResult GetTravailleur(decimal id)
        {
            Travailleur travailleur = db.Travailleur.Find(id);
            if (travailleur == null)
            {
                return NotFound();
            }

            return Ok(travailleur);
        }

        // PUT: api/Travailleurs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTravailleur(decimal id, Travailleur travailleur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != travailleur.numDossier)
            {
                return BadRequest();
            }

            db.Entry(travailleur).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravailleurExists(id))
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

        // POST: api/Travailleurs
        [ResponseType(typeof(Travailleur))]
        public IHttpActionResult PostTravailleur(Travailleur travailleur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Travailleur.Add(travailleur);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TravailleurExists(travailleur.numDossier))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = travailleur.numDossier }, travailleur);
        }

        // DELETE: api/Travailleurs/5
        [ResponseType(typeof(Travailleur))]
        public IHttpActionResult DeleteTravailleur(decimal id)
        {
            Travailleur travailleur = db.Travailleur.Find(id);
            if (travailleur == null)
            {
                return NotFound();
            }

            db.Travailleur.Remove(travailleur);
            db.SaveChanges();

            return Ok(travailleur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TravailleurExists(decimal id)
        {
            return db.Travailleur.Count(e => e.numDossier == id) > 0;
        }
    }
}