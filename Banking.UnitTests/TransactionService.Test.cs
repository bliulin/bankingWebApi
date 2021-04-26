using System;
using System.Collections.Generic;
using System.Text;
using Banking.Business.Implementation;
using Banking.Data.Implementation;
using Banking.UnitTests.Fakes;
using NUnit.Framework;

namespace Banking.UnitTests
{
    public class TransactionServiceTest
    {
        [Test]
        public void Given_TransactionReport_When_IbanDoesNotExist_Then_ShouldReturnZeroTransactions()
        {
            var fileProviderFake = new LocalFileProviderFake();



            var tdp = new TransactionsDataProvider(fileProviderFake);
            var adp = new AccountsDataProvider(fileProviderFake);
            var service = new TransactionService(tdp, adp);
        }
    }
}
