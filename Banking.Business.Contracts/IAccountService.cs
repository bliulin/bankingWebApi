using Banking.Business.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Business.Contracts
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountModel>> GetClientAccounts(Guid clientId);
    }
}
