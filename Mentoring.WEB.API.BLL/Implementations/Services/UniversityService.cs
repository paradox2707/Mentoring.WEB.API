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
using System.Diagnostics;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class UniversityService : IUniversityService
    {
        readonly IUnitOfWork _uow;
        readonly IUniversityRepository _universityRepo;
        readonly IMapper _mapper;
        readonly IEdboService _edboService;

        public UniversityService(IUnitOfWork uow, IMapper mapper, IEdboService edboService)
        {
            _uow = uow;
            _universityRepo = uow.UniversityRepository;
            _mapper = mapper;
            _edboService = edboService;
        }

        public async Task<IEnumerable<UniversityModel>> GetAllAsync()
        {
            var daos = await _universityRepo.GetAllAsync();

            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }

        public async Task UpdateAllUniversitiesFromExternalSourceAsync()
        {
            var externalUniversities = await _edboService.GetAllUniversities();
            var dbUniversity = await _universityRepo.GetAllAsync();

            foreach (var item in externalUniversities)
            {
                item.Id = dbUniversity.FirstOrDefault(e => e.ExternalId.ToString() == item.ExternalId)?.Id ?? default;
            }
            var universitiesForUpdate = _mapper.Map<IEnumerable<EdboUniversityModel>, List<University>>(externalUniversities);

            _universityRepo.UpdateList(universitiesForUpdate);
            await _uow.SaveAsync();
        }
    }
}
