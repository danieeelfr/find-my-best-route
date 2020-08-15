using System.ComponentModel;
using System;
using System.Collections.Generic;
using Core.Services;
using System.IO;
using System.Text;
using Core.Models;
using Infrastructure;
using System.Linq;

namespace Services
{
    public class RouteService : IRouteService
    {
        // private const string FILE_PATH = "/home/daniel/Workspace/find-my-best-route/Resources/input-file.txt";

        private const string FILE_PATH = "/home/danielfr/Workspace/Pessoais/Challenges/find-my-best-route/Resources/input-file.txt";

        private readonly FileManager _fileManager;
        private Dictionary<List<Route>, int> possibleRoutes;
        private List<Route> partialRoutes;

        private List<string> result;

        private List<Route> allRoutes;

        public RouteService()
        {
            _fileManager = new FileManager();
        }

        public Route GetBestRoute(String from, String to)
        {
            allRoutes = GetAllRoutes(FILE_PATH);
            var sb = new StringBuilder();

            var directRoutes = allRoutes.FindAll(route =>
            {
                return route.getFrom().Equals(from) && route.getTo().Equals(to);
            });

            foreach (var directRoute in directRoutes)
            {
                sb.AppendLine($"{directRoute.getFrom()} - {directRoute.getTo()}");
            }

            var startRoutes = allRoutes.FindAll(route =>
           {
               return route.getFrom().Equals(from);
           });

            partialRoutes = new List<Route>();
            possibleRoutes = new Dictionary<List<Route>, int>();
            foreach (var route in startRoutes)
            {
                partialRoutes.Add(route);
                GetNextConnection(from, to, route);
            }




            return new Route();
        }

        private void GetNextConnection(String from, String to, Route route)
        {

            var connections = allRoutes.FindAll(r =>
            {
                return r.getFrom().Equals(route.getTo());
            });

            foreach (var connection in connections)
            {
                if (connection.getTo().Equals(to))
                {
                    partialRoutes.Add(connection);
                    Console.WriteLine("connection end found");
                    possibleRoutes.Add(new List<Route>(partialRoutes), 99);
                    partialRoutes.Clear();
                    continue;
                }
                else
                {
                    Console.WriteLine("connection partial found");
                    partialRoutes.Add(new Route()
                    {
                        From = connection.getFrom(),
                        To = connection.getTo()
                    });
                    GetNextConnection(from, to, connection);
                }
            }
        }

        private List<String> GetConnections(String from)
        {
            List<String> result = null;

            var connections = allRoutes.FindAll(route =>
            {
                return route.getTo().Equals(from);
            });

            if (connections.Count() > 0)
            {
                result = new List<String>();

                foreach (var connection in connections)
                {
                    result.Add(connection.getFrom());
                }
            }

            return result;
        }


        private List<Route> GetAllRoutes(String filepath)
        {
            List<string> data = _fileManager.GetFileData(filepath);
            List<Route> routes = new List<Route>();

            data.ForEach(value =>
            {
                string[] values = value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                Route route = new Route();
                route.setFrom(values[0]);
                route.setTo(values[1]);
                route.setPrice(Convert.ToDouble(values[2]));
                routes.Add(route);
            });

            return routes;
        }

        public void AddRoutes(List<Route> routes)
        {
            throw new NotImplementedException();
        }
    }
}
