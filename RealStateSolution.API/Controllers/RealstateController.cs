using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealStateSolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RealStateSolution.Services.Domain.RealstateResult;

namespace RealStateSolution.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RealstateController : ControllerBase
    {
        private readonly IRealStateAPIService _realStateAPIService;

        public RealstateController(IRealStateAPIService realStateAPIService)
        {
            _realStateAPIService = realStateAPIService;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<RealStateObject>))]
        public async Task<IActionResult> GetTopAgents()
        {
            return Ok(await _realStateAPIService.GetByAgentsOrderByCountAsync());
        }

        [HttpGet("forsale")]
        [Produces(typeof(IEnumerable<RealStateObject>))]
        public async Task<IActionResult> GetTopForSales()
        {
            return Ok(await _realStateAPIService.GetTopTenAsync());
        }
    }
}
