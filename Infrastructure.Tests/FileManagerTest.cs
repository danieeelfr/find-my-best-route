using System.Diagnostics;
using System;
using Xunit;
using Infrastructure;
using Core;
using Core.Models;
using System.Collections.Generic;

namespace Infrastructure.Tests
{
    public class FileManagerTest
    {
        private readonly FileManager _fileManager;

        public FileManagerTest()
        {
            _fileManager = new FileManager();
        }

        [Fact]
        public void Test1()
        {
            List<Route> routes = _fileManager.GetRoutes();
            Console.WriteLine("routes tested: " + routes.Count);

            routes.ForEach(x => {
                Console.WriteLine(x.getFrom() + "," + x.getTo() + "," + x.getPrice());
            });
        }
    }
}
