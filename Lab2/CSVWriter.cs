using System;
using System.IO;
using System.Threading.Tasks;

namespace Lab2
{
    public class CSVWriter : IDisposable
    {
        private readonly StreamWriter _writer;

        public CSVWriter(string fileName)
        {
            FileInfo csvFileInfo = new FileInfo(fileName);
            if (csvFileInfo.Extension != ".csv")
            {
                throw new FileLoadException("The file extension was not .csv.");
            }

            _writer = new StreamWriter(fileName);
        }

        public async Task WriteLineAsync(params object[] values) => await _writer.WriteLineAsync(string.Join(",", values ?? new object[0]));

        public void Dispose() => _writer.Dispose();
    }
}
