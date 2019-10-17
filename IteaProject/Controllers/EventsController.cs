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
    public class EventsController : ControllerBase
    {
        readonly IService<Event> service;

        public EventsController(IService<Event> service)
        {
            this.service = service;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await service.GetAll();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await service.FindById(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, [FromBody] Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }
           await service.Update(id, @event);
            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent([FromBody] Event @event)
        {
            await service.Create(@event);
            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            var @event = await service.FindById(id);
            if (@event == null)
            {
                return NotFound();
            }


            await service.Delete(@event);
            return @event;
        }

        private bool EventExists(int id)
        {
            return service.GetAll().Result.Any(e => e.Id==id);
        }
    }
}
