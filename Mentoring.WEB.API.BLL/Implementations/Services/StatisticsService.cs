using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class StatisticsService: IStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepo;
        private readonly IMapper _mapper;

        public StatisticsService(IUnitOfWork uow, IMapper mapper)
        {
            _statisticsRepo = uow.StatisticsRepository;
            _mapper = mapper;
        }

        public async Task<SummaryUserApplicationDashboardModel> GetSummaryUserApplicationDashboard()
        {
            var dao = await _statisticsRepo.GetSummaryUserApplicationDashboard();
            return _mapper.Map<SummaryUserApplicationDashboard, SummaryUserApplicationDashboardModel>(dao);
        }
    }
}
