using System;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase
    {
        private const String DEFAULT_FILE_PATH = "Resources/input-file.txt";
        private readonly RouteService _routeService;
        private readonly ILogger<RouteController> _logger;

        public RouteController(ILogger<RouteController> logger)
        {
            _logger = logger;
            _routeService = new RouteService();
        }

        [HttpGet("{from}/{to}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public String GetBestRoute(String from, String to, String filePath = DEFAULT_FILE_PATH)
        {
            // if (String.IsNullOrWhiteSpace(filePath))
            // {
            //     filePath = DEFAULT_FILE_PATH;
            // }
            return _routeService.GetBestRoute(from.ToUpper(), to.ToUpper(), filePath);
        }
    }
}
