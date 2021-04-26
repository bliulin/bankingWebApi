using Banking.Business.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transaction = Banking.Data.Contracts.Models.Transaction;

namespace Banking.Business.Contracts
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionReportModel>> GetTransactionsForLastMonth(DateTimeOffset offset, string accountIban);
    }
}
