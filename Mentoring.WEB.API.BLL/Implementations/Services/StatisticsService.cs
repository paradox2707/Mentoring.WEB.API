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

        public async Task<IEnumerable<SummaryUserApplicationByProfessionalDirectionDashboardModel>> SummaryUserApplicationByProfessionalDirectionDashboard()
        {
            var dao = await _statisticsRepo.GetSummaryUserApplicationByProfessionalDirectionDashboard();
            return _mapper.Map<IEnumerable<SummaryUserApplicationByProfessionalDirectionDashboard>, IEnumerable<SummaryUserApplicationByProfessionalDirectionDashboardModel>>(dao);
        }
    }
}
