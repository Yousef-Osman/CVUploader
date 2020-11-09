using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVUploader.Repositoris
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAllAsync();
    }
}
