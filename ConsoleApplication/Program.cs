using System;
using Services;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please try again informing the routes file path...");
                return;
            }

            while (true) // Loop indefinitely
            {
                var routeService = new RouteService();

                Console.WriteLine("Please enter the route: ");
                var route = Console.ReadLine();

                if (route.Equals("exit")) // Check string
                {
                    Console.WriteLine("Finished...");
                    break;
                }

                var splittedRoute = route.Split("-");

                if (args.Length > 0 && splittedRoute.Length == 2)
                {
                    var filePath = args[0];
                    var bestRoute = routeService.GetBestRoute($"{splittedRoute[0]}", $"{splittedRoute[1]}", filePath);
                    Console.WriteLine($"best route: {bestRoute}");
                }
                else
                {
                    Console.WriteLine("Please try again informing a valid route (FROM,TO) or type exit to finish...");
                }

                Console.ReadKey();

            }
        }
    }
}
