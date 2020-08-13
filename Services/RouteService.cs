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
            List<string> data = _fileManager.GetFileData(filepath);
            
            List<Route> routes = new List<Route>();


            data.ForEach(value => {

                string[] values = value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                
                Route route = new Route();
                    route.setFrom(values[0]);
                    route.setTo(values[1]);
                    route.setPrice(Convert.ToDouble(values[2]));

                    routes.Add(route);
            });

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
