using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly DbSet<Speciality> _currentRepo;

        public SpecialityRepository(UnitedAppContext context)
        {
            _currentRepo = context.Specialities;
        }

        public async Task<List<Speciality>> GetAllAsync()
        {
            return await _currentRepo.ToListAsync();
        }
    }
}
