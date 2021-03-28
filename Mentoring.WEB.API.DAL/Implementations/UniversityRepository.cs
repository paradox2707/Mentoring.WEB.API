using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class UniversityRepository : IUniversityRepository
    {
        readonly UnitedAppContext _context;
        private readonly DbSet<University> _currentRepo;

        public UniversityRepository(UnitedAppContext context)
        {
            this._context = context;
            this._currentRepo = context.Universities;
        }
        public Task CreateAsync(University entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<University>> GetAllAsync()
        {
            return await _currentRepo.ToListAsync();
        }

        public Task<List<University>> GetAllByAsync(Expression<Func<University, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<University> GetByAsync(Expression<Func<University, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<University> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
