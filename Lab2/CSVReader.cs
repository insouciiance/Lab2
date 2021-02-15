using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class CSVReader
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
    }
}
