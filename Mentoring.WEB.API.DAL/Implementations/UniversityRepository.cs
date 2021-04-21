using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly DbSet<University> _currentRepo;

        public UniversityRepository(UnitedAppContext context)
        {
            _currentRepo = context.Universities;
        }

        public async Task<List<University>> GetAllAsync()
        {
            return await _currentRepo.ToListAsync();
        }

        public async Task<List<University>> GetAllWithSpecialiesAsync()
        {
            return await _currentRepo.Include(e => e.Specialities).ToListAsync();
        }
    }
}
