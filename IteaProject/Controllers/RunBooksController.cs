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
    public class RunBooksController : ControllerBase
    {
        readonly IService<RunBook> service;

        public RunBooksController(IService<RunBook> service)
        {
            this.service = service;
        }

        // GET: api/RunBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RunBook>>> GetRunBooks()
        {
            return await service.GetAll();
        }

        // GET: api/RunBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RunBook>> GetRunBook(int id)
        {
            var runBook = await service.FindById(id);

            if (runBook == null)
            {
                return NotFound();
            }

            return runBook;
        }

        // PUT: api/RunBooks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRunBook(int id, [FromBody]RunBook runBook)
        {
            if (id != runBook.Id)
            {
                return BadRequest();
            }
            runBook.WhenChanged = DateTime.UtcNow;
            await service.Update(id, runBook);
            return NoContent();
        }

        // POST: api/RunBooks
        [HttpPost]
        public async Task<ActionResult<RunBook>> PostRunBook([FromBody]RunBook runBook)
        {
            DateTime t = DateTime.UtcNow;

            runBook.WhenChanged = t;
            runBook.WhenCreated = t;
            runBook.IsActive = true;
            await service.Create(runBook);
            return CreatedAtAction("GetRunBook", new { id = runBook.Id }, runBook);
        }

        // DELETE: api/RunBooks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RunBook>> DeleteRunBook(int id)
        {
            var runBook = await service.FindById(id);
            if (runBook == null)
            {
                return NotFound();
            }

            await service.Delete(runBook);
            return runBook;
        }

        private bool RunBookExists(int id)
        {
            return service.GetAll().Result.Any(rb => rb.Id == id);
        }
    }
}
