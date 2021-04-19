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
        private IUniversityRepository _universityRepo;
        private ISpecialityRepository _specialityRepo;

        public UnitOfWork(UnitedAppContext context)
        {
            this.context = context;
        }

        public IUniversityRepository UniversityRepository
        {
            get
            {
                if (this._universityRepo is null)
                {
                    this._universityRepo = new UniversityRepository(context);
                }
                return _universityRepo;
            }
        }

        public ISpecialityRepository SpecialityRepository
        {
            get
            {
                if (this._specialityRepo is null)
                {
                    this._specialityRepo = new SpecialityRepository(context);
                }
                return _specialityRepo;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
