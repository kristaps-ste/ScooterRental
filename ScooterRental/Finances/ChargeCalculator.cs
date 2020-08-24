using System;

namespace ScooterRental.Finances
{
    public class ChargeCalculator : IChargeCalculator
    {
        private decimal _perDayMaxCharge;
        public ChargeCalculator()
        {
            _perDayMaxCharge = 20m;
        }
        public ChargeCalculator(decimal maxDayCharge)
        {
            _perDayMaxCharge = maxDayCharge;
        }
        public  decimal CalculateCharge(decimal rate, TimeSpan period)
        {
            decimal toPay = 0m;
            decimal expectedPayPerDay = rate * (decimal)new TimeSpan(1, 0, 0, 0).TotalMinutes;

            if (period.Days > 0)
            {
                toPay = expectedPayPerDay  > _perDayMaxCharge  ? 
                    _perDayMaxCharge * period.Days : expectedPayPerDay * period.Days;

                period = period.Subtract(new TimeSpan(period.Days, 0, 0, 0));
            }
            expectedPayPerDay = rate * (decimal)Math.Round(period.TotalMinutes,MidpointRounding.AwayFromZero);
            toPay += _perDayMaxCharge < expectedPayPerDay ? _perDayMaxCharge : expectedPayPerDay;

            return toPay;
        }
    }
}
