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
        private readonly FileManager _fileManager;
        private List<Route> possibleRoutes;
         private List<List<Route>> result;

        public RouteService()
        {
            _fileManager = new FileManager();
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
        int count = 0;
        public Route GetBestRoute(String from, String to)
        {
            List<Route> allRoutes = GetAllRoutes("/home/danielfr/Desktop/test/input-file.txt");
            Console.WriteLine("all routes:");
          
            // allRoutes.RemoveAll(route => !route.getFrom().Equals(from) &&
            //                          !route.getTo().Equals(to));

            // Console.WriteLine("after deleted routes:");
            // allRoutes.ForEach(r =>
            // {
            //     Console.WriteLine(r.getFrom() + " - " + r.getTo());
            // });

            possibleRoutes = new List<Route>();
            result = new List<List<Route>>();

            SetPossibleRoutes(ref allRoutes, from, to);
            Console.WriteLine("possible routes:" + result.Count);
            // if (possibleRoutes == null)
            // {
            //     possibleRoutes = new List<Route>();
            // }

            result.ForEach(r =>
            {
                
                r.ForEach(x => {
                    Console.WriteLine(x.getFrom() + ", " + x.getTo());
                });
                
            });

            return new Route();
        }

        private void SetPossibleRoutes(ref List<Route> routes, String from, String to)
        {
            List<Route> allRoutes = routes;
            List<Route> partialRoutes = new List<Route>();
           

            routes
            //.Where(route => route.getTo().Equals(to))
            .Select(route => route)
            .ToList()
            .ForEach(route =>
            {  
                Console.WriteLine("Routes size: " + allRoutes.Count);
                allRoutes.Remove(route);

                if ((route.getTo().Equals(to) || 
                     route.getFrom().Equals(from)) && 
                    !possibleRoutes.Contains(route))
                {
                    Console.WriteLine("Route found..." + route.getFrom());
                    possibleRoutes.AddRange(partialRoutes);
                    var temp = partialRoutes;
                    result.Insert(0, temp);
                    
                    partialRoutes.RemoveAll(r => r != null); 

                } else {
                    
                }

            });

            if (allRoutes.Count > 0)
            {
                count = count + 1;
                Console.WriteLine("new recoursive round... " + allRoutes.Count);
                routes = allRoutes;
                SetPossibleRoutes(ref routes, from, to);
            }
            else
                routes = allRoutes;
        }

        public void AddRoutes(List<Route> routes)
        {
            throw new NotImplementedException();
        }
    }
}
