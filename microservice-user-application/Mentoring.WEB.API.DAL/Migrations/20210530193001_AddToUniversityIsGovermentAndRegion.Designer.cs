﻿// <auto-generated />
using Mentoring.WEB.API.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mentoring.WEB.API.DAL.Migrations
{
    [DbContext(typeof(UnitedAppContext))]
    [Migration("20210530193001_AddToUniversityIsGovermentAndRegion")]
    partial class AddToUniversityIsGovermentAndRegion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mentoring.WEB.API.DAL.Entities.ProfessionalDirection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProfessionalDirections");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Програмування"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Медицина"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Педагогіка"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Природничі науки"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Суспільні науки"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Юриспруденція"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Економіка"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Менеджмент"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Маркетинг"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "Фінанси"
                        },
                        new
                        {
                            Id = 11L,
                            Name = "Журналістика"
                        },
                        new
                        {
                            Id = 12L,
                            Name = "Дизайн"
                        },
                        new
                        {
                            Id = 13L,
                            Name = "Акторське мистецтво"
                        });
                });

            modelBuilder.Entity("Mentoring.WEB.API.DAL.Entities.Region", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Вся Україна"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Захід"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Схід"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Північ"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Південь"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Центр"
                        });
                });

            modelBuilder.Entity("Mentoring.WEB.API.DAL.Entities.Speciality", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialities");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Національна безпека"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Право"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "дизайн"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Соціологія"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Фінанси, банківська справа та страхування"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Менеджмент"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Маркетинг"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "фінанси і кредит"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "менеджмент організацій і адміністрування"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "менеджмент зовнішньоекономічної діяльності"
                        });
                });

            modelBuilder.Entity("Mentoring.WEB.API.DAL.Entities.University", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGoverment")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RegionId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Universities");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            IsGoverment = true,
                            Name = "Академія зовнішньої розвідки України",
                            RegionId = 2L,
                            ShortName = "AЗРУ"
                        },
                        new
                        {
                            Id = 2L,
                            IsGoverment = true,
                            Name = "Академія праці, соціальних відносин і туризму",
                            RegionId = 2L,
                            ShortName = "АПСВТ"
                        },
                        new
                        {
                            Id = 3L,
                            IsGoverment = false,
                            Name = "Вищий навчальний заклад \"Київська Академія перукарського мистецтва\"",
                            RegionId = 6L,
                            ShortName = "ВНЗ \"КАПМ\""
                        },
                        new
                        {
                            Id = 4L,
                            IsGoverment = true,
                            Name = "Вищий навчальний заклад \"Київський економічний інститут менеджменту\" у формі Товариства з обмеженою відповідальністю",
                            RegionId = 6L,
                            ShortName = "КЕІМ"
                        });
                });

            modelBuilder.Entity("Mentoring.WEB.API.DAL.Entities.UserApplication", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AverageMark")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserApplications");
                });

            modelBuilder.Entity("ProfessionalDirectionUserApplication", b =>
                {
                    b.Property<long>("ProfessionalDirectionsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserApplicationsId")
                        .HasColumnType("bigint");

                    b.HasKey("ProfessionalDirectionsId", "UserApplicationsId");

                    b.HasIndex("UserApplicationsId");

                    b.ToTable("ProfessionalDirectionUserApplication");
                });

            modelBuilder.Entity("RegionUserApplication", b =>
                {
                    b.Property<long>("RegionsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserApplicationsId")
                        .HasColumnType("bigint");

                    b.HasKey("RegionsId", "UserApplicationsId");

                    b.HasIndex("UserApplicationsId");

                    b.ToTable("RegionUserApplication");
                });

            modelBuilder.Entity("SpecialityUniversity", b =>
                {
                    b.Property<long>("SpecialitiesId")
                        .HasColumnType("bigint");

                    b.Property<long>("UniversitiesId")
                        .HasColumnType("bigint");

                    b.HasKey("SpecialitiesId", "UniversitiesId");

                    b.HasIndex("UniversitiesId");

                    b.ToTable("SpecialityUniversity");

                    b.HasData(
                        new
                        {
                            SpecialitiesId = 1L,
                            UniversitiesId = 1L
                        },
                        new
                        {
                            SpecialitiesId = 2L,
                            UniversitiesId = 2L
                        },
                        new
                        {
                            SpecialitiesId = 3L,
                            UniversitiesId = 2L
                        },
                        new
                        {
                            SpecialitiesId = 6L,
                            UniversitiesId = 2L
                        },
                        new
                        {
                            SpecialitiesId = 5L,
                            UniversitiesId = 4L
                        },
                        new
                        {
                            SpecialitiesId = 6L,
                            UniversitiesId = 4L
                        },
                        new
                        {
                            SpecialitiesId = 7L,
                            UniversitiesId = 4L
                        },
                        new
                        {
                            SpecialitiesId = 8L,
                            UniversitiesId = 4L
                        },
                        new
                        {
                            SpecialitiesId = 9L,
                            UniversitiesId = 4L
                        },
                        new
                        {
                            SpecialitiesId = 10L,
                            UniversitiesId = 4L
                        });
                });

            modelBuilder.Entity("Mentoring.WEB.API.DAL.Entities.University", b =>
                {
                    b.HasOne("Mentoring.WEB.API.DAL.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("ProfessionalDirectionUserApplication", b =>
                {
                    b.HasOne("Mentoring.WEB.API.DAL.Entities.ProfessionalDirection", null)
                        .WithMany()
                        .HasForeignKey("ProfessionalDirectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mentoring.WEB.API.DAL.Entities.UserApplication", null)
                        .WithMany()
                        .HasForeignKey("UserApplicationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RegionUserApplication", b =>
                {
                    b.HasOne("Mentoring.WEB.API.DAL.Entities.Region", null)
                        .WithMany()
                        .HasForeignKey("RegionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mentoring.WEB.API.DAL.Entities.UserApplication", null)
                        .WithMany()
                        .HasForeignKey("UserApplicationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpecialityUniversity", b =>
                {
                    b.HasOne("Mentoring.WEB.API.DAL.Entities.Speciality", null)
                        .WithMany()
                        .HasForeignKey("SpecialitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mentoring.WEB.API.DAL.Entities.University", null)
                        .WithMany()
                        .HasForeignKey("UniversitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
