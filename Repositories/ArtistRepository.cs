using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ArtistContext _context;
        private readonly IRepositoryAsync<Artist> _repository; 
        public ArtistRepository(IRepositoryAsync<Artist> repository, ArtistContext context)
        {
            _context = context;
            _repository = repository;
        }

        public IQueryable<Artist> Artists => _repository.Entities;

        public async Task DeleteAsync(Artist artist)
        {
            await _repository.DeleteAsync(artist);
        }

        public Artist GetById(Guid artistId)
        {
            return _context.Artists.FirstOrDefault(x => x.Id == artistId.ToString());
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
