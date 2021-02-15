using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    internal class CSVReader : IDisposable
    {
        private StreamReader _reader;

        public CSVReader(string fileName)
        {
            string extension = fileName.Split('.').Last();
            if (extension != "csv")
            {
                throw new FileLoadException("The file extension was not .csv.");
            }

            _reader = new StreamReader(fileName);
        }

        public async Task<string[]> ReadLineAsync()
        {
            string line = await _reader.ReadLineAsync();
            return line.Split(',');
        }

        public void Dispose() => _reader.Dispose();
    }
}
