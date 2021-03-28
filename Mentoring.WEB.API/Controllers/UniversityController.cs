using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.DAL.Entities;
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
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService _universityService;

        public UniversityController(IUniversityService universityService)
        {
            this._universityService = universityService;
        }

        // GET: api/<University>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> Get()
        {
            return Ok(await _universityService.GetAllAsync());
        }
    }
}
