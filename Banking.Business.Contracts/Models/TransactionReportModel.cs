using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Business.Contracts.Models
{
    public class TransactionReportModel
    {
        public string CategoryName { get; set; }

        public decimal TotalAmount { get; set; }

        public string Currency { get; set; }
    }
}
