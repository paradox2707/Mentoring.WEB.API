using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.DAL.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.BLL.Tests
{
    [TestFixture]
    public class InboundModelValidatorTests
    {
        [SetUp]
        public void Init()
        { 
            _re
        }

        [Test]
        public async Task ValidateUserApplication()
        {
            var userApplication = new UserApplicationModel
            {
                Regions = { new RegionModel {Name } }
            };
        }
    }
}
