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

        public static LocalFileProviderFake GetTestDataWithAccountsAndTransactions()
        {
            var fake = GetWithManyClientAccountsData();
            fake.Transactions.AddRange(new List<Transaction>()
            {
                new Transaction
                {
                    TransactionId = 1,
                    Amount=101,
                    CategoryId = 1,
                    Iban = "450ffbb8-9f11-4ec6-a1e1-df48aefc82ef",
                    TransactionDate = "2021-03-23"
                },
                new Transaction
                {
                    TransactionId = 2,
                    Amount=77,
                    CategoryId = 1,
                    Iban = "450ffbb8-9f11-4ec6-a1e1-df48aefc82ef",
                    TransactionDate = "2021-03-22"
                },
                new Transaction
                {
                    TransactionId = 3,
                    Amount=55,
                    CategoryId = 2,
                    Iban = "450ffbb8-9f11-4ec6-a1e1-df48aefc82ef",
                    TransactionDate = "2021-03-22"
                },
                new Transaction
                {
                    TransactionId = 4,
                    Amount=13,
                    CategoryId = 2,
                    Iban = "450ffbb8-9f11-4ec6-a1e1-df48aefc82ef",
                    TransactionDate = "2021-03-21"
                },
                new Transaction
                {
                    TransactionId = 5,
                    Amount=201.5M,
                    CategoryId = 3,
                    Iban = "450ffbb8-9f11-4ec6-a1e1-df48aefc82ef",
                    TransactionDate = "2021-03-19"
                },
                new Transaction
                {
                    TransactionId = 21,
                    Amount=203,
                    CategoryId = 3,
                    Iban = "450ffbb8-9f11-4ec6-a1e1-df48aefc82ef",
                    TransactionDate = "2021-04-19"
                },
                new Transaction
                {
                    TransactionId = 6,
                    Amount=3.99M,
                    CategoryId = 5,
                    Iban = "450ffbb8-9f11-4ec6-a1e1-df48aefc82ef",
                    TransactionDate = "2021-03-18"
                },

                // other IBAN

                new Transaction
                {
                    TransactionId = 61,
                    Amount=6.99M,
                    CategoryId = 5,
                    Iban = "450ffbb8-9f11-4ec6-a1e1-df48aefc6452",
                    TransactionDate = "2021-03-18"
                },
            });

            return fake;
        }
    }
}
