using Banking.Data.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Data.Contracts
{
    public interface ILocalFileProvider
    {
        //Task<string> GetFileContents(string filename);

        //Task<IEnumerable<T>> GetEntities()

        Task<IEnumerable<Account>> GetAccounts();

        Task<IEnumerable<Transaction>> GetTransactions();
    }
}
