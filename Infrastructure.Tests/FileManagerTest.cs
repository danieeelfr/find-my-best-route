using System.Diagnostics;
using System;
using Xunit;
using Infrastructure;
using Core;
using Core.Models;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure.Tests
{
    public class FileManagerTest
    {
        private const string VALID_FILE_PATH = "/home/danielfr/Workspace/Pessoais/Challenges/find-my-best-route/Resources/input-file.txt";
        private const string INVALID_FILE_PATH = "/invalid/input-file.txt";

        private readonly FileManager _fileManager;

        public FileManagerTest()
        {
            _fileManager = new FileManager();
        }

        [Fact]
        public void GetFileDataWithValidFileShouldReturnRoutesWithSuccess()
        {
            var routes = _fileManager.GetFileData(VALID_FILE_PATH);

            Assert.NotNull(routes);
            Assert.True(routes.Count > 0);
        }

        [Fact]
        public void AddDataWithValidFileShouldSaveWithSuccess()
        {
            List<string> originalData = new List<string>();
            originalData.Add("GRU,BRC,10");
            originalData.Add("BRC,SCL,5");
            originalData.Add("GRU,CDG,75");
            originalData.Add("GRU,SCL,20");
            originalData.Add("GRU,ORL,56");
            originalData.Add("ORL,CDG,5");
            originalData.Add("SCL,ORL,20");
         
            _fileManager.AddData(VALID_FILE_PATH, originalData, false);
            _fileManager.GetFileData(VALID_FILE_PATH);

            var dataAfter = _fileManager.GetFileData(VALID_FILE_PATH);

            Assert.Equal(originalData.Count, dataAfter.Count);

        }
    }
}