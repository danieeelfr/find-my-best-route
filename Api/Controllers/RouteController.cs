using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly RouteService _routeService;
        private readonly ILogger<RouteController> _logger;

        public RouteController(ILogger<RouteController> logger)
        {
            _logger = logger;
            _routeService = new RouteService();
        }

        [HttpPost]
        public String GetBestRoute(Route route, String filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath)) {
                
                filePath = "Api/Resources/input-file.txt";
            }
           return _routeService.GetBestRoute(route.getFrom(), route.getTo(), filePath);
        }
    }
}
