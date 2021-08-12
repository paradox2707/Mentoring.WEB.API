using Mentoring.WEB.API.DAL.Entities;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<SummaryUserApplicationDashboard> GetSummaryUserApplicationDashboard();
    }
}