using System;
using System.Collections.Generic;
using Core.Services;
using Core.Models;

namespace Core.Services
{
    public interface IRouteService
    {
        List<Route> GetAllRoutes(String filepath);

        Route GetBestRoute(String from, String to, List<Route> routes);

        void AddRoutes(List<Route> routes);

    }
}