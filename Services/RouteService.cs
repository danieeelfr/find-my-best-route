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
        private Dictionary<int, List<Route>> possibleRoutes;
        private List<Route> partialRoutes;

        private List<Route> allRoutes;

        public RouteService()
        {
            _fileManager = new FileManager();
        }

        public Route GetBestRoute(String from, String to)
        {
            allRoutes = GetAllRoutes(FILE_PATH);

            possibleRoutes = new Dictionary<int, List<Route>>();
            partialRoutes = new List<Route>();

            // SetPossibleRoutes(allRoutes, from, to);
            SetAllPossibleRoutes(from, to);

            foreach (var possibleRoute in possibleRoutes)
            {
                Console.WriteLine("Index: " + possibleRoute.Key);
                StringBuilder sb = new StringBuilder();
                foreach (var route in possibleRoute.Value)
                {
                    sb.Append(route.getFrom() + " - " + route.getTo() + " - ");
                    // Console.WriteLine("Route found..." + route.getFrom() + " - " + route.getTo() + " - " + route.getPrice());
                }
                Console.WriteLine(sb.ToString());
            }

            return new Route();
        }

        private void SetAllPossibleRoutes(String from, String to, int index = 1)
        {

            // var index = 1;
            foreach (Route route in allRoutes)
            {
                index++;

                if (route.getFrom().Equals(from) &&
                   route.getTo().Equals(to))
                {
                    var directRoutes = new List<Route>();
                    directRoutes.Add(route);
                    possibleRoutes.Add(index, directRoutes);
                    partialRoutes.Clear();

                    continue;
                }

                // check who arrive there
                if (route.getTo().Equals(to) || route.getFrom().Equals(from))
                {
                    partialRoutes.Add(route);

                    // Console.WriteLine("Partial " + route.getFrom() + " - " + route.getTo() + " - " + route.getPrice());

                    // check the start point
                    if (route.getFrom().Equals(from) &&
                        !route.getTo().Equals(to))
                    {
                        possibleRoutes.Add(index, new List<Route>(partialRoutes));
                        partialRoutes.Clear();
                        continue;
                    }
                    else
                    {
                        SetAllPossibleRoutes(route.getTo(), route.getFrom(), index);
                    }
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

        public void AddRoutes(List<Route> routes)
        {
            throw new NotImplementedException();
        }
    }
}
