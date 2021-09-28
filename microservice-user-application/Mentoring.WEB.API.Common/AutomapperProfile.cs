using AutoMapper;
using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.FilterModels;
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
            CreateMap<UserApplicationModel, UserApplication> ()
                .ForMember(dist => dist.ProfessionalDirections, opt => opt.Ignore())
                .ForMember(dist => dist.Regions, opt => opt.Ignore());
            CreateMap<UserApplication, UserApplicationModel>();
            CreateMap<Region, RegionModel>().ReverseMap();
            CreateMap<ProfessionalDirection, ProfessionalDirectionModel>().ReverseMap();
            CreateMap<UniversityFilterForUserApplication, UniversityFilterForUserApplicationInSql>().ReverseMap();
            CreateMap<UserApplicationFilter, UserApplicationFilterInSql>();
            CreateMap<UserApplicationModel, UniversityFilterForUserApplicationValidationInSql>()
                .ForMember(dist => dist.ProfessionalDirections, opt => opt.MapFrom(sourse => sourse.ProfessionalDirections.Select(e => e.Name)))
                .ForMember(dist => dist.Regions, opt => opt.MapFrom(sourse => sourse.Regions.Select(e => e.Name)));
        }
    }
}
