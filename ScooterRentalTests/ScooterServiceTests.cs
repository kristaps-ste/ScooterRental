using System;
using System.Collections.Generic;
using System.Text;
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

    }
}
