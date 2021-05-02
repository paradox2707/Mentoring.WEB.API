using Mentoring.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.Client.Abstract
{
    public interface IRepository
    {
        Task<List<UniversityModel>> GetUniversitiesAsync();
        Task<List<UniversityModel>> GetUniversitiesWithSpecialitiesAsync();
        Task<List<SpecialityModel>> GetSpecialitiesAsync();
        Task CreateApplication(ApplicationModel dto);
    }
}