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
        private const string sqlAnd = " AND ";
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

        public async Task<List<University>> GetAllBySql(UniversityFilterDao filter)
        {
            var neededEnd = false;
            var sqlParametrs = new List<object>();
            var orderOfStringParamentrs = 0;
            var result = @"SELECT [Universities].[Id] as Id
                , [Universities].[ExternalId] as ExternalId
                , [Universities].[IsGoverment] as IsGoverment
                , [Universities].[Name] as Name
                , [Universities].[RegionId] as RegionId
                , [Universities].[ShortName] as ShortName  FROM Universities ";
            if (filter.Region != null)
            {
                result += "INNER JOIN (SELECT * FROM Regions WHERE [Name] = {" +
                    $"{orderOfStringParamentrs}" +
                    "}) as RegionTbl on RegionTbl.Id = Universities.RegionId";
                sqlParametrs.Add(filter.Region);
                orderOfStringParamentrs++;
            }

            result += filter.NeededConditionce ? " WHERE " : string.Empty; 

            if (filter.SearchText != null)
            {
                result += neededEnd ? sqlAnd : string.Empty;
                neededEnd = true;
                result += "Universities.[Name] Like CONCAT(CONCAT('%',{" +
                    $"{orderOfStringParamentrs}" +
                    "}),'%') ";
                sqlParametrs.Add(filter.SearchText);
                orderOfStringParamentrs++;
            }

            if (filter.IsGoverment.HasValue)
            {
                result += neededEnd ? sqlAnd : string.Empty;
                neededEnd = true;
                result += "Universities.[IsGoverment] = {" + $"{orderOfStringParamentrs}" + "} ";
                sqlParametrs.Add(Convert.ToInt32(filter.IsGoverment.Value));
                orderOfStringParamentrs++;
            }

            return await _currentRepo.FromSqlInterpolated(FormattableStringFactory.Create(result, sqlParametrs.ToArray())).Include(e => e.Region).ToListAsync();
        }

        public async Task<List<University>> GetAllWithSpecialiesAsync()
        {
            return await _currentRepo.Include(e => e.Specialities).ToListAsync();
        }
    }
}
