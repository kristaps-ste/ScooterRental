using System;

namespace ScooterRental.Finances
{
    public interface IFinancialRecord
    {
        string   ScooterId { get; }
        DateTime DateTime { get; }
        decimal MoneyCharged { get; }
    }
}