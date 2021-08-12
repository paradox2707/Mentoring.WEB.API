using Mentoring.WEB.API.Common.DTO;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces
{
    public interface IStatisticsService
    {
        Task<SummaryUserApplicationDashboardModel> GetSummaryUserApplicationDashboard();
    }
}