using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Data.Contracts.Models
{
    public enum TransactionCategory
    {
        Food = 1,
        Entertainment = 2,
        Clothing = 3,
        Travel = 4,
        MedicalExpenses = 5
    }

    public static class TransactionCategoryExtension
    {
        public static string ToFriendlyString(this TransactionCategory categ)
        {
            switch (categ)
            {
                case TransactionCategory.MedicalExpenses:
                    {
                        return "Medical expenses";
                    }
                default:
                    {
                        return categ.ToString();
                    }
            }
        }
    }
}
