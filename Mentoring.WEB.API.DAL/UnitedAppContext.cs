using Mentoring.WEB.API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.WEB.API.DAL
{
    public class UnitedAppContext : DbContext
    {
        public UnitedAppContext(DbContextOptions<UnitedAppContext> options) : base(options)
        {}

        public DbSet<University> Universities { get; set; }
        public DbSet<Speciality> Specialities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>().HasData(
                new University[]
                {
                    new University { Id=1L, Name="Академія зовнішньої розвідки України", ShortName="AЗРУ" },
                    new University { Id=2L, Name="Академія праці, соціальних відносин і туризму", ShortName="АПСВТ" },
                    new University { Id=4L, Name="Вищий навчальний заклад \"Київська Академія перукарського мистецтва\"", ShortName="ВНЗ \"КАПМ\"" },
                    new University { Id=5L, Name="Вищий навчальний заклад \"Київський економічний інститут менеджменту\" у формі Товариства з обмеженою відповідальністю", ShortName="КЕІМ" },
                }
                );
            modelBuilder.Entity<Speciality>().HasData(
                new Speciality[]
                {
                    new Speciality { Id =1L, Name ="Національна безпека" },
                    new Speciality { Id =2L, Name ="Право" },
                    new Speciality { Id =3L, Name ="дизайн" },
                    new Speciality { Id =4L, Name ="Соціологія" },
                    new Speciality { Id =5L, Name ="Фінанси, банківська справа та страхування" },
                    new Speciality { Id =6L, Name ="Менеджмент" },
                    new Speciality { Id =7L, Name ="Маркетинг" },
                    new Speciality { Id =8L, Name ="фінанси і кредит" },
                    new Speciality { Id =9L, Name ="менеджмент організацій і адміністрування" },
                    new Speciality { Id =10L, Name ="менеджмент зовнішньоекономічної діяльності" },
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
        }
    }
}
