using AutoMapper;
using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.DAL.Entities;

namespace Mentoring.WEB.API.Common
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<SummaryUserApplicationDashboard, SummaryUserApplicationDashboardModel>();
            CreateMap<SummaryUserApplicationByProfessionalDirectionDashboard, SummaryUserApplicationByProfessionalDirectionDashboardModel>();
        }
    }
}
