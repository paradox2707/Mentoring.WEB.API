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
    public class AbiturientApplicationController : ControllerBase
    {
        // GET: api/<AbiturientApplicationController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<AbiturientApplicationController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AbiturientApplicationController>
        [HttpPost]
        public void Post([FromBody] AbiturientApplicationModel value)
        {

        }

        //// PUT api/<AbiturientApplicationController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AbiturientApplicationController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
