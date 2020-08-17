using System;
using Xunit;
using Services;
using System.Collections.Generic;
using Core.Models;


namespace Services.Tests
{

    public class RouteServiceTest
    {
        private const string FILE_PATH = "/home/danielfr/Workspace/Pessoais/Challenges/find-my-best-route/Resources/input-file.txt";
        private readonly RouteService _routeService;

        public RouteServiceTest()
        {
            _routeService = new RouteService();
        }

        [Fact]
        public void Test1()
        {
            var bestRoute = _routeService.GetBestRoute("GRU", "CDG", FILE_PATH);

            Assert.Equal("GRU - BRC - SCL - ORL - CDG", bestRoute);

        }

        [Fact]
        public void Test2()
        {
            var newRoutes = new List<Route>();
            var route = new Route();
            route.setFrom("BRL");
            route.setTo("ARG");
            route.setPrice(50);

            newRoutes.Add(route);
            _routeService.AddRoutes(newRoutes, FILE_PATH);
        }
    }
}
