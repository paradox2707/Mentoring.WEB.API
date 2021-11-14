using AutoMapper;
using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using Mentoring.WEB.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DbSet<Region> _currentRepo;
        readonly IMapper _mapper;

        public RegionRepository(UnitedAppContext context, IMapper mapper)
        {
            _currentRepo = context.Regions;
            _mapper = mapper;
        }

        public async Task Create(RegionModel value)
        {
            if (await _currentRepo.AnyAsync(e => e.Name == value.Name))
                throw new Exception("Same Region exists in DB");

            await _currentRepo.AddAsync(_mapper.Map<RegionModel, Region>(value));
        }

        public async Task<List<RegionModel>> GetAllAsync()
        {
            var daos = await _currentRepo.ToListAsync();
            return _mapper.Map<List<Region>, List<RegionModel>>(daos);
        }
    }
}
