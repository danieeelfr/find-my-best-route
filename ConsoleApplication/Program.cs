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

            var routeService = new RouteService();

            Console.WriteLine("Please enter the route: ");
            var route = Console.ReadLine().Split("-");

            if (args.Length > 0 && route.Length == 2)
            {
                var filePath = args[0];
                var bestRoute = routeService.GetBestRoute($"{route[0]}", $"{route[1]}", filePath);
                Console.WriteLine($"best route: {bestRoute}");
            }
            else
            {
                Console.WriteLine("Please try again informing a valid route (FROM,TO)...");
            }

            Console.ReadKey();
        }
    }
}
