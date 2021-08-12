using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUniversityRepository UniversityRepository { get; }

        ISpecialityRepository SpecialityRepository { get; }

        IUserApplicationRepository UserApplicationRepository { get; }

        IRegionRepository RegionRepository { get; }

        IProfessionalDirectionRepository ProfessionalDirectionRepository { get; }

        IStatisticsRepository StatisticsRepository { get; }

        Task<int> SaveAsync();
    }
}
