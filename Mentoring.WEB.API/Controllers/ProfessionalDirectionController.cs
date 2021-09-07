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
    public class ProfessionalDirectionController : ControllerBase
    {
        private readonly IProfessionalDirectionService _proDirectionService;
        private readonly ILogger<ProfessionalDirectionController> _logger;

        public ProfessionalDirectionController(IProfessionalDirectionService proDirectionService, ILogger<ProfessionalDirectionController> logger)
        {
            _proDirectionService = proDirectionService;
            _logger = logger;
        }

        // GET: api/<ProfessionalDirectionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessionalDirectionModel>>> Get()
        {
            return Ok(await _proDirectionService.GetAllAsync());
        }
    }
}
