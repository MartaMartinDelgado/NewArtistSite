using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.Repositories
{
    public interface IArtistRepository
    {
        IQueryable<Artist> Artists { get; }
        Artist GetById(Guid artistId);
        Task<Artist> InsertAsync(Artist artist);
        Task UpdateAsync(Artist artist);
        Task DeleteAsync(Artist artist);
    }
}
