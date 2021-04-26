using Banking.Data.Contracts;
using Banking.Data.Contracts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Data.Implementation
{
    public class AccountsDataProvider : IAccountsDataProvider
    {
        private readonly ILocalFileProvider _fileProvider;

        public AccountsDataProvider(ILocalFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public async Task<string> GetAccountCurrency(string accountIban)
        {
            string accountsJson = await _fileProvider.GetFileContents("accounts.json");

            var accounts = JsonConvert.DeserializeObject<List<Account>>(accountsJson);
            var account = accounts.FirstOrDefault(account => account.Iban == accountIban);

            if (account == null)
            {
                throw new ArgumentException($"No account was found for IBAN: {accountIban}");
            }

            return account.Currency;
        }

        public async Task<IEnumerable<Account>> GetClientAccounts(Guid clientId)
        {
            string accountsJson = await _fileProvider.GetFileContents("accounts.json");

            var accounts = JsonConvert.DeserializeObject<List<Account>>(accountsJson);
            var clientAccounts = clientId.CompareTo(Guid.Empty) == 0 ?
                accounts :
                accounts.Where(account => account.ResourceId == clientId);

            return clientAccounts;
        }
    }
}
