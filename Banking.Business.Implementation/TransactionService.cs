using Banking.Business.Contracts;
using Banking.Business.Contracts.Models;
using Banking.Data.Contracts;
using Banking.Data.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Business.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionsDataProvider _transactionsDataProvider;
        private readonly IAccountsDataProvider _accountsDataProvider;

        public TransactionService(ITransactionsDataProvider transactionsDataProvider,
            IAccountsDataProvider accountsDataProvider)
        {
            _transactionsDataProvider = transactionsDataProvider;
            _accountsDataProvider = accountsDataProvider;
        }

        public async Task<IEnumerable<TransactionReportModel>> GetTransactionsForLastMonth(DateTimeOffset offset, string accountIban)
        {
            var transactions = await _transactionsDataProvider.GetTransactions(accountIban);
            string accountCurrency = await _accountsDataProvider.GetAccountCurrency(accountIban);

            //TODO: filter by date

            var result = transactions
                .GroupBy(t => t.CategoryId)
                .Select(group => new TransactionReportModel
                {
                    CategoryName = ((TransactionCategory)group.Key).ToFriendlyString(),
                    TotalAmount = group.Sum(t => t.Amount),
                    Currency = accountCurrency
                });

            return result;
        }
    }
}
