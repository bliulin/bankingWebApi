using Banking.Data.Contracts;
using Banking.Data.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Data.Psd2
{
    public class Psd2AccountDataProvider : IAccountsDataProvider
    {
        public Task<string> GetAccountCurrency(string accountIban)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetClientAccounts(Guid clientId)
        {
            throw new NotImplementedException();
        }
    }
}
