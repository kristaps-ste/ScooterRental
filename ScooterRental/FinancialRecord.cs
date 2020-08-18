using System;
using System.Reflection.Emit;

namespace ScooterRental
{
    public class FinancialRecord
    {
        public string   ScooterId { get; }
        public DateTime DateTime { get; }
        public  decimal MoneyCharged { get; }
        public FinancialRecord(string scooterId,DateTime dateTime, decimal toPay)
        {
            ScooterId = scooterId;
            DateTime = dateTime;
            MoneyCharged = toPay;
        }
    }
}