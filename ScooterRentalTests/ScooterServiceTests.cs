using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using ScooterRental;
using Xunit;

namespace ScooterRentalTests
{
    public class ScooterServiceTests
    {
        private ScooterService ScooterServiceInstance;
        public ScooterServiceTests()
        {
            ScooterServiceInstance = new ScooterService();
        }

        [Fact]
        public void ScooterServiceShouldContainInitializedList()
        {
            Assert.NotNull(ScooterServiceInstance.GetScooters());
        }

        [Fact]
        public void AddScooter_ShouldBeAbleToAddNewScooterToList()
        {
            var expectedCount = 1;
            ScooterServiceInstance.AddScooter("11111",0.5m);
            Assert.Equal(expectedCount,ScooterServiceInstance.GetScooters().Count);
        }
        [Fact]
        public void AddScooter_ShouldThrowExceptionWhenDuplicateIdAdded()
        {
            ScooterServiceInstance.AddScooter("11111",0.5m);
            Assert.Throws<ArgumentException>(() => ScooterServiceInstance.AddScooter("11111", 0.5m));
        }

    }
}
