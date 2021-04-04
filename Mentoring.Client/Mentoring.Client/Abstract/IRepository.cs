using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.Client.Abstract
{
    internal interface IRepository
    {
        Task<List<UniversityModel>> GetUniversityAsync();
    }
}