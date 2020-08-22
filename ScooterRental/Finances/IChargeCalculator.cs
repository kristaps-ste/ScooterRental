using System;

namespace ScooterRental
{
    public interface IChargeCalculator
    {
        decimal CalculateCharge(decimal rate, TimeSpan period);
    }
}
