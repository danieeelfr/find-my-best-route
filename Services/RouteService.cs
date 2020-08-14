using System.ComponentModel;
using System;
using System.Collections.Generic;
using Core.Services;
using Core.Models;
using Infrastructure;
using System.Linq;

namespace Services
{
    public class RouteService : IRouteService
    {

        private const string FILE_PATH = "/home/daniel/Workspace/find-my-best-route/Resources/input-file.txt";
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

                foreach (var route in possibleRoute.Value)
                {
                    Console.WriteLine("Route found..." + route.getFrom() + " - " + route.getTo() + " - " + route.getPrice());
                }
            }

            return new Route();
        }

        private void SetAllPossibleRoutes(String from, String to)
        {

            var index = 1;
            foreach (Route route in allRoutes)
            {
                if (route.getFrom().Equals(from) &&
                   route.getTo().Equals(to))
                {
                    var directRoutes = new List<Route>();
                    directRoutes.Add(route);
                    possibleRoutes.Add(index, directRoutes);

                    index++;
                    //return;
                }

                // check who arrive there
                if (route.getTo().Equals(to))
                {
                    partialRoutes.Add(route);

                    Console.WriteLine("Partial " + route.getFrom() + " - " + route.getTo() + " - " + route.getPrice());
                    
                    SetAllPossibleRoutes(route.getTo(), route.getFrom());
                }
            }
        }

        private void SetPossibleRoutes(List<Route> routes, String from, String to)
        {
            List<Route> allRoutes = routes;
            List<Route> partialRoutes = new List<Route>();

            int index = 1;
            var partialRoute = new List<Route>();
            foreach (Route route in routes)
            {
                // check direct route
                if (route.getFrom().Equals(from) &&
                    route.getTo().Equals(to))
                {
                    var directRoutes = new List<Route>();
                    directRoutes.Add(route);
                    possibleRoutes.Add(index, directRoutes);
                    partialRoutes.Clear();
                    index++;
                    return;
                }

                // check how arrived there
                if (route.getTo().Equals(to) &&
                    !route.getFrom().Equals(from))
                {

                    partialRoute.Add(route);

                    var nextRoutes = routes.FindAll(x => x.getFrom().Equals(route.getTo()));

                    foreach (var r in nextRoutes)
                    {
                        // check how arrived there
                        if (r.getTo().Equals(to) &&
                            !r.getFrom().Equals(from))
                        {
                            partialRoute.Add(route);
                        }


                    }

                    // possibleRoutes.Add(index, partialRoute);
                    partialRoutes.Clear();
                    index++;
                    return;

                    partialRoutes.Add(route);


                }
            }


            // routes
            // //.Where(route => route.getTo().Equals(to))
            // .Select(route => route)
            // .ToList()
            // .ForEach(route =>
            // {  
            //     Console.WriteLine("Routes size: " + allRoutes.Count);
            //     allRoutes.Remove(route);

            //     if ((route.getTo().Equals(to) || 
            //          route.getFrom().Equals(from)))
            //     {
            //         Console.WriteLine("Route found..." + route.getFrom() + " - " + route.getTo() + " - " + route.getPrice());
            //         possibleRoutes.AddRange(partialRoutes);
            //         var temp = partialRoutes;
            //         result.Insert(0, temp);

            //         partialRoutes.RemoveAll(r => r != null); 

            //     } else {

            //     }

            //});


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
