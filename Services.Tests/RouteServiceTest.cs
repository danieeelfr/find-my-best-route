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
            List<Route> routes = _routeService.GetAllRoutes("/home/danielfr/Desktop/test/input-file.txt");

            routes.ForEach(x =>
            {
                Console.WriteLine(x.getFrom() + "," + x.getTo() + "," + x.getPrice());
            });
        }
    }
}
