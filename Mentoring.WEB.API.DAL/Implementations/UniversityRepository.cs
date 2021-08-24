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

        public async Task<List<University>> GetAllBySql(UniversityFilterInSql filter) =>
            await _currentRepo
            .FromSqlInterpolated(CreateQueryWithConditions(filter))
            .Include(e => e.Region)
            .ToListAsync();

        public async Task<List<University>> GetAllForUserApplicationBySql(UniversityFilterForUserApplicationInSql filter) =>
            await _currentRepo
            .FromSqlInterpolated(CreateQueryWithConditionsForUserApplication(filter))
            .Include(e => e.Region)
            .ToListAsync();

        public async Task<List<University>> GetAllForUserApplicationValidationBySql(UniversityFilterForUserApplicationValidationInSql filter) =>
            await _currentRepo
            .FromSqlInterpolated(CreateQueryWithConditionsForUserApplicationValidation(filter))
            .Include(e => e.Region)
            .ToListAsync();

        private FormattableString CreateQueryWithConditionsForUserApplicationValidation(UniversityFilterForUserApplicationValidationInSql filter)
        {
            string sqlQuery = $@"
                SELECT 
                  [Universities].[Id] as Id
                , [Universities].[ExternalId] as ExternalId
                , [Universities].[IsGoverment] as IsGoverment
                , [Universities].[Name] as Name
                , [Universities].[RegionId] as RegionId
                , [Universities].[ShortName] as ShortName 
                , [Universities].[AverageMark] as AverageMark
                FROM Universities
                INNER JOIN (SELECT * FROM Regions 
                WHERE [Name] IN ({filter.FormatNumbersForRegionsForSqlQuery})
                ) as RegionTbl ON RegionTbl.Id = Universities.RegionId
                INNER JOIN ( SELECT * FROM SpecialityUniversity
                    INNER JOIN (SELECT Specialities.* FROM Specialities 
                        INNER JOIN (SELECT * FROM ProfessionalDirections 
                        WHERE [Name] IN ({filter.FormatNumbersForProfessionalDirectionsForSqlQuery})
                        ) as ProfessionalDirectionTbl ON ProfessionalDirectionTbl.Id = Specialities.ProfessionalDirectionId
                    ) as SpecialitiesTbl ON SpecialitiesTbl.Id = SpecialityUniversity.SpecialitiesId
                ) as SpecialityTbl ON SpecialityTbl.Id = Universities.RegionId";

            return FormattableStringFactory.Create(sqlQuery, filter.GetParametersForSql());
        }

        private FormattableString CreateQueryWithConditionsForUserApplication(UniversityFilterForUserApplicationInSql filter)
        {
            string sqlQuery = $@"
                SELECT 
                  [Universities].[Id] as Id
                , [Universities].[ExternalId] as ExternalId
                , [Universities].[IsGoverment] as IsGoverment
                , [Universities].[Name] as Name
                , [Universities].[RegionId] as RegionId
                , [Universities].[ShortName] as ShortName 
                , [Universities].[AverageMark] as AverageMark
                FROM Universities
                INNER JOIN (SELECT * FROM Regions 
                WHERE [Name] IN ({filter.GetFormatNumbersForSqlQuery()})
                ) as RegionTbl ON RegionTbl.Id = Universities.RegionId
                WHERE AverageMark <= {{{filter.ParameterNumberForAvarageMark}}}";

            return FormattableStringFactory.Create(sqlQuery, filter.GetParametersForSql());
        }

        public async Task<List<University>> GetAllWithSpecialiesAsync()
        {
            return await _currentRepo.Include(e => e.Specialities).ToListAsync();
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
