using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    public class CSVReader : IDisposable
    {
        private readonly StreamReader _reader;

        public CSVReader(string fileName)
        {
            FileInfo csvFileInfo = new FileInfo(fileName);
            if (csvFileInfo.Extension != ".csv")
            {
                throw new FileLoadException("The file extension was not .csv.");
            }

            if (!csvFileInfo.Exists)
            {
                throw new FileNotFoundException();
            }

            _reader = new StreamReader(fileName);
        }

        public async Task<string[]> ReadLineAsync()
        {
            string line = await _reader.ReadLineAsync();
            return line?.Split(',');
        }

        public static async Task<string[][]> ReadAllDirectoryAsync(string directory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            if (!directoryInfo.Exists)
            {
                return new string[0][];
            }

            List<string[]> lines = new List<string[]>();

            foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.csv", SearchOption.AllDirectories))
            {
                using CSVReader csvReader = new CSVReader(fileInfo.FullName);
                string[] lineData;

                while ((lineData = await csvReader.ReadLineAsync()) != null)
                {
                    lines.Add(lineData);
                }
            }

            return lines.ToArray();
        }

        public void Dispose() => _reader.Dispose();
    }
}
