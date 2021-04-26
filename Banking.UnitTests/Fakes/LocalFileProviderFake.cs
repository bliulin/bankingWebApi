using Banking.Data.Contracts;
using Banking.Data.Contracts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests.Fakes
{
    public class LocalFileProviderFake : ILocalFileProvider
    {
        public List<Account> Accounts { get; set; } = new List<Account>();

        public Task<string> GetFileContents(string filename)
        {
            string contents = string.Empty;

            if (filename == "accounts.json")
            {
                contents = JsonConvert.SerializeObject(Accounts);               
            }

            return Task.FromResult(contents);
        }
    }
}
