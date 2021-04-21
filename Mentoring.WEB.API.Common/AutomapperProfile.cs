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
        }
    }
}
