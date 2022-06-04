using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly IRepositoryAsync<Experience> _repository;
        public ExperienceRepository(IRepositoryAsync<Experience> repository)
        {
            _repository = repository;
        }
        public IQueryable<Experience> Experiences => _repository.Entities;

        public async Task DeleteAsync(Experience experience)
        {
            await _repository.DeleteAsync(experience);
        }

        public async Task<Experience> GetByIdAsync(int experienceId)
        {
            return await _repository.GetByIdAsync(experienceId);
        }

        public async Task<Experience> InsertAsync(Experience experience)
        {
            await _repository.InsertAsync(experience);
            return experience;
        }

        public async Task UpdateAsync(Experience experience)
        {
            await _repository.UpdateAsync(experience);
        }
    }
}
