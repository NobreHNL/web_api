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
    public class AnimaisController : ApiController
    {
        private WebApiContext db = new WebApiContext();

        // GET: api/Animais
        public IQueryable<Animal> GetAnimals()
        {
            return db.Animais;
        }

        // GET: api/Animais/5
        [ResponseType(typeof(Animal))]
        public async Task<IHttpActionResult> GetAnimal(int id)
        {
            Animal animal = await db.Animais.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        // PUT: api/Animais/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAnimal(int id, Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animal.Id)
            {
                return BadRequest();
            }

            db.Entry(animal).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
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

        // POST: api/Animais
        [ResponseType(typeof(Animal))]
        public async Task<IHttpActionResult> PostAnimal(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Animais.Add(animal);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = animal.Id }, animal);
        }

        // DELETE: api/Animais/5
        [ResponseType(typeof(Animal))]
        public async Task<IHttpActionResult> DeleteAnimal(int id)
        {
            Animal animal = await db.Animais.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            db.Animais.Remove(animal);
            await db.SaveChangesAsync();

            return Ok(animal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnimalExists(int id)
        {
            return db.Animais.Count(e => e.Id == id) > 0;
        }
    }
}