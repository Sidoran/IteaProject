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
    public class AgentsController : ControllerBase
    {
        readonly IService<Agent> service;

        public AgentsController(IService<Agent> service)
        {
            this.service = service;
        }

        // GET: api/Agents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgents()
        {
            return await service.GetAll();
        }

        // GET: api/Agents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agent>> GetAgent(int id)
        {
            var agent = await service.FindById(id);

            if (agent == null)
            {
                return NotFound();
            }

            return agent;
        }

        // PUT: api/Agents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgent(int id, [FromBody] Agent agent)
        {
            if (id != agent.Id)
            {
                return BadRequest();
            }
          await service.Update(id, agent);
          return NoContent();
        }

        // POST: api/Agents
        [HttpPost]
        public async Task<ActionResult<Agent>> PostAgent([FromBody]Agent agent)
        {
            await service.Create(agent);

            return CreatedAtAction("GetAgent", new { id = agent.Id }, agent);
        }

        // DELETE: api/Agents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agent>> DeleteAgent(int id)
        {
            var agent = await service.FindById(id);
            if (agent == null)
            {
                return NotFound();
            }
         
            await service.Delete(agent);
            return agent;
        }


        private bool AgentExists(int id)
        {
            return service.GetAll().Result.Any(a => a.Id == id);
        }
    }
}
