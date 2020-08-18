using System;
using Services;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            if (!ValidateInputParameter(args))
                return;

            while (true)
            {
                Console.WriteLine("\nPlease enter the route: [FROM-TO] - or type exit to finish");
                var route = Console.ReadLine().ToUpper();

                if (route.Equals("EXIT"))
                {
                    Console.ResetColor();
                    Console.WriteLine("\nFinished...");
                    break;
                }

                var splittedRoute = route.Split("-");

                if (args.Length > 0 && splittedRoute.Length == 2)
                {
                    FindBestRoute(args, splittedRoute);
                }
                else
                {
                    SetConsoleColors(true);
                    Console.WriteLine("\nPlease try again informing a valid route (FROM,TO) or type exit to finish...");
                }

                Console.ReadKey();

            }
        }

        private static void FindBestRoute(string[] args, string[] splittedRoute)
        {
            var routeService = new RouteService();

            var filePath = args[0];
            var bestRoute = routeService.GetBestRoute($"{splittedRoute[0]}", $"{splittedRoute[1]}", filePath);
            Console.Clear();

            if (!bestRoute.Contains("No route found"))
                SetConsoleColors(false);
            else
                SetConsoleColors(false);

            Console.WriteLine($"\n{bestRoute}\n");
            Console.ResetColor();
        }

        private static bool ValidateInputParameter(string[] args)
        {
            if (args.Length == 0)
            {
                SetConsoleColors(true);
                Console.WriteLine("\nPlease try again passing the routes file path. \n> Example: dotnet run c:\\find-my-best-route\\Resources\\input-file.txt\n\n");
                return false;
            }

            return true;
        }

        private static void SetConsoleColors(bool isErrorMode)
        {
            if (isErrorMode)
            {
                Console.Beep();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}