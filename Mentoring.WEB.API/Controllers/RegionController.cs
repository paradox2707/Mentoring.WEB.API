using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mentoring.WEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly ILogger<RegionController> _logger;

        public RegionController(IRegionService regionService, ILogger<RegionController> logger)
        {
            _regionService = regionService;
            _logger = logger;
        }

        // GET: api/<RegionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionModel>>> Get()
        {
            return Ok(await _regionService.GetAllAsync());
        }
    }
}
