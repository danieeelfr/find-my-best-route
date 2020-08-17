using System;
using System.IO;
using System.Text;
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
                return null;
            }

            return data;
        }

        public void AddData(String filePath, List<string> data, bool append)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, append, Encoding.ASCII);

                foreach (var line in data)
                {

                    sw.WriteLine($"{line}");
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
