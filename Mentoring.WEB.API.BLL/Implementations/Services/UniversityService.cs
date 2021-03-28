using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _articleRepo;
        private readonly IMapper _mapper;

        public UniversityService(IUnitOfWork uow, IMapper mapper)
        {
            _articleRepo = uow.UniversityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UniversityModel>> GetAllAsync()
        {
            var daos = await _articleRepo.GetAllAsync();

            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }

    }
}
