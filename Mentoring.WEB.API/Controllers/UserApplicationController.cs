using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mentoring.WEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApplicationController : ControllerBase
    {
        private readonly IUserApplicationService _applicationService;

        public UserApplicationController(IUserApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task Post([FromBody] UserApplicationModel value)
        {
            await _applicationService.CreateAsync(value);
        }
    }
}
