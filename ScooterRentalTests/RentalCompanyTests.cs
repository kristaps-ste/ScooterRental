using System;
using FluentAssertions;
using ScooterRental;
using Xunit;
using ScooterRentalTests;

namespace ScooterRentalTests
{
    public class RentalCompanyTests
    {
        private string ExpectedName="DemoCompany";
        private RentalCompany RentalInstance;

        public RentalCompanyTests()
        {
            RentalInstance = new RentalCompany(ExpectedName);
        }
        [Fact]
        public void RentalCompanyInstanceInitializationWithCorrectName()
        {
            Assert.Equal(ExpectedName, RentalInstance.Name);
        }

        [Fact]
        public void RentalCompanyScooterServiceSholudBeInitialized()
        {
            Assert.NotNull(RentalInstance.ScooterService);
        }
       

    }
}
