using Mentoring.WEB.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface IUniversityRepository
    {
        Task<List<University>> GetAllAsync();
        Task CreateAsync(University entity);
        Task UpdateAsync(University entity);
        void UpdateList(IEnumerable<University> entity);
    }
}
