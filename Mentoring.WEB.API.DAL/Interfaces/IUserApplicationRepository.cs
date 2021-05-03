using Mentoring.WEB.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface IUserApplicationRepository
    {
        Task<List<UserApplication>> GetAllAsync();
        Task CreateAsync(UserApplication entity);
    }
}
