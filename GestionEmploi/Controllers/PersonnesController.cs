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
    public class PersonnesController : ApiController
    {
        private DBIG3A8Entities db = new DBIG3A8Entities();

        // GET: api/Personnes
        public IQueryable<Personne> GetPersonne()
        {
            return db.Personne;
        }

        // GET: api/Personnes/5
        [ResponseType(typeof(Personne))]
        public IHttpActionResult GetPersonne(string id)
        {
            Personne personne = db.Personne.Find(id);
            if (personne == null)
            {
                return NotFound();
            }

            return Ok(personne);
        }

        // PUT: api/Personnes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonne(string id, Personne personne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personne.idPersonne)
            {
                return BadRequest();
            }

            db.Entry(personne).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult PostPersonne(Personne personne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personne.Add(personne);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PersonneExists(personne.idPersonne))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = personne.idPersonne }, personne);
        }

        // DELETE: api/Personnes/5
        [ResponseType(typeof(Personne))]
        public IHttpActionResult DeletePersonne(string id)
        {
            Personne personne = db.Personne.Find(id);
            if (personne == null)
            {
                return NotFound();
            }

            db.Personne.Remove(personne);
            db.SaveChanges();

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

        private bool PersonneExists(string id)
        {
            return db.Personne.Count(e => e.idPersonne == id) > 0;
        }
    }
}