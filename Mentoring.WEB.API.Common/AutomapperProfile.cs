using AutoMapper;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.Common.FilterModels;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Filters;

namespace Mentoring.WEB.API.Common
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<University, UniversityModel>();
            CreateMap<Speciality, SpecialityModel>();
            CreateMap<UserApplicationModel, UserApplication> ()
                .ForMember(dist => dist.ProfessionalDirections, opt => opt.Ignore())
                .ForMember(dist => dist.Regions, opt => opt.Ignore());
            CreateMap<Region, RegionModel>().ReverseMap();
            CreateMap<ProfessionalDirection, ProfessionalDirectionModel>().ReverseMap();
            CreateMap<UniversityFilter, UniversityFilterDao>().ReverseMap();
        }
    }
}
