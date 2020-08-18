using System;
using ScooterRental;
using Xunit;
using ScooterRentalTests;

namespace ScooterRentalTests
{
    public class RentalCompanyTests
    {
        [Fact]
        public void RentalCompanyInstanceInitializationWithCorrectName()
        {
            var expectedName="DemoCompany";
            
            var rentalInstance= new RentalCompany();

            Assert.Equal(expectedName,rentalInstance.Name);
        }
    }
}
