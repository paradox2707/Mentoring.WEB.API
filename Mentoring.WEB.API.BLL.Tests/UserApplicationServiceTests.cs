//using Mentoring.WEB.API.BLL.DTO;
//using Mentoring.WEB.API.BLL.Implementations.Services;
//using Mentoring.WEB.API.BLL.Interfaces.DAL;
//using Mentoring.WEB.API.DAL.Entities;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Threading.Tasks;

//namespace Mentoring.WEB.API.BLL.Tests
//{
//    [TestFixture]
//    public class UserApplicationServiceTests
//    {
//        private Mock<IUnitOfWork> _uowMock;
//        private UserApplicationService _sut;

//        [SetUp]
//        public void Init()
//        {
//            _uowMock = new Mock<IUnitOfWork>();
//        }

//        [Test]
//        public async Task CreateAsync_ShouldExecuteCreateMethod_WhenInboundDtoHasNotCollectionAtributes()
//        {
//            //arrange
//            var applicationDTO = new UserApplicationModel
//            {
//                FirstName = "Андрій",
//                SecondName = "Слижук",
//                AverageMark = 200,
//                PhoneNumber = 0661234567
//            };
//            _uowMock.Setup(e => e.RegionRepository.GetByAsync(It.IsAny<Expression<Func<Region, bool>>>()).Result);
//            _uowMock.Setup(e => e.ProfessionalDirectionRepository.GetByAsync(It.IsAny<Expression<Func<ProfessionalDirection, bool>>>()).Result);
//            _uowMock.Setup(e => e.UserApplicationRepository.CreateAsync(It.IsAny<UserApplication>()));

//            //Act
//            _sut = new UserApplicationService(_uowMock.Object, UTestHelper.CreateMapper());
//            await _sut.CreateAsync(applicationDTO);

//            //Assert
//            _uowMock.Verify(m => m.UserApplicationRepository.CreateAsync(It.IsAny<UserApplication>()), Times.Once);
//        }

//        [Test]
//        public async Task CreateAsync_ShouldExecuteCreateMethod_WhenInboundDtoHasCollectionAtributes()
//        {
//            //arrange
//            var applicationDTO = new UserApplicationModel
//            {
//                FirstName = "Андрій",
//                SecondName = "Слижук",
//                AverageMark = 200,
//                PhoneNumber = 0661234567,
//                Regions = new List<RegionModel> { new RegionModel { Name = "Схід" }, new RegionModel { Name = "Захід" } },
//                ProfessionalDirections = new List<ProfessionalDirectionModel>
//                {
//                    new ProfessionalDirectionModel { Name = "Програмування"},
//                    new ProfessionalDirectionModel { Name = "Медицина"},
//                    new ProfessionalDirectionModel { Name = "Фінанси"}
//                }
//            };
//            _uowMock.Setup(e => e.RegionRepository.GetByAsync(It.IsAny<Expression<Func<Region, bool>>>()).Result);
//            _uowMock.Setup(e => e.ProfessionalDirectionRepository.GetByAsync(It.IsAny<Expression<Func<ProfessionalDirection, bool>>>()).Result);
//            _uowMock.Setup(e => e.UserApplicationRepository.CreateAsync(It.IsAny<UserApplication>()));

//            //Act
//            _sut = new UserApplicationService(_uowMock.Object, UTestHelper.CreateMapper());
//            await _sut.CreateAsync(applicationDTO);

//            //Assert
//            _uowMock.Verify(m => m.UserApplicationRepository.CreateAsync(It.IsAny<UserApplication>()), Times.Once);
//        }
//    }
//}
