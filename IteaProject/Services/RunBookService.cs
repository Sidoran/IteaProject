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
    public class RunBookService : IService<RunBook>

    {
        public RunBookService(ProjectDbContext dbContext)
        {
            Repository = new ProjectRepository<RunBook>(dbContext);
        }

        public ProjectRepository<RunBook> Repository { get; set ; }

        public async Task Create(RunBook item)
        {
            DateTime t = DateTime.UtcNow;
            item.WhenChanged = t;
            item.WhenCreated = t;
            await Repository.CreateAsync(item);
        }

        public async Task Delete(RunBook item)
        {
            await Repository.RemoveAsync(item);
        }

        public async Task<RunBook> FindById(int id)
        {
            return await Repository.FindById(id);
        }

        public async Task<List<RunBook>> GetAll()
        {
            return await Repository.GetAll().ToListAsync();
        }

        public IQueryable<RunBook> GetQuery()
        {
            return Repository.GetAll();
        }

        public async Task<RunBook> Update(int id, RunBook updatedItem)
        {
            updatedItem.WhenChanged = DateTime.UtcNow;
            await Repository.UpdateAsync(updatedItem);
            return updatedItem;
        }
        
    }
}
