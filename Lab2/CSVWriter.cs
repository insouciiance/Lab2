﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class CSVWriter : IDisposable
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
