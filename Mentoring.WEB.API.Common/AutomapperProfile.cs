using AutoMapper;
using Mentoring.WEB.API.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mentoring.WEB.API.DAL.Entities;

namespace Mentoring.WEB.API.Common
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<University, UniversityModel>();
            CreateMap<Speciality, SpecialityModel>();
            CreateMap<EdboUniversityModel, University>()
                .ForMember(dist => dist.Specialities, opt => opt.AllowNull())
                .ForMember(dist => dist.ExternalId, opt => opt.MapFrom(source => Convert.ToInt32(source.ExternalId)));
            CreateMap<EdboSpecialityModel, Speciality>()
                .ForMember(dist => dist.Universities, opt => opt.Ignore())
                .ForMember(dist => dist.ExternalId, opt => opt.NullSubstitute(0));
        }
    }
}
