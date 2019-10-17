using IteaProject.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteaProject.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        ProjectRepository<T> Repository { get; set; }
        Task<List<T>> GetAll();
        Task<T> FindById(int id);
        Task Create(T item);
        Task Delete(T item);
        Task<T> Update(int id, T updatedItem);
        IQueryable<T> GetQuery();
    }
}
