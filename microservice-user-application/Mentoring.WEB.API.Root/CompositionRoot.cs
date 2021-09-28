using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mentoring.WEB.API.BLL.Implementations.Services;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common;
using Mentoring.WEB.API.DAL;
using Mentoring.WEB.API.DAL.Implementations;
using Mentoring.WEB.API.BLL.Implementations;
using Mentoring.WEB.API.BLL.Interfaces.DAL;

namespace Mentoring.WEB.API.Root
{
    public class CompositionRoot
    {
        public static void InjectDependencies(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<UnitedAppContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUniversityService, UniversityService>();
            services.AddScoped<IUserApplicationService, UserApplicationService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IProfessionalDirectionService, ProfessionalDirectionService>();
            services.AddScoped<IInboundValidator, InboundValidator>();

            #region DI Mapper
            var myProfile = new AutomapperProfile();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            #endregion
        }
    }
}
