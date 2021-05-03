using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class UserApplicationRepository : IUserApplicationRepository
    {
        private readonly DbSet<UserApplication> _currentRepo;

        public UserApplicationRepository(UnitedAppContext context)
        {
            _currentRepo = context.UserApplications;
        }

        public async Task CreateAsync(UserApplication entity)
        {
            await _currentRepo.AddAsync(entity);
        }

        public async Task<List<UserApplication>> GetAllAsync()
        {
            return await _currentRepo.Include(e => e.Regions).ToListAsync();
        }
    }
}
