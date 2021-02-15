using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class CSVWriter
    {
        private StreamWriter _writer;

        public CSVWriter(string fileName)
        {
            string extension = fileName.Split('.').Last();
            if (extension != "csv")
            {
                throw new FileLoadException("The file extension was not .csv.");
            }

            _writer = new StreamWriter(fileName);
        }

        public async Task WriteLineAsync(params object[] values)
        {
            if (values == null)
            {
                return;
            }

            foreach (object value in values)
            {
                await _writer.WriteAsync(value?.ToString());
            }

            await _writer.WriteAsync(Environment.NewLine);
        }
    }
}
