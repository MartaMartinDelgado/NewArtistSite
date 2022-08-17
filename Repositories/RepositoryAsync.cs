using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        //Using Dependency Injection to access the artist context
        private readonly ArtistContext _artistContext;
        public RepositoryAsync(ArtistContext artistContext)
        {
            _artistContext = artistContext;
        }

        public IQueryable<T> Entities => _artistContext.Set<T>();

        public Task DeleteAsync(T entity)
        {
            _artistContext.Set<T>().Remove(entity);
            _artistContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _artistContext.Set<T>().FindAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _artistContext.Set<T>().AddAsync(entity);
            await _artistContext.SaveChangesAsync();
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            _artistContext.Entry(entity).CurrentValues.SetValues(entity);
            _artistContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
