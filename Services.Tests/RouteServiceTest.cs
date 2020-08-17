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

        [Theory]
        [InlineData("GRU", "CDG", "GRU - BRC - SCL - ORL - CDG")]
        // [InlineData(-4, -6, -10)]
        // [InlineData(-2, 2, 0)]
        public void GetBestRouteWithValidFileAndRoutesShouldReturnWithSuccess(string from, string to, string expected)
        {
            var bestRoute = _routeService.GetBestRoute(from, to, FILE_PATH);
            Assert.Equal(expected, bestRoute);
        }

        [Fact]
        public void AddMultipleRoutesWithValidFileShouldSaveDataWithSuccess()
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