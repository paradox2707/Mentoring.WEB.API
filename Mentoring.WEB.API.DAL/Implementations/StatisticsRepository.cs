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
    public class StatisticsRepository : IStatisticsRepository
    {
        private UnitedAppContext _context;

        public StatisticsRepository(UnitedAppContext context)
        {
            _context = context;
        }

        public async Task<SummaryUserApplicationDashboard> GetSummaryUserApplicationDashboard() =>
            await _context.Set<SummaryUserApplicationDashboard>().FromSqlRaw(GetQueryForSummaryUserApplicationDashboard()).FirstOrDefaultAsync();

        private static string GetQueryForSummaryUserApplicationDashboard() => 
            @"SELECT Count(*) as TotalAmount
,AVG(AverageMark) as AvarageMark
,MIN(AverageMark) as MinMark
,MAX(AverageMark) as MaxMark 
FROM UserApplications";
    }
}
