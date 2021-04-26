using Banking.Data.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Data.Implementation
{
    public class LocalFileProvider : ILocalFileProvider
    {
        private readonly string _contentRootPath;

        public LocalFileProvider(string contentRootPath)
        {
            _contentRootPath = contentRootPath;
        }

        public Task<string> GetFileContents(string filename)
        {
            string filePath = Path.Combine(_contentRootPath,
                @"bin\Debug\netcoreapp3.1\DataSource",
                //"DataSource",
                filename);

            return File.ReadAllTextAsync(filePath);
        }
    }
}
