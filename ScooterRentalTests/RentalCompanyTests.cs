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
       
        [Fact]
        public void StartRent_ShouldThrowExceptionIfOccupied()
        {
            string testId = "1";
            
            RentalInstance.ScooterService.AddScooter(testId,0.5m);
            RentalInstance.StartRent(testId);
            Assert.Throws<ArgumentException>(() => RentalInstance.StartRent(testId));
        }

        [Fact]
        public void StartRent_ShouldSaveDateTimeWhenRentStarted()
        {
            string testId = "1";
            
            RentalInstance.ScooterService.AddScooter(testId,0.5m);
            RentalInstance.StartRent(testId);
            var dateStarted = RentalInstance.ScooterService.GetScooterById(testId).RentedAt;
           
            Assert.InRange(dateStarted,DateTime.UtcNow.AddMinutes(-0.1), DateTime.UtcNow);
        }

        [Fact]
        public void EndRent_ShouldStopRentByScooterId()
        {
            string testId = "1";

            RentalInstance.ScooterService.AddScooter(testId,0.5m);
            RentalInstance.StartRent(testId);
            RentalInstance.EndRent(testId);

            Assert.False(RentalInstance.ScooterService.GetScooterById(testId).IsRented);
        }

        [Theory]
        
        [InlineData(1,1,1)]
        [InlineData(0.5,0.5,0.5)]
        [InlineData(1,21,20)]
        [InlineData(1,1442,22)]
        [InlineData(0.01,1440,14.4)]
        [InlineData(0.01,2881,28.81)]
        public void EndRent_ShouldReturnCorrectToPayAccordingToRules(decimal price,double minutes, decimal expectedCharge )
        {
            string testId = "1";

            var testDateStarted = DateTime.UtcNow.AddMinutes(-minutes);
            
            RentalInstance.ScooterService.AddScooter(testId,price);
            RentalInstance.StartRent(testId);
            RentalInstance.ScooterService.GetScooterById(testId).RentedAt = testDateStarted;

            var charge= RentalInstance.EndRent(testId);

            Assert.Equal(expectedCharge,charge);
        }
    }
}
