using System;
using Xunit;
using Services;
using System.Collections.Generic;
using Core.Models;


namespace Services.Tests
{

    public class RouteServiceTest
    {
        private readonly RouteService _routeService;

        public RouteServiceTest()
        {
            _routeService = new RouteService();
        }

        [Fact]
        public void Test1()
        {
            Route route = _routeService.GetBestRoute("GRU", "CDG");

            Console.WriteLine(route);

            
        }
    }
}
