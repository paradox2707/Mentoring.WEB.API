using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly UnitedAppContext context;
        readonly IMapper _mapper;
        private IStatisticsRepository _statisticsRepo;

        public UnitOfWork(UnitedAppContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public IStatisticsRepository StatisticsRepository
        {
            get
            {
                if (_statisticsRepo is null)
                {
                    _statisticsRepo = new StatisticsRepository(context, _mapper);
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
