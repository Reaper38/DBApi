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
using DBApi.Models;

namespace DBApi.Controllers
{
    [Authorize]
    public class CatalogsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Catalogs
        public IQueryable<CatalogModel> GetCatalogs()
        {
            return db.Catalogs;
        }

        // GET: api/Catalogs/5
        [ResponseType(typeof(CatalogModel))]
        public IHttpActionResult GetCatalog(Guid id)
        {
            CatalogModel catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return NotFound();
            }

            return Ok(catalog);
        }

        // PUT: api/Catalogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCatalog(Guid id, CatalogModel catalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catalog.Id)
            {
                return BadRequest();
            }

            db.Entry(catalog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogExists(id))
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

        // POST: api/Catalogs
        [ResponseType(typeof(CatalogModel))]
        public IHttpActionResult PostCatalog(CatalogModel catalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Catalogs.Add(catalog);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CatalogExists(catalog.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = catalog.Id }, catalog);
        }

        // DELETE: api/Catalogs/5
        [ResponseType(typeof(CatalogModel))]
        public IHttpActionResult DeleteCatalog(Guid id)
        {
            CatalogModel catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return NotFound();
            }

            db.Catalogs.Remove(catalog);
            db.SaveChanges();

            return Ok(catalog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatalogExists(Guid id)
        {
            return db.Catalogs.Count(e => e.Id == id) > 0;
        }
    }
}