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
        readonly ISpecialityRepository _specialityRepo;
        readonly IMapper _mapper;
        readonly IEdboService _edboService;

        public UniversityService(IUnitOfWork uow, IMapper mapper, IEdboService edboService)
        {
            _uow = uow;
            _universityRepo = uow.UniversityRepository;
            _specialityRepo = uow.SpecialityRepository;
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
            //var externalSpecialities = await _edboService.GetAllSpecialities();
            //var externalUniversities = await _edboService.GetAllUniversities();
            var externalUniversities = await _edboService.GetAllUniversitiesWithSpecialities();
            

            var allExternalSpecialities = externalUniversities.Where(e => e.Specialities != null).SelectMany(u => u.Specialities.ToList());
            var externalSpecialities = allExternalSpecialities
                .GroupBy(s => s.ExternalId)
                .Select(e => e.FirstOrDefault())
                .OrderBy(e => e.ExternalId);
            var dbSpecialities = await _specialityRepo.GetAllAsync();
            foreach (var speciality in externalSpecialities)
            {
                speciality.Id = dbSpecialities.FirstOrDefault(e => e.ExternalId.ToString() == speciality.ExternalId)?.Id ?? default;
            }
            var specialitiesForUpdate = _mapper.Map<IEnumerable<EdboSpecialityModel>, List<Speciality>>(externalSpecialities);

            _specialityRepo.UpdateList(specialitiesForUpdate);
            await _uow.SaveAsync();


            var dbUniversities = await _universityRepo.GetAllAsync();
            var dbSpecialitiesAfterUpdate = await _specialityRepo.GetAllAsync();
            foreach (var university in externalUniversities)
            {
                university.Id = dbUniversities.FirstOrDefault(e => e.ExternalId.ToString() == university.ExternalId)?.Id ?? default;
                if (university.Specialities == null)
                    continue;

                foreach (var speciality in university.Specialities)
                {
                    speciality.Id = dbSpecialitiesAfterUpdate.FirstOrDefault(e => e.ExternalId.ToString() == speciality.ExternalId)?.Id ?? default;
                }
            }
            var universitiesForUpdate = _mapper.Map<IEnumerable<EdboUniversityModel>, List<University>>(externalUniversities);

            //_universityRepo.UpdateList(universitiesForUpdate);
            await _uow.SaveAsync();
        }
    }
}
