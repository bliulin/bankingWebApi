using Banking.Data.Contracts;
using Banking.Data.Contracts.Models;
using Newtonsoft.Json;
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

        public Task<IEnumerable<Account>> GetAccounts()
        {
            return GetFileContents<Account>("accounts.json");
        }

        public Task<IEnumerable<Transaction>> GetTransactions()
        {
            return GetFileContents<Transaction>("transactions.json");
        }

        private async Task<IEnumerable<T>> GetFileContents<T>(string filename)
        {
            string dataSourceFolder = "DataSource";

#if DEBUG
            dataSourceFolder = @"bin\Debug\netcoreapp3.1\DataSource";
#endif

            string filePath = Path.Combine(_contentRootPath,
                dataSourceFolder,
                filename);

            string contents = await File.ReadAllTextAsync(filePath);
            var collection = JsonConvert.DeserializeObject<IEnumerable<T>>(contents);
            return collection;
        }
    }
}
