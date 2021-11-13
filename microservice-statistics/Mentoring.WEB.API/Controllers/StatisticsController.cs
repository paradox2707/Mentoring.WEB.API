using Mentoring.WEB.API.BLL.DTO;
using Mentoring.WEB.API.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult<SummaryUserApplicationDashboardModel>> GetSummaryUserApplication()
        {
            return Ok(await _statisticsService.GetSummaryUserApplicationDashboard());
        }

        [HttpGet]
        [Route("SummaryUserApplicationByProfessionalDirectionDashboard")]
        public async Task<ActionResult<IEnumerable<SummaryUserApplicationByProfessionalDirectionDashboardModel>>> GetSummaryUserApplicationByProfessionalDirection()
        {
            return Ok(await _statisticsService.SummaryUserApplicationByProfessionalDirectionDashboard());
        }
    }
}
