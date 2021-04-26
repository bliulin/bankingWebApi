using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transaction = Banking.Data.Contracts.Models.Transaction;

namespace Banking.Data.Contracts
{
    public interface ITransactionsDataProvider
    {       
        Task<IEnumerable<Transaction>> GetTransactions(string accountIban);
    }
}
