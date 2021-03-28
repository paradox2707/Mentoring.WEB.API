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
        Task<University> GetByIdAsync(int id);
        Task<University> GetByAsync(Expression<Func<University, bool>> expression);

        Task<List<University>> GetAllAsync();
        Task<List<University>> GetAllByAsync(Expression<Func<University, bool>> expression);

        Task CreateAsync(University entity);
        Task UpdateAsync();
        Task DeleteAsync();
    }
}
