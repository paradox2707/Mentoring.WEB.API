using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class SpecialityService : ISpecialityService
    {
        readonly IUnitOfWork _uow;
        readonly ISpecialityRepository _specialityRepo;
        readonly IMapper _mapper;

        public SpecialityService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _specialityRepo = uow.SpecialityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SpecialityModel>> GetAllAsync()
        {
            var daos = await _specialityRepo.GetAllAsync();

            return _mapper.Map<List<Speciality>, IEnumerable<SpecialityModel>>(daos);
        }
    }
}
