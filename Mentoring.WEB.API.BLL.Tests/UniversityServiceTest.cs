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
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetAllAsync_ShouldReturnAllUniversities()
        {
            //arrange
            var expected = GetUniversitiesDTO().ToList();
            var uowMock = new Mock<IUnitOfWork>();
            var edbo = new Mock<IEdboService>();
            uowMock.Setup(e => e.UniversityRepository.GetAllAsync().Result).Returns(GetUniversitiesDAO());

            //act
            IUniversityService universiryService = new UniversityService(uowMock.Object, UTestHelper.CreateMapper(), edbo.Object);
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
        public async Task UpdateAllUniversitiesFromExternalSourceAsync_SouldCallUpdateFromRepository()
        {
            //arrange
            var edboUniversities = GetEdboUniversitiesDTO().ToList();
            var uowMock = new Mock<IUnitOfWork>();
            var repo = new Mock<IUniversityRepository>();
            var edbo = new Mock<IEdboService>();
            edbo.Setup(e => e.GetAllUniversities().Result).Returns(edboUniversities);
            uowMock.Setup(e => e.UniversityRepository).Returns(repo.Object);
            repo.Setup(e => e.GetAllAsync().Result).Returns(new List<University>());
            //act
            IUniversityService universiryService = new UniversityService(uowMock.Object, UTestHelper.CreateMapper(), edbo.Object);
            await universiryService.UpdateAllUniversitiesFromExternalSourceAsync();
            //assert
            uowMock.Verify(e => e.UniversityRepository.UpdateList(It.IsAny<IEnumerable<University>>()), Times.Once);
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

        private IEnumerable<EdboUniversityModel> GetEdboUniversitiesDTO()
        {
            return new List<EdboUniversityModel>
            {
                new EdboUniversityModel { ExternalId="1", Name="Національний технічний університет України «Київський політехнічний інститут імені Ігоря Сікорського»", ShortName="КПІ ім. Ігоря Сікорського"}
            };
        }
    }
}