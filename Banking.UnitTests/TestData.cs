using Banking.Data.Contracts.Models;
using Banking.UnitTests.Fakes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.UnitTests
{
    public static class TestData
    {
        public static LocalFileProviderFake GetWithSingleAccount()
        {
            var accountsProvider = new LocalFileProviderFake();
            accountsProvider.Accounts.AddRange(new List<Account>()
            {
                new Account
                {
                    Currency="EUR",
                    Iban="450ffbb8-9f11-4ec6-a1e1-df48aefc82ef",
                    Name="Hr A van Dijk , Mw B Mol-van Dijk",
                    Product="Betaalrekening",
                    ResourceId=new Guid("450ffbb8-9f11-4ec6-a1e1-df48aefc82ef")
                }
            });
            return accountsProvider;
        }

        public static LocalFileProviderFake GetWithTwoAccountsForSameCustomer()
        {
            var accountsProvider = new LocalFileProviderFake();
            accountsProvider.Accounts.AddRange(new List<Account>()
            {
                new Account
                {
                    Currency="EUR",
                    Iban="450ffbb8-9f11-4ec6-a1e1-df48aefc82ef",
                    Name="Hr A van Dijk , Mw B Mol-van Dijk",
                    Product="Betaalrekening",
                    ResourceId=new Guid("450ffbb8-9f11-4ec6-a1e1-df48aefc82ef")
                },
                 new Account
                {
                    Currency="USD",
                    Iban="450ffbb8-9f11-4ec6-a1e1-df48aefc1234",
                    Name="Hr A van Dijk , Mw B Mol-van Dijk",
                    Product="Betaalrekening",
                    ResourceId=new Guid("450ffbb8-9f11-4ec6-a1e1-df48aefc82ef")
                }
            });
            return accountsProvider;
        }

        public static LocalFileProviderFake GetWithManyClientAccountsData()
        {
            var accountsProvider = new LocalFileProviderFake();
            accountsProvider.Accounts.AddRange(new List<Account>()
            {
                new Account
                {
                    Currency="EUR",
                    Iban="450ffbb8-9f11-4ec6-a1e1-df48aefc82ef",
                    Name="Hr A van Dijk , Mw B Mol-van Dijk",
                    Product="Betaalrekening",
                    ResourceId=new Guid("450ffbb8-9f11-4ec6-a1e1-df48aefc82ef")
                },
                 new Account
                {
                    Currency="USD",
                    Iban="450ffbb8-9f11-4ec6-a1e1-df48aefc1234",
                    Name="Hr A van Dijk , Mw B Mol-van Dijk",
                    Product="Betaalrekening",
                    ResourceId=new Guid("450ffbb8-9f11-4ec6-a1e1-df48aefc82ef")
                },
                 new Account
                {
                    Currency="EUR",
                    Iban="450ffbb8-9f11-4ec6-a1e1-df48aefa8921",
                    Name="John Smith",
                    Product="Betaalrekening",
                    ResourceId=new Guid("450ffbb8-9f11-4ec6-a1e1-df48aefc2233")
                },
                 new Account
                {
                    Currency="RON",
                    Iban="450ffbb8-9f11-4ec6-a1e1-df48aefc6452",
                    Name="Vasile Popescu",
                    Product="Betaalrekening",
                    ResourceId=new Guid("450ffbb8-9f11-4ec6-a1e1-df48aefc0000")
                }
            });
            return accountsProvider;
        }
    }
}
