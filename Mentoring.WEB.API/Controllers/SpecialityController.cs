using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mentoring.WEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;
        private readonly ILogger<SpecialityController> _logger;

        public SpecialityController(ISpecialityService specialityService, ILogger<SpecialityController> logger)
        {
            _specialityService = specialityService;
            _logger = logger;
        }

        // GET: api/<SpecialityController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialityModel>>> Get()
        {
            _logger.LogInformation("Call end-point all specialities");
            return Ok(await _specialityService.GetAllAsync());
        }
    }
}
