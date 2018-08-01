using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.HealthChecks;

namespace WithBeatPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IHealthCheckService _healthCheck;

        public ValuesController(IHealthCheckService healthCheck)
        {
            _healthCheck = healthCheck;
        }

        [HttpGet("NotFound")]
        public ActionResult NotFound()
        {
            return base.NotFound();
        }
        [HttpGet("CreatedAt")]
        public ActionResult CreatedAt()
        {
            return base.CreatedAtAction(nameof(CreatedAt), 1);
        }

        [HttpGet("Ok")]
        public ActionResult Ok()
        {
            return base.Ok();
        }

        [HttpGet("InternalServerError")]
        public ActionResult InternalServerError()
        {
            return new StatusCodeResult(500);
        }

        [HttpGet("Result")]
        public ActionResult Result()
        {
            return Ok(_healthCheck.CheckHealthAsync().Result);
        }
    }
}
