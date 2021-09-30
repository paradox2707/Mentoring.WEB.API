using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Interfaces.DAL
{
    public interface IUnitOfWork
    {
        IUniversityRepository UniversityRepository { get; }

        ISpecialityRepository SpecialityRepository { get; }

        IRegionRepository RegionRepository { get; }

        IProfessionalDirectionRepository ProfessionalDirectionRepository { get; }

        Task<int> SaveAsync();
    }
}
