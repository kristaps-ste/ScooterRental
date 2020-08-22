using System;
using ScooterRental;
using Xunit;

namespace ScooterRentalTests
{
    public class ChargeCalculatorTests
    {
        private decimal _maxDayCharge;
        private IChargeCalculator _calculatorInstance;
        public ChargeCalculatorTests()
        {
            _maxDayCharge = 20m;
            _calculatorInstance= new ChargeCalculator(_maxDayCharge);
        }

        [Theory]

        [InlineData(1, 1, 1)]
        [InlineData(0.5, 0.5, 0.5)]
        [InlineData(1, 21, 20)]
        [InlineData(1, 1442, 22)]
        [InlineData(0.01, 1440, 14.4)]
        [InlineData(0.01, 2880, 28.8)]
        [InlineData(0.01, 2881, 28.81)]
        public void CalculateCharge_ShouldReturnCorrectToPayAccordingToRules(decimal price, double minutes, decimal expectedCharge)
        {
            var charge = _calculatorInstance.CalculateCharge(price, TimeSpan.FromMinutes(minutes));
            Assert.Equal(expectedCharge, charge);
        }
    }
}
