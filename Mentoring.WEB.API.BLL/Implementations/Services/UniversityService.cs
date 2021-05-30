using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using System.Linq;
using System;
using Mentoring.WEB.API.Common.FilterModels;

namespace Mentoring.WEB.API.BLL.Implementations.Services
{
    public class UniversityService : IUniversityService
    {
        readonly IUnitOfWork _uow;
        readonly IUniversityRepository _universityRepo;
        readonly IMapper _mapper;

        public UniversityService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _universityRepo = uow.UniversityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UniversityModel>> GetAllAsync()
        {
            var daos = await _universityRepo.GetAllAsync();

            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }

        public async Task<IEnumerable<UniversityModel>> GetAllByFilterAsync(UniversityFilter filter)
        {
            var daos = await _universityRepo.GetAllAsync();
            if (string.IsNullOrWhiteSpace(filter.Region))
                daos = daos.Where(e => e.Region.Name == filter.Region).ToList();
            if (filter.IsGoverment != null)
                daos = daos.Where(e => e.IsGoverment == filter.IsGoverment).ToList();
            if (string.IsNullOrWhiteSpace(filter.SearchText))
                daos = GetUniversityByFilter(filter.SearchText.TrimEnd().ToLower(), daos);
            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }

        private static List<University> GetUniversityByFilter(string filter, List<University> daos) => 
            daos.Where(e => e.Name.ToLower().Split(new string[] { " ", "  ", "   ", "\t" }, StringSplitOptions.RemoveEmptyEntries).Any(word => word.StartsWith(filter))
            || e.Name.ToLower().StartsWith(filter)
            || e.ShortName.ToLower().Split(new string[] { " ", "  ", "   ", "\t" }, StringSplitOptions.RemoveEmptyEntries).Any(word => word.StartsWith(filter))
            || e.ShortName.ToLower().StartsWith(filter))
            .ToList();

        public async Task<IEnumerable<UniversityModel>> GetAllWithSpecialitiesAsync()
        {
            var daos = await _universityRepo.GetAllWithSpecialiesAsync();

            return _mapper.Map<List<University>, IEnumerable<UniversityModel>>(daos);
        }
    }
}
