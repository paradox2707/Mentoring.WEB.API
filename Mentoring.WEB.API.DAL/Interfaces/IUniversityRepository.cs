using Mentoring.WEB.API.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface IUniversityRepository
    {
        Task<List<University>> GetAllAsync();
        Task<List<University>> GetAllWithSpecialiesAsync();
    }
}
