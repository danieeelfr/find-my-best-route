using System;
using System.IO;
using Core;
using Core.Models;
using System.Collections.Generic;

namespace Infrastructure
{
    public class FileManager
    {
        public List<string> GetFileData(String filepath)
        {
            List<string> data = new List<string>();

            String line;
            try
            {
                StreamReader sr = new StreamReader(filepath);

                line = sr.ReadLine();

                while (line != null)
                {
                    data.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            
            return data;
        }
    }
}
