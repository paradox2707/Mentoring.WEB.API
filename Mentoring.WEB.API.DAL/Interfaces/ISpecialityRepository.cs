using Mentoring.WEB.API.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface ISpecialityRepository
    {
        Task<List<Speciality>> GetAllAsync();
    }
}
