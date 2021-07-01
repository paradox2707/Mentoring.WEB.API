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
        private const string fieldsOfUniversitiesForQuery =
            @"SELECT [Universities].[Id] as Id
                , [Universities].[ExternalId] as ExternalId
                , [Universities].[IsGoverment] as IsGoverment
                , [Universities].[Name] as Name
                , [Universities].[RegionId] as RegionId
                , [Universities].[ShortName] as ShortName  FROM Universities ";

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

        public async Task<List<University>> GetAllBySql(UniversityFilterDao filter) => 
            await _currentRepo
            .FromSqlInterpolated(CreateQueryWithConditional(filter))
            .Include(e => e.Region)
            .ToListAsync();

        private static FormattableString CreateQueryWithConditional(UniversityFilterDao filter)
        {
            var sqlQuery = string.Empty;
            var neededConjunction = false;     
            var orderOfStringParamentrs = 0; 
            var sqlParametrs = new List<object>();

            if (filter.Region != null)
            {
                sqlQuery = fieldsOfUniversitiesForQuery + GetQueryForRegions(ref orderOfStringParamentrs);
                sqlParametrs.Add(filter.Region);
                sqlQuery += filter.Conjunction.ToLower() == "or" 
                    ? $" UNION {fieldsOfUniversitiesForQuery}" 
                    : string.Empty;
            }
            else
            {
                sqlQuery = fieldsOfUniversitiesForQuery;
            }

            sqlQuery += filter.NeededCondition ? " WHERE " : string.Empty;

            if (filter.SearchText != null)
            {
                var textForConditional = $"Universities.[Name] Like CONCAT(CONCAT('%', {{{orderOfStringParamentrs++}}} ),'%') ";
                sqlQuery += PrepareConditionalForQuery(textForConditional, filter.ConjunctionForQuery, ref neededConjunction);
                sqlParametrs.Add(filter.SearchText);
            }

            if (filter.IsGoverment.HasValue)
            {
                var textForConditional = $"Universities.[IsGoverment] = {{{orderOfStringParamentrs++}}} ";
                sqlQuery += PrepareConditionalForQuery(textForConditional, filter.ConjunctionForQuery, ref neededConjunction);
                sqlParametrs.Add(Convert.ToInt32(filter.IsGoverment.Value));
            }

            return FormattableStringFactory.Create(sqlQuery, sqlParametrs.ToArray());
        }

        private static string PrepareConditionalForQuery(string textForConditional, string conjunction, ref bool neededConjunction)
        {
            var conditional = neededConjunction ? conjunction : string.Empty; 
            conditional += textForConditional;
            neededConjunction = true;
            return conditional;
        }

        private static string GetQueryForRegions(ref int orderOfStringParamentrs) => 
            "INNER JOIN (SELECT * FROM Regions WHERE [Name] = {" +
                $"{orderOfStringParamentrs++}" +
                "}) as RegionTbl on RegionTbl.Id = Universities.RegionId";


        public async Task<List<University>> GetAllWithSpecialiesAsync()
        {
            return await _currentRepo.Include(e => e.Specialities).ToListAsync();
        }
    }
}
