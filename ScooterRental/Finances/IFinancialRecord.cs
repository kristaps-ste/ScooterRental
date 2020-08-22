using System;

namespace ScooterRental
{
    public interface IFinancialRecord
    {
        string   ScooterId { get; }
        DateTime DateTime { get; }
        decimal MoneyCharged { get; }
    }
}