using Mentoring.WEB.API.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EDBOController : ControllerBase
    {
        readonly IEDBOService _EDBOService;

        public EDBOController(IEDBOService eDBOService)
        {
            _EDBOService = eDBOService;
        }

        // GET: api/<EDBO>
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            await _EDBOService.UpdateUniversities();
            return Ok("Success update!");
        }

    }
}
