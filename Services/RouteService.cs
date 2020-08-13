using System;
using System.Collections.Generic;
using Core.Services;
using Core.Models;
using Infrastructure;

namespace Services
{
    public class RouteService : IRouteService
    {
        private readonly FileManager _fileManager;

        public RouteService()
        {
            _fileManager = new FileManager();
        }
        public List<Route> GetAllRoutes(String filepath) {
            List<Route> routes = _fileManager.GetRoutes(filepath);

            return routes;
        }

        public Route GetBestRoute(String from, String to, List<Route> routes) {
            throw new NotImplementedException();
        }

        public void AddRoutes(List<Route> routes) {
            throw new NotImplementedException();
        }
    }
}
