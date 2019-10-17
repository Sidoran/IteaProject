using IteaProject.Models.Abstract;
using IteaProject.Models.Database;
using IteaProject.Models.Entities;
using IteaProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteaProject.Services
{
    public class EventService:IService<Event>
    {
        public EventService (ProjectDbContext dbContext)
        {
            Repository = new ProjectRepository<Event>(dbContext);
        }

        public ProjectRepository<Event> Repository { get; set; }

        public async Task Create(Event item)
        {
            await Repository.CreateAsync(item);
        }

        public async Task Delete(Event item)
        {
            await Repository.RemoveAsync(item);
        }

        public async Task<Event> FindById(int id)
        {
            return await Repository.FindById(id);
        }

        public async Task<List<Event>> GetAll()
        {
            return await Repository.GetAll().ToListAsync();
        }

        public IQueryable<Event> GetQuery()
        {
            return Repository.GetAll();
        }

        public async Task<Event> Update(int id, Event updatedItem)
        {
            await Repository.UpdateAsync(updatedItem);
            return updatedItem;
        }

    }
}
