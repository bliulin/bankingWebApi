using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Banking.Data.Contracts.Models;
using Banking.Data.Implementation;
using Banking.UnitTests.Fakes;
using NUnit.Framework;

namespace Banking.UnitTests
{
    public class AccountsDataProviderTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_OneAccount_When_RetrieveAccountsWithEmptyGuid_Then_TheAccountIsRetrieved()
        {
            var accountsProvider = TestData.GetWithSingleAccount();
            var accountsDataProvider = new AccountsDataProvider(accountsProvider);

            var accounts = accountsDataProvider.GetClientAccounts(Guid.Empty).Result;

            Assert.AreEqual(1, accounts.Count());
            var firstAccount = accounts.First();
            Assert.AreEqual("450ffbb8-9f11-4ec6-a1e1-df48aefc82ef", firstAccount.Iban);
        }

        [Test]
        public void Given_TwoAccountsForTheSameClient_When_RetrieveAccountsWithClientId_Then_TheTwoAccountsAreRetrieved()
        {
            var accountsProvider = TestData.GetWithTwoAccountsForSameCustomer();
            var accountsDataProvider = new AccountsDataProvider(accountsProvider);

            var accounts = accountsDataProvider.GetClientAccounts(new Guid("450ffbb8-9f11-4ec6-a1e1-df48aefc82ef")).Result;

            Assert.AreEqual(2, accounts.Count());
        }

        [Test]
        public void Given_AccountsForMultipleClients_When_RetrieveAccountsWithClientId_Then_OnlyAccountsForThatClientAreReturned()
        {
            var accountsProvider = TestData.GetWithManyClientAccountsData();
            var accountsDataProvider = new AccountsDataProvider(accountsProvider);

            var accounts = accountsDataProvider.GetClientAccounts(new Guid("450ffbb8-9f11-4ec6-a1e1-df48aefc82ef")).Result;

            Assert.AreEqual(2, accounts.Count());
        }

        [Test]
        public void Given_AccountsForMultipleClients_When_RetrieveAccountsWithInexistentClientId_Then_ZeroAccountsAreReturned()
        {
            var accountsProvider = TestData.GetWithManyClientAccountsData();
            var accountsDataProvider = new AccountsDataProvider(accountsProvider);

            var accounts = accountsDataProvider.GetClientAccounts(new Guid("450ffbb8-9f11-4ec6-a1e1-df48aefcffaa")).Result;

            Assert.AreEqual(0, accounts.Count());
        }
    }
}
