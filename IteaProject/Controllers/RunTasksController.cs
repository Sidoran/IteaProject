using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IteaProject.Models.Database;
using IteaProject.Models.Entities;
using IteaProject.Services.Interfaces;

namespace IteaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunTasksController : ControllerBase
    {
        readonly IService<RunTask> service;

        public RunTasksController(IService<RunTask> service)
        {
            this.service = service;
        }

        // GET: api/RunTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RunTask>>> GetRunTasks()
        {
            return await service.GetAll();
        }

        // GET: api/RunTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RunTask>> GetRunTask(int id)
        {
            var runTask = await service.FindById(id);

            if (runTask == null)
            {
                return NotFound();
            }

            return runTask;
        }

        // PUT: api/RunTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRunTask(int id, [FromBody]RunTask runTask)
        {
            if (id != runTask.Id)
            {
                return BadRequest();
            }
            runTask.WhenChanged = DateTime.UtcNow;
            await service.Update(id, runTask);
            return NoContent();
        }

        // POST: api/RunTasks
        [HttpPost]
        public async Task<ActionResult<RunTask>> PostRunTask([FromBody]RunTask runTask)
        {
            runTask.WhenCreated = DateTime.UtcNow;
            runTask.WhenChanged = DateTime.UtcNow;
            runTask.IsActive = true;
            await service.Create(runTask);
            return CreatedAtAction("GetRunTask", new { id = runTask.Id }, runTask);
        }

        // DELETE: api/RunTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RunTask>> DeleteRunTask(int id)
        {
            var runTask = await service.FindById(id);
            if (runTask == null)
            {
                return NotFound();
            }

            await service.Delete(runTask);
            return runTask;
        }

        private bool RunTaskExists(int id)
        {
            return service.GetAll().Result.Any(rt => rt.Id == id);
        }
    }
}
