using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly IRepositoryAsync<Content> _repository;
        public ContentRepository(IRepositoryAsync<Content> repository)
        {
            _repository = repository;
        }
        public IQueryable<Content> Contents => _repository.Entities;

        public void DeleteAsync(Content content)
        {
             _repository.DeleteAsync(content);
        }

        public async Task<Content> GetByIdAsync(int contentId)
        {
            return await _repository.GetByIdAsync(contentId);
        }

        public async Task<Content> InsertAsync(Content content)
        {
            await _repository.InsertAsync(content);
            return content;
        }

        public async Task UpdateAsync(Content content)
        {
            await _repository.UpdateAsync(content);
        }
    }
}
