using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeatPulse.Core;

namespace WithBeatPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
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
    }
}
