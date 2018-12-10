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
    public class CompraGadoItemsController : ApiController
    {
        private WebApiContext db = new WebApiContext();

        // GET: api/CompraGadoItems
        public IQueryable<CompraGadoItem> GetCompraGadoItems()
        {
            return db.CompraGadoItems.Include(c => c.Animais).Include(c => c.CompraGado);
        }

        // GET: api/CompraGadoItems/5
        [ResponseType(typeof(CompraGadoItem))]
        public async Task<IHttpActionResult> GetCompraGadoItem(int id)
        {
            CompraGadoItem compraGadoItem = await db.CompraGadoItems.Where(c => c.Id == id)
                .Include(c => c.Animais).Include(c => c.CompraGado).SingleAsync();
            if (compraGadoItem == null)
            {
                return NotFound();
            }

            return Ok(compraGadoItem);
        }

        // PUT: api/CompraGadoItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCompraGadoItem(int id, CompraGadoItem compraGadoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compraGadoItem.Id)
            {
                return BadRequest();
            }

            db.Entry(compraGadoItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraGadoItemExists(id))
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

        // POST: api/CompraGadoItems
        [ResponseType(typeof(CompraGadoItem))]
        public async Task<IHttpActionResult> PostCompraGadoItem(CompraGadoItem compraGadoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompraGadoItems.Add(compraGadoItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = compraGadoItem.Id }, compraGadoItem);
        }

        // DELETE: api/CompraGadoItems/5
        [ResponseType(typeof(CompraGadoItem))]
        public async Task<IHttpActionResult> DeleteCompraGadoItem(int id)
        {
            CompraGadoItem compraGadoItem = await db.CompraGadoItems.FindAsync(id);
            if (compraGadoItem == null)
            {
                return NotFound();
            }

            db.CompraGadoItems.Remove(compraGadoItem);
            await db.SaveChangesAsync();

            return Ok(compraGadoItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompraGadoItemExists(int id)
        {
            return db.CompraGadoItems.Count(e => e.Id == id) > 0;
        }
    }
}