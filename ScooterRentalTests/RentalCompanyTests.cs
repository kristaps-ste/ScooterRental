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

        [Fact]
        public void StartRent_ShouldMarkRentedScooterAsRented()
        {
            string testId = "1";
            
            RentalInstance.ScooterService.AddScooter(testId,0.5m);
            RentalInstance.StartRent(testId);
            Assert.True(RentalInstance.ScooterService.GetScooterById(testId).IsRented);
        }
       

    }
}
