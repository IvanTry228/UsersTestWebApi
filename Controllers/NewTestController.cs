using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersTestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewTestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<NewTestController> _logger;

        public NewTestController(ILogger<NewTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get1")]
        public string Get()
        {
            return "ping1";
        }

        [HttpGet("get2")]
        public string Get2()
        {
            return "ping2";
        }
    }
}
