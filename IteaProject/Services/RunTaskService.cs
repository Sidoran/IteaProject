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
    public class RunTaskService : IService<RunTask>
    {
        public RunTaskService(ProjectDbContext dbContext)
        {
            Repository = new ProjectRepository<RunTask>(dbContext);
        }

        public ProjectRepository<RunTask> Repository { get ; set ; }

        public async Task Create(RunTask item)
        {
            await Repository.CreateAsync(item);
        }

        public async Task Delete(RunTask item)
        {
            await Repository.RemoveAsync(item);
        }

        public async Task<RunTask> FindById(int id)
        {
            return await Repository.FindById(id);
        }

        public async Task<List<RunTask>> GetAll()
        {
            return await Repository.GetAll().ToListAsync();
        }

        public IQueryable<RunTask> GetQuery()
        {
            return Repository.GetAll();
        }

        public async Task<RunTask> Update(int id, RunTask updatedItem)
        {
            await Repository.UpdateAsync(updatedItem);
            return updatedItem;
        }
    }
}
