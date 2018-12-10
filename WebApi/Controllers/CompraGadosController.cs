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
    public class CompraGadosController : ApiController
    {
        private WebApiContext db = new WebApiContext();

        // GET: api/CompraGados
        public IQueryable<CompraGado> GetCompraGadoes()
        {
            return db.CompraGados.Include(c => c.Pecuarista).Include(c => c.CompraGadoItems);
        }

        // GET: api/CompraGados/5
        [ResponseType(typeof(CompraGado))]
        public async Task<IHttpActionResult> GetCompraGado(int id)
        {
            CompraGado compraGado = await db.CompraGados.Where(c => c.Id == id).Include(c => c.Pecuarista).Include(c => c.CompraGadoItems).SingleAsync();
            if (compraGado == null)
            {
                return NotFound();
            }

            return Ok(compraGado);
        }

        // PUT: api/CompraGados/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCompraGado(int id, CompraGado compraGado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compraGado.Id)
            {
                return BadRequest();
            }

            db.Entry(compraGado).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraGadoExists(id))
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

        // POST: api/CompraGados
        [ResponseType(typeof(CompraGado))]
        public async Task<IHttpActionResult> PostCompraGado(CompraGado compraGado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.CompraGados.Add(compraGado);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = compraGado.Id }, compraGado);
        }

        // DELETE: api/CompraGados/5
        [ResponseType(typeof(CompraGado))]
        public async Task<IHttpActionResult> DeleteCompraGado(int id)
        {
            CompraGado compraGado = await db.CompraGados.FindAsync(id);
            if (compraGado == null)
            {
                return NotFound();
            }

            db.CompraGados.Remove(compraGado);
            await db.SaveChangesAsync();

            return Ok(compraGado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompraGadoExists(int id)
        {
            return db.CompraGados.Count(e => e.Id == id) > 0;
        }
    }
}