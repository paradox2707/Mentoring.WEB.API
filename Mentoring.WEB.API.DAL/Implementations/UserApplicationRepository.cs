using AutoMapper;
using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.FilterModels;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
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
        private readonly UnitedAppContext _context;
        private readonly DbSet<UserApplication> _currentRepo;
        private readonly DbSet<Region> _regionRepo;
        private readonly DbSet<ProfessionalDirection> _proDirectionRepo;
        readonly IMapper _mapper;

        public UserApplicationRepository(UnitedAppContext context, IMapper mapper)
        {
            _context = context;
            _currentRepo = context.UserApplications;
            _regionRepo = context.Regions;
            _proDirectionRepo = context.ProfessionalDirections;
            _mapper = mapper;
        }

        public async Task CreateAsync(UserApplicationModel entity)
        {
            var dao = _mapper.Map<UserApplicationModel, UserApplication>(entity);
            foreach (var region in entity.Regions)
            {
                var daoRegion = await _regionRepo.FirstOrDefaultAsync(r => r.Name == region.Name);
                dao.Regions.Add(daoRegion);
            }
            foreach (var proDirection in entity.ProfessionalDirections)
            {
                var daoProDirection = await _proDirectionRepo.FirstOrDefaultAsync(pDir => pDir.Name == proDirection.Name);
                dao.ProfessionalDirections.Add(daoProDirection);
            }
            await _currentRepo.AddAsync(dao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserApplicationModel>> GetAllAsync()
        {
            var daos = await _currentRepo.Include(e => e.Regions).Include(e => e.ProfessionalDirections).ToListAsync();
            return _mapper.Map<IEnumerable<UserApplication>, List<UserApplicationModel>>(daos);
        }

        public async Task<List<UserApplicationModel>> GetAllBySql(UserApplicationFilter filter)
        {
            var daoFilter = _mapper.Map<UserApplicationFilter, UserApplicationFilterInSql>(filter);
            var daos = await _currentRepo
                .FromSqlInterpolated(CreateQueryWithConditions(daoFilter))
                .Include(e => e.Regions)
                .Include(e => e.ProfessionalDirections)
                .ToListAsync();
            return _mapper.Map<List<UserApplication>, List<UserApplicationModel>>(daos);
        }

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
