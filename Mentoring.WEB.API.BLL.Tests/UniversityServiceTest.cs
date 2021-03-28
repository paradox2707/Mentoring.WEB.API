using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Mentoring.WEB.API.BLL.Implementations.Services;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Interfaces;

namespace Mentoring.WEB.API.BLL.Tests
{
    public class UniversityServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            //arrange
            var expected = GetArticlesDTO().ToList();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(e => e.UniversityRepository.GetAllAsync().Result).Returns(GetArticlesDAO());

            //act
            IUniversityService articleServ = new UniversityService(uowMock.Object, UTestHelper.CreateMapper());
            var actual = articleServ.GetAllAsync().Result.ToList();

            //assert
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].ShortName, actual[i].ShortName);
            }
        }

        private List<University> GetArticlesDAO()
        {
            return new List<University>
            {
                new University { Id=1, Name="Національний технічний університет України «Київський політехнічний інститут імені Ігоря Сікорського»", ShortName="КПІ ім. Ігоря Сікорського"}
            };
        }

        private IEnumerable<UniversityModel> GetArticlesDTO()
        {
            return new List<UniversityModel>
            {
                new UniversityModel { Id=1, Name="Національний технічний університет України «Київський політехнічний інститут імені Ігоря Сікорського»", ShortName="КПІ ім. Ігоря Сікорського"}
            };
        }
    }
}