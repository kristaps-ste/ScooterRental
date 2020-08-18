using System;

namespace ScooterRental
{
    public class FinancialRecord
    {
        public string   ScooterId { get; }
        public DateTime DateTime { get; }
        public  decimal MoneyCharged { get; }
        public FinancialRecord(string scooterId,DateTime dateTime, decimal toPay)
        {
            
        }
    }
}