using System;
using System.Collections.Generic;
using Core.Models;

namespace Core.Services
{
    public interface IRouteService
    {
        String GetBestRoute(String from, String to, String filePath);

        void AddRoutes(List<Route> routes, String filePath);

    }
}