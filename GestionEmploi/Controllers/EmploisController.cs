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
    public class EmploisController : ApiController
    {
        private DBIG3A8Entities db = new DBIG3A8Entities();

        // GET: api/Emplois
        public IQueryable<Emploi> GetEmploi()
        {
            return db.Emploi;
        }

        // GET: api/Emplois/5
        [ResponseType(typeof(Emploi))]
        public IHttpActionResult GetEmploi(decimal id)
        {
            Emploi emploi = db.Emploi.Find(id);
            if (emploi == null)
            {
                return NotFound();
            }

            return Ok(emploi);
        }

        // PUT: api/Emplois/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmploi(decimal id, Emploi emploi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emploi.idEmploi)
            {
                return BadRequest();
            }

            db.Entry(emploi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploiExists(id))
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

        // POST: api/Emplois
        [ResponseType(typeof(Emploi))]
        public IHttpActionResult PostEmploi(Emploi emploi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Emploi.Add(emploi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmploiExists(emploi.idEmploi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = emploi.idEmploi }, emploi);
        }

        // DELETE: api/Emplois/5
        [ResponseType(typeof(Emploi))]
        public IHttpActionResult DeleteEmploi(decimal id)
        {
            Emploi emploi = db.Emploi.Find(id);
            if (emploi == null)
            {
                return NotFound();
            }

            db.Emploi.Remove(emploi);
            db.SaveChanges();

            return Ok(emploi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmploiExists(decimal id)
        {
            return db.Emploi.Count(e => e.idEmploi == id) > 0;
        }
    }
}