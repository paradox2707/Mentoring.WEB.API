using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Filters;
using Mentoring.WEB.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            return await _currentRepo.Include(e => e.Regions).Include(e => e.ProfessionalDirections).ToListAsync();
        }

        public async Task<List<UserApplication>> GetAllBySql(UserApplicationFilterInSql filter) =>
            await _currentRepo
            .FromSqlInterpolated(CreateQueryWithConditions(filter))
            .Include(e => e.Regions)
            .Include(e => e.ProfessionalDirections)            
            .ToListAsync();

        private FormattableString CreateQueryWithConditions(UserApplicationFilterInSql filter)
        {
            var sqlQuery = @$"SELECT
                    {filter.SelectedFieldsForSql}
                    {filter.RegionConditionForSql} 
                    {filter.ProfessionalDirectionConditionForSql}
                    {filter.Where} 
                    {filter.SearchTextConditionForSql}";

            var parametersData = filter.GetParametersSequence();
            for (int index = 0; index < parametersData.Count; index++)
            {
                sqlQuery = sqlQuery.Replace(parametersData.ElementAt(index).Key, index.ToString());
            }

            return FormattableStringFactory.Create(sqlQuery, parametersData.Values.ToArray());
        }
    }
}
