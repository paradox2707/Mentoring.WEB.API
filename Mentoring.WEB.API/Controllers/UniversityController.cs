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
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService _universityService;
        private readonly ILogger<UniversityController> _logger;

        public UniversityController(IUniversityService universityService, ILogger<UniversityController> logger)
        {
            _universityService = universityService;
            _logger = logger;
        }

        // GET: api/<University>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UniversityModel>>> Get([FromQuery] string filter)
        {
            _logger.LogInformation("Call end-point all universities");
            if(string.IsNullOrWhiteSpace(filter))
                return Ok(await _universityService.GetAllAsync());
            else
                return Ok(await _universityService.GetAllByStartWithFilterForEveryWordAsync(filter));
        }

        // GET: api/<University>
        [HttpGet]
        [Route("Specialities")]
        public async Task<ActionResult<IEnumerable<UniversityModel>>> GetWithSpecialities()
        {
            _logger.LogInformation("Call end-point all universities with specialities");
            return Ok(await _universityService.GetAllWithSpecialitiesAsync());
        }
    }
}
