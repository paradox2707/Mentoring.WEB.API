using AutoMapper;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.Common.FilterModels;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Filters;
using System.Linq;

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
            CreateMap<UserApplication, UserApplicationModel>();
            CreateMap<Region, RegionModel>().ReverseMap();
            CreateMap<ProfessionalDirection, ProfessionalDirectionModel>().ReverseMap();
            CreateMap<UniversityFilter, UniversityFilterInSql>().ReverseMap();
            CreateMap<UniversityFilterForUserApplication, UniversityFilterForUserApplicationInSql>().ReverseMap();
            CreateMap<UserApplicationModel, UniversityFilterForUserApplicationValidationInSql>()
                .ForMember(dist => dist.ProfessionalDirections, opt => opt.MapFrom(sourse => sourse.ProfessionalDirections.Select(e => e.Name)))
                .ForMember(dist => dist.Regions, opt => opt.MapFrom(sourse => sourse.Regions.Select(e => e.Name)));
        }
    }
}
