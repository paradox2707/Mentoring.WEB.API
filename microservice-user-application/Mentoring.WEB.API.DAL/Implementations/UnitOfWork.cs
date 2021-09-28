using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly UnitedAppContext context;
        readonly IMapper _mapper;
        private IUniversityRepository _universityRepo;
        private IUserApplicationRepository _userApplicationRepo;
        private IRegionRepository _regionRepo;
        private IProfessionalDirectionRepository _proDirectionRepo;

        public UnitOfWork(UnitedAppContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public IUniversityRepository UniversityRepository
        {
            get
            {
                if (_universityRepo is null)
                {
                    _universityRepo = new UniversityRepository(context, _mapper);
                }
                return _universityRepo;
            }
        }

        public IUserApplicationRepository UserApplicationRepository
        {
            get
            {
                if (_userApplicationRepo is null)
                {
                    _userApplicationRepo = new UserApplicationRepository(context, _mapper);
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
                    _regionRepo = new RegionRepository(context, _mapper);
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
                    _proDirectionRepo = new ProfessionalDirectionRepository(context, _mapper);
                }
                return _proDirectionRepo;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
