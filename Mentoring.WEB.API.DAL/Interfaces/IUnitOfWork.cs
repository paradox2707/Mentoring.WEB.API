using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUniversityRepository UniversityRepository { get; }

        ISpecialityRepository SpecialityRepository { get; }

        Task<int> SaveAsync();
    }
}
