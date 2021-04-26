using Banking.Data.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Data.Contracts
{
    public interface IAccountsDataProvider
    {
        Task<IEnumerable<Account>> GetClientAccounts(Guid clientId);
    }
}
