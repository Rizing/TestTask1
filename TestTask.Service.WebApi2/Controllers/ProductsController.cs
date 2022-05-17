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
using TestTask.Service.WebApi2.Models;

namespace TestTask.Service.WebApi2.Controllers
{
    public class ProductsController : ApiController
    {
        private TestDBEntities db = new TestDBEntities();

        //•	GET-метод получения изделия по переданному идентификатору
        public async Task<IHttpActionResult> GetProduct(Guid id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }


        //•	POST-метод добавления нового изделия
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = product.ID }, product);
        }


        //•	PUT-метод редактирования существующего изделия
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(Guid id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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


        //•	DELETE-метод удаления существующего изделия по указанному идентификатору изделия
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(Guid id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private bool ProductExists(Guid id)
        {
            return db.Products.Count(e => e.ID == id) > 0;
        }
    }
}