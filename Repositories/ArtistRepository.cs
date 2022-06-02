using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IRepositoryAsync<Artist> _repository; 
        public ArtistRepository(IRepositoryAsync<Artist> repository)
        {
            _repository = repository;
        }

        public IQueryable<Artist> Artists => _repository.Entities;

        public async Task DeleteAsync(Artist artist)
        {
            await _repository.DeleteAsync(artist);
        }

        public async Task<Artist> GetByIdAsync(int artistId)
        {
            return await _repository.GetByIdAsync(artistId);
        }

        public async Task<Artist> InsertAsync(Artist artist)
        {
            await _repository.InsertAsync(artist);
            return artist;
        }

        public async Task UpdateAsync(Artist artist)
        {
            await _repository.UpdateAsync(artist);
        }
    }
}
