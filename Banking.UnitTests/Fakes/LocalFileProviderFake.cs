using Banking.Data.Contracts;
using Banking.Data.Contracts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests.Fakes
{
    public class LocalFileProviderFake : ILocalFileProvider
    {
        public List<Account> Accounts { get; set; } = new List<Account>();

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Task<IEnumerable<Account>> GetAccounts()
        {
            return Task.FromResult(Accounts.AsEnumerable());
        }

        public Task<IEnumerable<Transaction>> GetTransactions()
        {
            return Task.FromResult(Transactions.AsEnumerable());
        }
    }
}
