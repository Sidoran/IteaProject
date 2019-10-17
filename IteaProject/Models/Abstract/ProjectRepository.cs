using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteaProject.Models.Interfaces;
using IteaProject.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IteaProject.Models.Abstract
{
    public class ProjectRepository<T>:IAsyncRepository<T> where T: class
    {
        private readonly ProjectDbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public ProjectRepository(ProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public async Task CreateAsync(T item)
        {
           await dbSet.AddAsync(item);
           await dbContext.SaveChangesAsync();
        }

        public Task<T> FindById(int id)
        {
            return dbSet.FindAsync(id);
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return dbSet.AsParallel().Where(predicate);
        }

        public async Task RemoveAsync(T item)
        {
            dbSet.Remove(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            dbContext.Update(item);
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
    }

}

