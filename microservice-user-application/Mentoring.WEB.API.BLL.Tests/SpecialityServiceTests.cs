using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Implementations.Services;
using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.BLL.Interfaces.DAL;
using Mentoring.WEB.API.DAL.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Mentoring.WEB.API.BLL.Tests
{
    class SpecialityServiceTests
    {
        private Mock<IUnitOfWork> _uowMock;
        //private ISpecialityService _sut;

        [SetUp]
        public void Init()
        {
            _uowMock = new Mock<IUnitOfWork>();
        }

        [Test]
        public void GetAllAsync_ShouldReturnAllSpecialities()
        {
            ////arrange
            //var expected = GetSpecialitiesDTO().ToList();
            //_uowMock.Setup(e => e.SpecialityRepository.GetAllAsync().Result).Returns(GetSpecialitiesDAO());

            ////act
            //_sut = new SpecialityService(_uowMock.Object, UTestHelper.CreateMapper());
            //var actual = _sut.GetAllAsync().Result.ToList();

            ////assert
            //for (int i = 0; i < actual.Count; i++)
            //{
            //    Assert.AreEqual(expected[i].Id, actual[i].Id);
            //    Assert.AreEqual(expected[i].Name, actual[i].Name);
            //}
        }

        private List<Speciality> GetSpecialitiesDAO()
        {
            return new List<Speciality>
            {
                new Speciality { Id=1, Name="Право"}
            };
        }

        //private IEnumerable<SpecialityModel> GetSpecialitiesDTO()
        //{
        //    return new List<SpecialityModel>
        //    {
        //        new SpecialityModel { Id=1, Name="Право"}
        //    };
        //}
    }
}
