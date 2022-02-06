using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Eve.Models;
using Eve.Repositories;

namespace Eve.Controllers
{
    [ApiController]
    public class AirQualityController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMeasurementRepository _repository;

        public AirQualityController(ILogger<HomeController> logger, IMeasurementRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("api/airquality")]
        [ProducesResponseType(Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType(Microsoft.AspNetCore.Http.StatusCodes.Status503ServiceUnavailable)]
        public IActionResult AirQuality()
        {
            AirQuality data = new AirQuality(_repository);

            return new JsonResult(data);
        }
    }
}
