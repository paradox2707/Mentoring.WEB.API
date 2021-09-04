using Mentoring.WEB.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mentoring.WEB.API.DAL
{
    public class UnitedAppContext : DbContext
    {
        public UnitedAppContext(DbContextOptions<UnitedAppContext> options) : base(options)
        {}

        public DbSet<University> Universities { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ProfessionalDirection> ProfessionalDirections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SummaryUserApplicationDashboard>().HasNoKey().ToView(null);
            modelBuilder.Entity<SummaryUserApplicationByProfessionalDirectionDashboard>().HasNoKey().ToView(null);
            modelBuilder.Entity<University>().HasData(
                new University[]
                {
                    new University { Id=1L, Name="Академія зовнішньої розвідки України", ShortName="AЗРУ", IsGoverment=true, AverageMark=182, RegionId=2L },
                    new University { Id=2L, Name="Академія праці, соціальних відносин і туризму", ShortName="АПСВТ", IsGoverment=true, AverageMark=175, RegionId=2L },
                    new University { Id=3L, Name="Вищий навчальний заклад \"Київська Академія перукарського мистецтва\"", ShortName="ВНЗ \"КАПМ\"", IsGoverment=false, AverageMark=170, RegionId=6L },
                    new University { Id=4L, Name="Вищий навчальний заклад \"Київський економічний інститут менеджменту\" у формі Товариства з обмеженою відповідальністю", ShortName="КЕІМ", IsGoverment=true, AverageMark=180, RegionId=6L },
                }
                );
            modelBuilder.Entity<Speciality>().HasData(
                new Speciality[]
                {
                    new Speciality { Id =1L, Name ="Національна безпека", ProfessionalDirectionId =4 },
                    new Speciality { Id =2L, Name ="Право", ProfessionalDirectionId =6 },
                    new Speciality { Id =3L, Name ="дизайн", ProfessionalDirectionId =12 },
                    new Speciality { Id =4L, Name ="Соціологія", ProfessionalDirectionId =4 },
                    new Speciality { Id =5L, Name ="Фінанси, банківська справа та страхування", ProfessionalDirectionId =10 },
                    new Speciality { Id =6L, Name ="Менеджмент", ProfessionalDirectionId =8 },
                    new Speciality { Id =7L, Name ="Маркетинг", ProfessionalDirectionId =9 },
                    new Speciality { Id =8L, Name ="фінанси і кредит", ProfessionalDirectionId =10 },
                    new Speciality { Id =9L, Name ="менеджмент організацій і адміністрування", ProfessionalDirectionId =8 },
                    new Speciality { Id =10L, Name ="менеджмент зовнішньоекономічної діяльності", ProfessionalDirectionId =8 },
                }
                );
            modelBuilder.Entity("SpecialityUniversity").HasData(
                new { UniversitiesId = 1L, SpecialitiesId = 1L },
                new { UniversitiesId = 2L, SpecialitiesId = 2L },
                new { UniversitiesId = 2L, SpecialitiesId = 3L },
                new { UniversitiesId = 2L, SpecialitiesId = 6L },
                new { UniversitiesId = 4L, SpecialitiesId = 5L },
                new { UniversitiesId = 4L, SpecialitiesId = 6L },
                new { UniversitiesId = 4L, SpecialitiesId = 7L },
                new { UniversitiesId = 4L, SpecialitiesId = 8L },
                new { UniversitiesId = 4L, SpecialitiesId = 9L },
                new { UniversitiesId = 4L, SpecialitiesId = 10L }
                );
            modelBuilder.Entity<Region>().HasData(
                new Region[]
                {
                    new Region { Id =1L, Name="Вся Україна" },
                    new Region { Id =2L, Name="Захід" },
                    new Region { Id =3L, Name="Схід" },
                    new Region { Id =4L, Name="Північ" },
                    new Region { Id =5L, Name="Південь" },
                    new Region { Id =6L, Name="Центр" },
                });
            modelBuilder.Entity<ProfessionalDirection>().HasData(
                new ProfessionalDirection[]
                {
                    new ProfessionalDirection { Id =1L, Name="Програмування" },
                    new ProfessionalDirection { Id =2L, Name="Медицина" },
                    new ProfessionalDirection { Id =3L, Name="Педагогіка" },
                    new ProfessionalDirection { Id =4L, Name="Природничі науки" },
                    new ProfessionalDirection { Id =5L, Name="Суспільні науки" },
                    new ProfessionalDirection { Id =6L, Name="Юриспруденція" },
                    new ProfessionalDirection { Id =7L, Name="Економіка" },
                    new ProfessionalDirection { Id =8L, Name="Менеджмент" },
                    new ProfessionalDirection { Id =9L, Name="Маркетинг" },
                    new ProfessionalDirection { Id =10L, Name="Фінанси" },
                    new ProfessionalDirection { Id =11L, Name="Журналістика" },
                    new ProfessionalDirection { Id =12L, Name="Дизайн" },
                    new ProfessionalDirection { Id =13L, Name="Акторське мистецтво" },
                });
        }
    }
}
