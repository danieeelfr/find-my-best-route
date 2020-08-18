using System;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Core.Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase
    {
        private const String DEFAULT_FILE_PATH = "Resources/input-file.txt";
        private readonly RouteService _routeService;

        public RouteController()
        {
            _routeService = new RouteService();
        }

        [HttpGet("{from}/{to}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public String GetBestRoute(String from, String to, String filePath = DEFAULT_FILE_PATH)
        {
            return _routeService.GetBestRoute(from.ToUpper(), to.ToUpper(), filePath);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void AddRoute([FromBody] List<RouteDTO> routesDTO, String filePath = DEFAULT_FILE_PATH)
        {
            var routes = new List<Route>();

            foreach (var item in routesDTO)
            {
                routes.Add(new Route() {
                    From = item.getFrom(),
                    To = item.getTo(),
                    Price = item.getPrice()
                });
            }

            _routeService.AddRoutes(routes, filePath);
        }
    }
}
