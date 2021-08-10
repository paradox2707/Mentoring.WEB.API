using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common.DTO;
using Mentoring.WEB.API.Common.FilterModels;
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
        private readonly IInboundValidator _validator;

        public UserApplicationController(IUserApplicationService applicationService, IInboundValidator validator)
        {
            _applicationService = applicationService;
            _validator = validator;
        }

        // GET: api/<UserApplication>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserApplicationModel>>> Get([FromQuery] UserApplicationFilter filter)
        {
            if (filter.Active)
                return Ok(await _applicationService.GetAllByFilterAsync(filter));
            else
                return Ok(await _applicationService.GetAllAsync());
        }

        [HttpPost]
        public async Task Post([FromBody] UserApplicationModel value)
        {
            if(await _validator.ValidateUserApplication(value))
                await _applicationService.CreateAsync(value);
        }
    }
}
