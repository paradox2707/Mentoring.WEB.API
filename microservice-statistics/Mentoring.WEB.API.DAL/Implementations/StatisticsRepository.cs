using AutoMapper;
using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using Mentoring.WEB.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private UnitedAppContext _context;
        private readonly IMapper _mapper;

        public StatisticsRepository(UnitedAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SummaryUserApplicationDashboardModel> GetSummaryUserApplicationDashboard()
        {
            var dao = await _context.Set<SummaryUserApplicationDashboard>().FromSqlRaw(GetQueryForSummaryUserApplicationDashboard()).FirstOrDefaultAsync();
            return _mapper.Map<SummaryUserApplicationDashboard, SummaryUserApplicationDashboardModel>(dao);
        }

        public async Task<IEnumerable<SummaryUserApplicationByProfessionalDirectionDashboardModel>> GetSummaryUserApplicationByProfessionalDirectionDashboard()
        {
            var dao = await _context.Set<SummaryUserApplicationByProfessionalDirectionDashboard>().FromSqlRaw(GetQueryForSummaryUserApplicationByProfessionalDirectionDashboard()).ToListAsync();
            return _mapper.Map<IEnumerable<SummaryUserApplicationByProfessionalDirectionDashboard>, IEnumerable<SummaryUserApplicationByProfessionalDirectionDashboardModel>>(dao);
        }

        private static string GetQueryForSummaryUserApplicationDashboard() => 
            @"SELECT Count(*) as TotalAmount
,AVG(AverageMark) as AvarageMark
,MIN(AverageMark) as MinMark
,MAX(AverageMark) as MaxMark 
FROM UserApplications";

        private static string GetQueryForSummaryUserApplicationByProfessionalDirectionDashboard() =>
    @"SELECT ProfessionalDirections.[Name] as ProfessionalDirection,
COUNT(*) as UserApplicationAmount
FROM ProfessionalDirections
LEFT JOIN ProfessionalDirectionUserApplication PDUA ON PDUA.ProfessionalDirectionsId = ProfessionalDirections.Id
GROUP BY ProfessionalDirections.[Name]";

    }
}
