using AutoMapper;
using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using Mentoring.WEB.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly DbSet<Speciality> _currentRepo;
        readonly IMapper _mapper;

        public SpecialityRepository(UnitedAppContext context, IMapper mapper)
        {
            _currentRepo = context.Specialities;
            _mapper = mapper;
        }

        public async Task<List<SpecialityModel>> GetAllAsync()
        {
            return _mapper.Map<List<Speciality>, List<SpecialityModel>>(await _currentRepo.ToListAsync(););
        }
    }
}
