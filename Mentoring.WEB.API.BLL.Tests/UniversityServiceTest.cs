using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Mentoring.WEB.API.BLL.Implementations.Services;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Tests
{
    public class UniversityServiceTest
    {
        [Test]
        public void GetAllAsync_ShouldReturnAllUniversities()
        {
            //arrange
            var expected = GetUniversitiesDTO().ToList();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(e => e.UniversityRepository.GetAllAsync().Result).Returns(GetUniversitiesDAO());

            //act
            IUniversityService universiryService = new UniversityService(uowMock.Object, UTestHelper.CreateMapper());
            var actual = universiryService.GetAllAsync().Result.ToList();

            //assert
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].ShortName, actual[i].ShortName);
            }
        }

        [Test]
        public void GetAllWithSpecialitiesAsync_ShouldReturnAllUniversities()
        {
            //arrange
            var expected = GetUniversitiesWithSpecielitiesDTO().ToList();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(e => e.UniversityRepository.GetAllAsync().Result).Returns(GetUniversitiesWithSpecielitiesDAO());

            //act
            IUniversityService universiryService = new UniversityService(uowMock.Object, UTestHelper.CreateMapper());
            var actual = universiryService.GetAllAsync().Result.ToList();

            //assert
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].ShortName, actual[i].ShortName);
            }
        }

        [Test]
        public void GetAllWithSpecialitiesAsync_ShouldReturnRightNumberOfSpecialities()
        {
            //arrange
            var expected = GetUniversitiesWithSpecielitiesDTO().ToList();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(e => e.UniversityRepository.GetAllAsync().Result).Returns(GetUniversitiesWithSpecielitiesDAO());

            //act
            IUniversityService universiryService = new UniversityService(uowMock.Object, UTestHelper.CreateMapper());
            var actual = universiryService.GetAllAsync().Result.ToList();

            //assert
            foreach (var expectedItem in expected)
            {
                Assert.AreEqual(expectedItem.Specialities.Count, actual.Single(e => e.Id == expectedItem.Id).Specialities.Count);
            }
        }

        private List<University> GetUniversitiesDAO()
        {
            return new List<University>
            {
                new University { Id=1, Name="Національний технічний університет України «Київський політехнічний інститут імені Ігоря Сікорського»", ShortName="КПІ ім. Ігоря Сікорського"}
            };
        }

        private IEnumerable<UniversityModel> GetUniversitiesDTO()
        {
            return new List<UniversityModel>
            {
                new UniversityModel { Id=1, Name="Національний технічний університет України «Київський політехнічний інститут імені Ігоря Сікорського»", ShortName="КПІ ім. Ігоря Сікорського"}
            };
        }

        private List<University> GetUniversitiesWithSpecielitiesDAO()
        {
            return new List<University>
            {
                new University 
                { 
                    Id=1,
                    Name="Національний технічний університет України «Київський політехнічний інститут імені Ігоря Сікорського»", 
                    ShortName="КПІ ім. Ігоря Сікорського",
                    Specialities=new List<Speciality>
                    {
                        new Speciality { Id=1, Name="Pravo" },
                        new Speciality { Id=1, Name="Menegment" },
                        new Speciality { Id=1, Name="Marketing" }
                    }
                }
            };
        }

        private IEnumerable<UniversityModel> GetUniversitiesWithSpecielitiesDTO()
        {
            return new List<UniversityModel>
            {
                new UniversityModel 
                { 
                    Id=1, 
                    Name="Національний технічний університет України «Київський політехнічний інститут імені Ігоря Сікорського»", 
                    ShortName="КПІ ім. Ігоря Сікорського",
                    Specialities=new List<SpecialityModel>
                    {
                        new SpecialityModel { Id=1, Name="Pravo" },
                        new SpecialityModel { Id=1, Name="Menegment" },
                        new SpecialityModel { Id=1, Name="Marketing" }
                    }
                }
            };
        }
    }
}