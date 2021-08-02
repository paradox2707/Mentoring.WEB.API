using Mentoring.WEB.API.BLL.Implementations;
using Mentoring.WEB.API.Common;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using Mentoring.WEB.API.DAL.Filters;
using Mentoring.WEB.API.DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Tests
{
    [TestFixture]
    public class InboundValidatorTests
    {
        private Mock<IUnitOfWork> _uowMock;
        private InboundValidator _sut;

        [SetUp]
        public void Init()
        {
            _uowMock = new Mock<IUnitOfWork>();
        }

        [Test]
        public async Task ValidateUserApplication_ShouldValidateSuccess_WhenGetMoreThanZeroUnivesties()
        {
            _uowMock
                .Setup(e => e.UniversityRepository.GetAllForUserApplicationValidationBySql(It.IsAny<UniversityFilterForUserApplicationValidationInSql>()))
                .ReturnsAsync(new List<University> { new University() });
            _sut = new InboundValidator(_uowMock.Object, UTestHelper.CreateMapper());

            //act
            var result = await _sut.ValidateUserApplication(new UserApplicationModel());

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ValidateUserApplication_ShouldThrowException_WhenGetZeroUnivesties()
        {
            _uowMock
                .Setup(e => e.UniversityRepository.GetAllForUserApplicationValidationBySql(It.IsAny<UniversityFilterForUserApplicationValidationInSql>()))
                .ReturnsAsync(new List<University> { });
            _sut = new InboundValidator(_uowMock.Object, UTestHelper.CreateMapper());

            Assert.ThrowsAsync<ValidationAppException>(async() => await _sut.ValidateUserApplication(new UserApplicationModel()));
        }
    }
}
