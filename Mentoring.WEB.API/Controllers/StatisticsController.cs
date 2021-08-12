using Mentoring.WEB.API.BLL.Interfaces;
using Mentoring.WEB.API.Common.DTO;
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
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        // GET: api/<Statistics>
        [HttpGet]
        [Route("SummaryUserApplicationDashboard")]
        public async Task<ActionResult<SummaryUserApplicationDashboardModel>> Get()
        {
            return Ok(await _statisticsService.GetSummaryUserApplicationDashboard());
        }
    }
}
