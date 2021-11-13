using AutoMapper;
using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.FilterModels;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Filters;
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
        readonly IMapper _mapper;

        public UniversityRepository(UnitedAppContext context, IMapper mapper)
        {
            _currentRepo = context.Universities;
            _mapper = mapper;
        }

        public async Task<List<UniversityModel>> GetAllAsync()
        {
            var daos = await _currentRepo.Include(e => e.Region).ToListAsync();
            return _mapper.Map<List<University>, List<UniversityModel>>(daos);
        }

        public async Task<List<UniversityModel>> GetAllBySql(UniversityFilter filter)
        {
            var daoFilter = _mapper.Map<UniversityFilter, UniversityFilterInSql>(filter);
            var daos = await _currentRepo
                .FromSqlInterpolated(CreateQueryWithConditions(daoFilter))
                .Include(e => e.Region)
                .ToListAsync();
            return _mapper.Map<List<University>, List<UniversityModel>>(daos);
        }

        public async Task<List<UniversityModel>> GetAllWithSpecialiesAsync()
        {
            var daos = await _currentRepo.Include(e => e.Specialities).ToListAsync();
            return _mapper.Map<List<University>, List<UniversityModel>>(daos);
        }

        private static FormattableString CreateQueryWithConditions(UniversityFilterInSql filter)
        {
            string sqlQuery;
            if (filter.ComplexQuery)
            {
                sqlQuery = @$"SELECT
                    {filter.SelectedFieldsForSql}
                    {filter.RegionConditionForSqlInnerJoinApproach} 
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
