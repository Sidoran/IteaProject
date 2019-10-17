using IteaProject.Models.Abstract;
using IteaProject.Models.Database;
using IteaProject.Models.Entities;
using IteaProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteaProject.Services
{
    public class AgentService : IService<Agent>
    {
        public AgentService(ProjectDbContext dbContext)
        {
            Repository = new ProjectRepository<Agent>(dbContext);
        }

        public ProjectRepository<Agent> Repository { get ; set ; }

        public async Task Create(Agent item)
        {
            if (item.IpAddress == "" || item.Name == "") { //return new StatusCodeResult(StatusCodes.Status500InternalServerError); 
            }
            else { await Repository.CreateAsync(item); }
        }

        public async Task Delete(Agent item)
        {
            await Repository.RemoveAsync(item);
        }

        public async Task<Agent> FindById(int id)
        {
            return await Repository.FindById(id);
        }

        public async Task<List<Agent>> GetAll()
        {
            return await Repository.GetAll().ToListAsync();
        }

        public IQueryable<Agent> GetQuery()
        {
            return Repository.GetAll();
        }

        public async Task<Agent> Update(int id, Agent updatedItem)
        {
            await Repository.UpdateAsync(updatedItem);
            return updatedItem;
        }
    }
}
