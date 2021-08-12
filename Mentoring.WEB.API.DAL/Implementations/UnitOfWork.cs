using Mentoring.WEB.API.DAL.Interfaces;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly UnitedAppContext context;
        private IUniversityRepository _universityRepo;
        private ISpecialityRepository _specialityRepo;
        private IUserApplicationRepository _userApplicationRepo;
        private IRegionRepository _regionRepo;
        private IProfessionalDirectionRepository _proDirectionRepo;
        private IStatisticsRepository _statisticsRepo;

        public UnitOfWork(UnitedAppContext context)
        {
            this.context = context;
        }

        public IUniversityRepository UniversityRepository
        {
            get
            {
                if (_universityRepo is null)
                {
                    _universityRepo = new UniversityRepository(context);
                }
                return _universityRepo;
            }
        }

        public ISpecialityRepository SpecialityRepository
        {
            get
            {
                if (_specialityRepo is null)
                {
                    _specialityRepo = new SpecialityRepository(context);
                }
                return _specialityRepo;
            }
        }

        public IUserApplicationRepository UserApplicationRepository
        {
            get
            {
                if (_userApplicationRepo is null)
                {
                    _userApplicationRepo = new UserApplicationRepository(context);
                }
                return _userApplicationRepo;
            }
        }

        public IRegionRepository RegionRepository
        {
            get
            {
                if (_regionRepo is null)
                {
                    _regionRepo = new RegionRepository(context);
                }
                return _regionRepo;
            }
        }

        public IProfessionalDirectionRepository ProfessionalDirectionRepository
        {
            get
            {
                if (_proDirectionRepo is null)
                {
                    _proDirectionRepo = new ProfessionalDirectionRepository(context);
                }
                return _proDirectionRepo;
            }
        }

        public IStatisticsRepository StatisticsRepository
        {
            get
            {
                if (_statisticsRepo is null)
                {
                    _statisticsRepo = new StatisticsRepository(context);
                }
                return _statisticsRepo;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
