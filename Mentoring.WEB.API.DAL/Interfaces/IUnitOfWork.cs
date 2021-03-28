using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUniversityRepository UniversityRepository { get; }

        public Task<int> SaveAsync();
    }
}
