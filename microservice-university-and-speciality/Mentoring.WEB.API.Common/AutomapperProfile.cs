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
            CreateMap<Speciality, SpecialityModel>();
            CreateMap<Region, RegionModel>().ReverseMap();
            CreateMap<ProfessionalDirection, ProfessionalDirectionModel>().ReverseMap();
            CreateMap<UniversityFilter, UniversityFilterInSql>().ReverseMap();
        }
    }
}
