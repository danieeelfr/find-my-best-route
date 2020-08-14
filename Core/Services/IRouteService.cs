using System;
using System.Collections.Generic;
using Core.Services;
using Core.Models;

namespace Core.Services
{
    public interface IRouteService
    {
        Route GetBestRoute(String from, String to);

        void AddRoutes(List<Route> routes);

    }
}