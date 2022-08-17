using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.Repositories
{
    public interface IContentRepository
    {
        IQueryable<Content> Contents { get; }
        Task<Content> GetByIdAsync(int contentId);
        Task<Content> InsertAsync(Content content);
        Task UpdateAsync(Content content);
        Task DeleteAsync(Content content);
    }
}
