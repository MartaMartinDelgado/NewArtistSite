using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.Repositories
{
    interface IArtistRepository
    {
        IQueryable<Artist> Artists { get; }
        Task<Artist> GetByIdAsync(int artistId);
        Task<Artist> InsertAsync(Artist artist);
        Task UpdateAsync(Artist artist);
        Task DeleteAsync(Artist artist);
    }
}
