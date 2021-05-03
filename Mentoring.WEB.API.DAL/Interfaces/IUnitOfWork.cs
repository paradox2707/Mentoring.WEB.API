using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUniversityRepository UniversityRepository { get; }

        ISpecialityRepository SpecialityRepository { get; }

        IUserApplicationRepository UserApplicationRepository { get; }

        IRegionRepository RegionRepository { get; }

        Task<int> SaveAsync();
    }
}
