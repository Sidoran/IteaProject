using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IteaProject.Models.Interfaces
{
    interface IAsyncRepository<T>
    {
        Task CreateAsync(T item);
        Task<T> FindById(int id);
        IEnumerable<T> Get(Func<T, bool> predicate);
        IQueryable<T> GetAll();
        Task RemoveAsync(T item);
        Task UpdateAsync(T item);
    }
}
