using Mentoring.WEB.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly UnitedAppContext context;
        private IUniversityRepository articleRepo;

        public UnitOfWork(UnitedAppContext context)
        {
            this.context = context;
        }

        public IUniversityRepository UniversityRepository
        {
            get
            {
                if (this.articleRepo is null)
                {
                    this.articleRepo = new UniversityRepository(context);
                }
                return articleRepo;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
