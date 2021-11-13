using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mentoring.WEB.API.Common;

namespace Mentoring.WEB.API.BLL.Tests
{
    public static class UTestHelper
    {
        public static IMapper CreateMapper()
        {
            var myProfile = new AutomapperProfile();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            return config.CreateMapper();
        }
    }
}
