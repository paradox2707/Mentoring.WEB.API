using AutoMapper;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;

namespace Mentoring.WEB.API.Common
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<University, UniversityModel>();
            CreateMap<Speciality, SpecialityModel>();
            CreateMap<UserApplicationModel, UserApplication> ()
                .ForMember(dist => dist.Regions, opt => opt.Ignore());
            CreateMap<Region, RegionModel>().ReverseMap();
            CreateMap<ProfessionalDirection, ProfessionalDirectionModel>().ReverseMap();
        }
    }
}
