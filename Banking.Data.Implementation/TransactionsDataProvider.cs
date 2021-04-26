using Banking.Data.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction = Banking.Data.Contracts.Models.Transaction;

namespace Banking.Data.Implementation
{
    public class TransactionsDataProvider : ITransactionsDataProvider
    {
        private readonly ILocalFileProvider _fileProvider;

        public TransactionsDataProvider(ILocalFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions(string accountIban)
        {
            var transactions = await _fileProvider.GetTransactions();
            return transactions.Where(t => t.Iban == accountIban);
        }
    }
}
