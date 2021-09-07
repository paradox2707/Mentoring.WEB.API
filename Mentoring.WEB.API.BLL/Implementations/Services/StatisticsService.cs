using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class StatisticsService: IStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepo;

        public StatisticsService(IUnitOfWork uow)
        {
            _statisticsRepo = uow.StatisticsRepository;
        }

        public async Task<SummaryUserApplicationDashboardModel> GetSummaryUserApplicationDashboard()
        {
            return await _statisticsRepo.GetSummaryUserApplicationDashboard();
        }

        public async Task<IEnumerable<SummaryUserApplicationByProfessionalDirectionDashboardModel>> SummaryUserApplicationByProfessionalDirectionDashboard()
        {
            return await _statisticsRepo.GetSummaryUserApplicationByProfessionalDirectionDashboard();
        }
    }
}
