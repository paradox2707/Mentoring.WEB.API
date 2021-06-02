using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return await _currentRepo.Include(e => e.Region).ToListAsync();
        }

        public async Task<List<University>> GetAllByAsync(Expression<Func<University, bool>> expression)
        {
            return await _currentRepo.Include(e => e.Region).Where(expression).ToListAsync();
        }

        public async Task<List<University>> GetAllWithSpecialiesAsync()
        {
            return await _currentRepo.Include(e => e.Specialities).Include(e => e.Region).ToListAsync();
        }
    }
}
