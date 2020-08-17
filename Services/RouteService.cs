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
        // private const string FILE_PATH = "/home/danielfr/Workspace/Pessoais/Challenges/find-my-best-route/Resources/input-file.txt";

        private readonly FileManager _fileManager;
        private Dictionary<List<Route>, double> possibleRoutes;
        private List<Route> partialRoutes;
        private List<Route> allRoutes;

        public RouteService()
        {
            _fileManager = new FileManager();
        }

        public String GetBestRoute(String from, String to, String filePath)
        {
            allRoutes = GetAllRoutes(filePath);

            var directRoutes = allRoutes.FindAll(route =>
            {
                return route.getFrom().Equals(from) && route.getTo().Equals(to);
            });

            partialRoutes = new List<Route>();
            possibleRoutes = new Dictionary<List<Route>, double>();

            foreach (var directRoute in directRoutes)
            {
                partialRoutes.Add(directRoute);
                possibleRoutes.Add(new List<Route>(partialRoutes), directRoute.getPrice());
                partialRoutes.Clear();
            }

            var startRoutes = allRoutes.FindAll(route =>
            {
                return route.getFrom().Equals(from);
            });

            foreach (var route in startRoutes)
            {
                if (route.getFrom().Equals(from) && route.getTo().Equals(to))
                {
                    continue;
                }

                partialRoutes.Add(route);
                GetNextConnection(from, to, route);
            }

            var bestRoute = GetBestRoute();

            if (bestRoute == null)
            {
                return "Ooopss... No route found!";
            }

            List<string> result = new List<string>();


            foreach (var stop in bestRoute)
            {
                result.Add(stop.getFrom());
            }

            var sb = new StringBuilder("Best route: ");

            foreach (var r in result)
            {
                sb.Append($"{r} - ");
            }

            sb.Append(to);
            sb.Append($" > ${bestRoute.Sum(price => price.getPrice())}");

            return sb.ToString();

        }

        private void GetNextConnection(String from, String to, Route route)
        {

            var connections = allRoutes.FindAll(r =>
            {
                return r.getFrom().Equals(route.getTo());
            });

            foreach (var connection in connections)
            {
                if (connection.getFrom().Equals(from) && connection.getTo().Equals(to))
                {
                    return;
                }

                if (connection.getTo().Equals(to))
                {
                    partialRoutes.Add(connection);
                    possibleRoutes.Add(new List<Route>(partialRoutes),
                    partialRoutes.Sum(route => route.getPrice()));
                    partialRoutes.Clear();
                    continue;
                }
                else
                {
                    partialRoutes.Add(new Route()
                    {
                        From = connection.getFrom(),
                        To = connection.getTo(),
                        Price = connection.getPrice()
                    });
                    GetNextConnection(from, to, connection);
                }
            }
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

        private List<Route> GetBestRoute()
        {
            var result = possibleRoutes.OrderBy(route => route.Value);

            return result.FirstOrDefault().Key;
        }

        public void AddRoutes(List<Route> routes, String filePath)
        {
            List<string> data = new List<string>();

            foreach (var route in routes)
            {
                data.Add($"{route.getFrom()},{route.getTo()},{route.getPrice()}");
            }

            _fileManager.AddData(filePath, data, true);

        }
    }
}