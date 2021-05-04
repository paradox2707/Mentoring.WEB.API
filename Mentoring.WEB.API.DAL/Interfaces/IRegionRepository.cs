using Mentoring.WEB.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region> GetByAsync(Expression<Func<Region, bool>> expression);
    }
}
