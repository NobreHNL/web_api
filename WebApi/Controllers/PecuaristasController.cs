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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class PecuaristasController : ApiController
    {
        private WebApiContext db = new WebApiContext();

        // GET: api/Pecuaristas
        public IQueryable<Pecuarista> GetPecuaristas()
        {
            return db.Pecuaristas;
        }

        // GET: api/Pecuaristas/5
        [ResponseType(typeof(Pecuarista))]
        public async Task<IHttpActionResult> GetPecuarista(int id)
        {
            Pecuarista pecuarista = await db.Pecuaristas.FindAsync(id);
            if (pecuarista == null)
            {
                return NotFound();
            }

            return Ok(pecuarista);
        }

        // PUT: api/Pecuaristas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPecuarista(int id, Pecuarista pecuarista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pecuarista.Id)
            {
                return BadRequest();
            }

            db.Entry(pecuarista).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PecuaristaExists(id))
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

        // POST: api/Pecuaristas
        [ResponseType(typeof(Pecuarista))]
        public async Task<IHttpActionResult> PostPecuarista(Pecuarista pecuarista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pecuaristas.Add(pecuarista);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pecuarista.Id }, pecuarista);
        }

        // DELETE: api/Pecuaristas/5
        [ResponseType(typeof(Pecuarista))]
        public async Task<IHttpActionResult> DeletePecuarista(int id)
        {
            Pecuarista pecuarista = await db.Pecuaristas.FindAsync(id);
            if (pecuarista == null)
            {
                return NotFound();
            }

            db.Pecuaristas.Remove(pecuarista);
            await db.SaveChangesAsync();

            return Ok(pecuarista);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PecuaristaExists(int id)
        {
            return db.Pecuaristas.Count(e => e.Id == id) > 0;
        }
    }
}