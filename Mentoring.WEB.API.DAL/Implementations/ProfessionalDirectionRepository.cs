using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class ProfessionalDirectionRepository : IProfessionalDirectionRepository
    {
        private readonly DbSet<ProfessionalDirection> _currentRepo;

        public ProfessionalDirectionRepository(UnitedAppContext context)
        {
            _currentRepo = context.ProfessionalDirections;
        }

        public async Task<List<ProfessionalDirection>> GetAllAsync()
        {
            return await _currentRepo.Include(e => e.UserApplications).ToListAsync();
        }

        public async Task<ProfessionalDirection> GetByAsync(Expression<Func<ProfessionalDirection, bool>> expression)
        {
            return await _currentRepo.FirstOrDefaultAsync(expression);
        }
    }
}
