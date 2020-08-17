﻿using System;
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
                Console.Beep();
                Console.WriteLine("\nPlease enter the route: [FROM-TO] - or type exit to finish");
                return;
            }

            while (true)
            {
                var routeService = new RouteService();

                Console.WriteLine("\nPlease enter the route: [FROM-TO] - or type exit to finish");
                var route = Console.ReadLine().ToUpper();

                if (route.Equals("exit"))
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

                    Console.WriteLine($"\n{bestRoute}");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.WriteLine("\n\nPlease a new route: [FROM-TO] - or type exit to finish");
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
