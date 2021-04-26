using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Data.Contracts.Models
{
    public class Account
    {
        /// <summary>
        /// Assume this is the unique id of the customer
        /// </summary>
        public Guid ResourceId { get; set; }

        public string Product { get; set; }

        /// <summary>
        /// The Iban uniquely identifies the account
        /// </summary>
        public string Iban { get; set; }

        public string Name { get; set; }

        public string Currency { get; set; }
    }
}
