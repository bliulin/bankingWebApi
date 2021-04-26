using Banking.Business.Contracts;
using Banking.Business.Contracts.Models;
using Banking.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Business.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountsDataProvider _accountsDataProvider;

        public AccountService(IAccountsDataProvider accountsDataProvider)
        {
            _accountsDataProvider = accountsDataProvider;
        }

        public async Task<IEnumerable<AccountModel>> GetClientAccounts(Guid clientId)
        {
            var items = await _accountsDataProvider.GetClientAccounts(clientId);

            return items.Select(item => new AccountModel
            {
                Currency = item.Currency,
                Iban = item.Iban,
                Name = item.Name,
                Product = item.Product,
                ResourceId = item.ResourceId
            });
        }
    }
}
