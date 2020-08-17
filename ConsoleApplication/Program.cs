using System;
using Services;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            if (args.Length == 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Beep();
                Console.WriteLine("\nPlease try again passing the routes file path. \n> Example: dotnet run c:\\find-my-best-route\\Resources\\input-file.txt\n\n");
                return;
            }

            while (true)
            {
                var routeService = new RouteService();

                Console.WriteLine("\nPlease enter the route: [FROM-TO] - or type exit to finish");
                var route = Console.ReadLine().ToUpper();

                if (route.Equals("EXIT"))
                {
                    Console.WriteLine("\nFinished...");
                    break;
                }

                var splittedRoute = route.Split("-");

                if (args.Length > 0 && splittedRoute.Length == 2)
                {
                    var filePath = args[0];
                    var bestRoute = routeService.GetBestRoute($"{splittedRoute[0]}", $"{splittedRoute[1]}", filePath);
                    Console.Clear();

                    if (!bestRoute.Contains("No route found"))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine($"\n{bestRoute}\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Beep();
                    Console.WriteLine("\nPlease try again informing a valid route (FROM,TO) or type exit to finish...");
                }

                Console.ReadKey();

            }
        }
    }
}
