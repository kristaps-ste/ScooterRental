using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental
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
            decimal chargeToPay = 0m;
            decimal expectedPayPerDay = rate * (decimal)new TimeSpan(1, 0, 0, 0).TotalMinutes;

            if (period.Days > 0)
            {
                chargeToPay = expectedPayPerDay  < _perDayMaxCharge  ? 
                    expectedPayPerDay * period.Days : _perDayMaxCharge * period.Days;

                period = period.Subtract(new TimeSpan(period.Days, 0, 0, 0));
            }
            expectedPayPerDay = rate * (decimal)Math.Round(period.TotalMinutes);
            chargeToPay += _perDayMaxCharge < expectedPayPerDay ? _perDayMaxCharge : expectedPayPerDay;

            return chargeToPay;
        }
    }
}
