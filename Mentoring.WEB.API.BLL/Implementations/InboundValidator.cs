using AutoMapper;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Filters;
using Mentoring.WEB.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Implementations
{
    public class InboundValidator : IInboundValidator
    {
        readonly IUnitOfWork _uow;
        readonly IUniversityRepository _universityRepo;
        readonly IMapper _mapper;

        public InboundValidator(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _universityRepo = uow.UniversityRepository;
            _mapper = mapper;
        }

        public async Task<bool> ValidateUserApplication(UserApplicationModel userApplication)
        {
            var daoFilter = _mapper.Map<UserApplicationModel, UniversityFilterForUserApplicationValidationInSql>(userApplication);
            var daos = await _universityRepo.GetAllForUserApplicationValidationBySql(daoFilter);
            if(daos.Any())
                return true;

            throw new ValidationAppException("Doesn`t have any universities with this combination regions and directions");
        }
    }
}
