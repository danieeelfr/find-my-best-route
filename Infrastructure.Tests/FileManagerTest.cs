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
            List<string> routes = _fileManager.GetFileData("/home/danielfr/Desktop/test/input-file.txt");
            Console.WriteLine("routes tested: " + routes.Count);

            routes.ForEach(x => {
                Console.WriteLine(x);
            });
        }
    }
}
