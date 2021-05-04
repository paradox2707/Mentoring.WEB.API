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
    public class RegionRepository : IRegionRepository
    {
        private readonly DbSet<Region> _currentRepo;

        public RegionRepository(UnitedAppContext context)
        {
            _currentRepo = context.Regions;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _currentRepo.Include(e => e.UserApplications).ToListAsync();
        }

        public async Task<Region> GetByAsync(Expression<Func<Region, bool>> expression)
        {
            return await _currentRepo.FirstOrDefaultAsync(expression);
        }
    }
}
