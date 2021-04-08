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
    public class SpecialityRepository : ISpecialityRepository
    {
        readonly UnitedAppContext _context;
        private readonly DbSet<Speciality> _currentRepo;

        public SpecialityRepository(UnitedAppContext context)
        {
            this._context = context;
            this._currentRepo = context.Specialities;
        }

        public async Task CreateAsync(Speciality entity)
        {
            await _currentRepo.AddAsync(entity);
        }

        public async Task<List<Speciality>> GetAllAsync()
        {
            return await _currentRepo.AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(Speciality entity)
        {
            var itemExist = await _currentRepo.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (itemExist != null)
            {
                _currentRepo.Update(entity);
            }
        }

        public void UpdateList(IEnumerable<Speciality> entity)
        {
            _currentRepo.UpdateRange(entity);
        }
    }
}
