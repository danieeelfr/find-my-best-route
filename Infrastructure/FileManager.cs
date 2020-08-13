using System;
using System.IO;
using Core;
using Core.Models;
using System.Collections.Generic;

namespace Infrastructure
{
    public class FileManager
    {
        public List<Route> GetRoutes()
        {
            List<Route> routes = new List<Route>();

            String line;
            try
            {
                StreamReader sr = new StreamReader("/home/danielfr/Desktop/test/input-file.txt");

                line = sr.ReadLine();

                while (line != null)
                {
                    List<string> values = new List<string>(line.Split(new string[] { "," }, StringSplitOptions.None));
                    Route route = new Route();
                    route.setFrom(values[0]);
                    route.setTo(values[1]);
                    route.setPrice(Convert.ToDouble(values[2]));

                    routes.Add(route);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            
            return routes;
        }
    }
}
