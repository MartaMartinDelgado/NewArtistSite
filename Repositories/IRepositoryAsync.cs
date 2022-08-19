using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.Repositories
{
    public interface IRepositoryAsync<T> where T : class
    {
        IQueryable<T> Entities { get; }
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        void DeleteAsync(T entity);
    }
}
