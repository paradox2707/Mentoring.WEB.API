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

        public async Task<List<Speciality>> GetAllAsync()
        {
            return await _currentRepo.ToListAsync();
        }
    }
}
