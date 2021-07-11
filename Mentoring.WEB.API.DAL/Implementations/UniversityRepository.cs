using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Filters;
using Mentoring.WEB.API.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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

        public async Task<List<University>> GetAllBySql(UniversityFilterForSql filter) => 
            await _currentRepo
            .FromSqlInterpolated(CreateQueryWithConditional(filter))
            .Include(e => e.Region)
            .ToListAsync();

        public async Task<List<University>> GetAllWithSpecialiesAsync()
        {
            return await _currentRepo.Include(e => e.Specialities).ToListAsync();
        }

        private static FormattableString CreateQueryWithConditional(UniversityFilterForSql filter)
        {
            string sqlQuery;
            if (filter.ComplexQuery)
            {
                sqlQuery = @$"SELECT
                    {filter.SelectedFieldsForSql}
                    {(!string.IsNullOrWhiteSpace(filter.Region) ? filter.RegionConditionForSqlInnerJoinApproach : string.Empty)} 
                    UNION
                    SELECT
                    {filter.SelectedFieldsForSql}
                    {filter.Where} 
                    {(!string.IsNullOrWhiteSpace(filter.SearchText) ? filter.SearchTextConditionForSql : string.Empty)}
                    {(filter.IsGoverment != null ? filter.GovermentConditionForSql : string.Empty)}";
            }
            else
            {
                sqlQuery = @$"SELECT
                    {filter.SelectedFieldsForSql}
                    {(!string.IsNullOrWhiteSpace(filter.Region) ? filter.RegionConditionForSqlInnerJoinApproach : string.Empty)}        
                    {filter.Where} 
                    {(!string.IsNullOrWhiteSpace(filter.SearchText) ? filter.SearchTextConditionForSql : string.Empty)}
                    {(filter.IsGoverment != null ? filter.GovermentConditionForSql : string.Empty)}";
            }

            var parametersData = filter.GetParametersSequence();
            for (int index = 0; index < parametersData.Count; index++)
            {
                sqlQuery = sqlQuery.Replace(parametersData.ElementAt(index).Key, index.ToString());
            }

            return FormattableStringFactory.Create(sqlQuery, parametersData.Values.ToArray());
        }
    }
}
