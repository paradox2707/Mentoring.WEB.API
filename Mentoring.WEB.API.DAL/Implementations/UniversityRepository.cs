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
    public class UniversityRepository : IUniversityRepository
    {
        readonly UnitedAppContext _context;
        private readonly DbSet<University> _currentRepo;

        public UniversityRepository(UnitedAppContext context)
        {
            this._context = context;
            this._currentRepo = context.Universities;
        }

        public async Task CreateAsync(University entity)
        {
            await _currentRepo.AddAsync(entity);
        }

        public async Task<List<University>> GetAllAsync()
        {
            return await _currentRepo.ToListAsync();
        }

        public async Task UpdateAsync(University entity)
        {
            var itemExist = await _currentRepo.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (itemExist != null)
            {
                _currentRepo.Update(entity);
            }
        }

        public void UpdateList(IEnumerable<University> entity)
        {            
            _currentRepo.UpdateRange(entity);
        }
    }
}
