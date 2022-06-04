using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistSite.Repositories
{
    interface IExperienceRepository
    {
        IQueryable<Experience> Experiences { get; }
        Task<Experience> GetByIdAsync(int experienceId);
        Task<Experience> InsertAsync(Experience experience);
        Task UpdateAsync(Experience experience);
        Task DeleteAsync(Experience experience);
    }
}
