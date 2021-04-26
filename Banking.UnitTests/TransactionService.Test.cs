using System;
using System.Collections.Generic;
using System.Linq;
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
            var fileProviderFake = TestData.GetTestDataWithAccountsAndTransactions();
            var tdp = new TransactionsDataProvider(fileProviderFake);
            var adp = new AccountsDataProvider(fileProviderFake);
            var service = new TransactionService(tdp, adp);

            var report = service.GetTransactionsForLastMonth(new DateTime(2021, 4, 26), Guid.NewGuid().ToString()).Result;

            Assert.AreEqual(0, report.Count());
        }

        [Test]
        public void Given_TransactionReport_When_TransactionsArePresent_Then_ShouldAggregateResultsPerCategory()
        {
            var fileProviderFake = TestData.GetTestDataWithAccountsAndTransactions();
            var tdp = new TransactionsDataProvider(fileProviderFake);
            var adp = new AccountsDataProvider(fileProviderFake);
            var service = new TransactionService(tdp, adp);

            var report = service.GetTransactionsForLastMonth(new DateTime(2021, 4, 26), "450ffbb8-9f11-4ec6-a1e1-df48aefc82ef").Result;

            Assert.AreEqual(4, report.Count());

            var medical = report.Where(t => t.CategoryName == "Medical expenses");
            Assert.AreEqual(1, medical.Count());
            Assert.AreEqual(3.99M, medical.First().TotalAmount);
        }

        [Test]
        public void Given_TransactionReport_When_TransactionsArePresent_Then_MedicalExpensesAreCorrect()
        {
            var fileProviderFake = TestData.GetTestDataWithAccountsAndTransactions();
            var tdp = new TransactionsDataProvider(fileProviderFake);
            var adp = new AccountsDataProvider(fileProviderFake);
            var service = new TransactionService(tdp, adp);

            var report = service.GetTransactionsForLastMonth(new DateTime(2021, 4, 26), "450ffbb8-9f11-4ec6-a1e1-df48aefc82ef").Result;

            var medical = report.Where(t => t.CategoryName == "Medical expenses");
            Assert.AreEqual(1, medical.Count());
            Assert.AreEqual(3.99M, medical.First().TotalAmount);
        }

        [Test]
        public void Given_TransactionReport_When_NoTransactionForCategory_Then_CategoryIsNotPresentInReport()
        {
            var fileProviderFake = TestData.GetTestDataWithAccountsAndTransactions();
            var tdp = new TransactionsDataProvider(fileProviderFake);
            var adp = new AccountsDataProvider(fileProviderFake);
            var service = new TransactionService(tdp, adp);

            var report = service.GetTransactionsForLastMonth(new DateTime(2021, 4, 26), "450ffbb8-9f11-4ec6-a1e1-df48aefc82ef").Result;

            var travel = report.Where(t => t.CategoryName == "Travel");
            Assert.AreEqual(0, travel.Count());
        }

        [Test]
        public void Given_TransactionReport_When_TransactionsArePresent_Then_OnlyTransactionsForLastMonthAreRetrieved()
        {
            var fileProviderFake = TestData.GetTestDataWithAccountsAndTransactions();
            var tdp = new TransactionsDataProvider(fileProviderFake);
            var adp = new AccountsDataProvider(fileProviderFake);
            var service = new TransactionService(tdp, adp);

            var report = service.GetTransactionsForLastMonth(new DateTime(2021, 4, 26), "450ffbb8-9f11-4ec6-a1e1-df48aefc82ef").Result;

            var clothing = report.Where(t => t.CategoryName == "Clothing");
            Assert.AreEqual(1, clothing.Count());
            Assert.AreEqual(201.5M, clothing.First().TotalAmount);
        }

        [Test]
        public void Given_TransactionReport_When_ASingleTransactionIsPresent_Then_ShouldReturnOneRecordInReport()
        {
            var fileProviderFake = TestData.GetTestDataWithAccountsAndTransactions();
            var tdp = new TransactionsDataProvider(fileProviderFake);
            var adp = new AccountsDataProvider(fileProviderFake);
            var service = new TransactionService(tdp, adp);

            var report = service.GetTransactionsForLastMonth(new DateTime(2021, 4, 26), "450ffbb8-9f11-4ec6-a1e1-df48aefc6452").Result;

            Assert.AreEqual(1, report.Count());

            var medical = report.Where(t => t.CategoryName == "Medical expenses");
            Assert.AreEqual(1, medical.Count());
            Assert.AreEqual(6.99M, medical.First().TotalAmount);
        }

        [Test]
        public void Given_TransactionReport_Then_OffsetIsConsidered()
        {
            var fileProviderFake = TestData.GetTestDataWithAccountsAndTransactions();
            var tdp = new TransactionsDataProvider(fileProviderFake);
            var adp = new AccountsDataProvider(fileProviderFake);
            var service = new TransactionService(tdp, adp);

            var report = service.GetTransactionsForLastMonth(new DateTime(2021, 3, 26), "450ffbb8-9f11-4ec6-a1e1-df48aefc6452").Result;

            Assert.AreEqual(0, report.Count());
        }
    }
}
