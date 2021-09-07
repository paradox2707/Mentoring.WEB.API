using AutoMapper;
using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using Mentoring.WEB.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.DAL.Implementations
{
    public class ProfessionalDirectionRepository : IProfessionalDirectionRepository
    {
        private readonly DbSet<ProfessionalDirection> _currentRepo;
        readonly IMapper _mapper;

        public ProfessionalDirectionRepository(UnitedAppContext context, IMapper mapper)
        {
            _currentRepo = context.ProfessionalDirections;
            _mapper = mapper;
        }

        public async Task<List<ProfessionalDirectionModel>> GetAllAsync()
        {
            return _mapper.Map<List<ProfessionalDirection>, List<ProfessionalDirectionModel>>(await _currentRepo.Include(e => e.UserApplications).ToListAsync());
        }
    }
}
