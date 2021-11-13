using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces.DAL
{
    public interface IUnitOfWork
    {
        IStatisticsRepository StatisticsRepository { get; }

        Task<int> SaveAsync();
    }
}
