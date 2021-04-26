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
            string transactionsJson = await _fileProvider.GetFileContents("transactions.json");

            //TODO make fileProvider generic and return data directly
            var transactions = JsonConvert.DeserializeObject<List<Transaction>>(transactionsJson);

            return transactions.Where(t => t.Iban == accountIban);
        }

        //public async Task<IEnumerable<Transaction>> GetTransactionsForLastMonth(DateTimeOffset offset, string accountIban)
        //{
        //    string transactionsJson = await _fileProvider.GetFileContents("transactions.json");

        //    //TODO make fileProvider generic and return data directly
        //    var transactions = JsonConvert.DeserializeObject<List<Transaction>>(transactionsJson);

        //    int previousMonth = offset.Month - 1;
        //    //var result = transactions
        //    //    .Where(t => t.Iban == accountIban)
        //    //    .Where(t=>DateTime.Parse(t.TransactionDate).Month == previousMonth)
        //    //    .GroupBy()

        //    var result = transactions
        //        .GroupBy(t => t.CategoryId, (categId) => 
        //            new 
        //            {
                        
        //            });
        //}
    }
}
