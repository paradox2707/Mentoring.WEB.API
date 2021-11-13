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

        public async Task<List<UniversityModel>> GetAllForUserApplicationBySql(UniversityFilterForUserApplication filter)
        {
            var daoFilter = _mapper.Map<UniversityFilterForUserApplication, UniversityFilterForUserApplicationInSql>(filter);
            var daos = await _currentRepo
                .FromSqlInterpolated(CreateQueryWithConditionsForUserApplication(daoFilter))
                .Include(e => e.Region)
                .ToListAsync();
            return _mapper.Map<List<University>, List<UniversityModel>>(daos);
        }

        public async Task<List<UniversityModel>> GetAllForUserApplicationValidationBySql(UserApplicationModel filter)
        {
            var daoFilter = _mapper.Map<UserApplicationModel, UniversityFilterForUserApplicationValidationInSql>(filter);
            var daos = await _currentRepo
                .FromSqlInterpolated(CreateQueryWithConditionsForUserApplicationValidation(daoFilter))
                .Include(e => e.Region)
                .ToListAsync();
            return _mapper.Map<List<University>, List<UniversityModel>>(daos);
        }

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
    }
}
