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
    public class TaskModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TaskModels
        public IQueryable<TaskModel> GetTaskModels()
        {
            return db.TaskModels;
        }

        // GET: api/TaskModels/5
        [ResponseType(typeof(TaskModel))]
        public IHttpActionResult GetTaskModel(Guid id)
        {
            TaskModel taskModel = db.TaskModels.Find(id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return Ok(taskModel);
        }

        // PUT: api/TaskModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaskModel(Guid id, TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskModel.Id)
            {
                return BadRequest();
            }

            db.Entry(taskModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskModelExists(id))
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

        // POST: api/TaskModels
        [ResponseType(typeof(TaskModel))]
        public IHttpActionResult PostTaskModel(TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskModels.Add(taskModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TaskModelExists(taskModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = taskModel.Id }, taskModel);
        }

        // DELETE: api/TaskModels/5
        [ResponseType(typeof(TaskModel))]
        public IHttpActionResult DeleteTaskModel(Guid id)
        {
            TaskModel taskModel = db.TaskModels.Find(id);
            if (taskModel == null)
            {
                return NotFound();
            }

            db.TaskModels.Remove(taskModel);
            db.SaveChanges();

            return Ok(taskModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskModelExists(Guid id)
        {
            return db.TaskModels.Count(e => e.Id == id) > 0;
        }
    }
}