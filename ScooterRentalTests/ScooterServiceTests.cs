using System.Collections.Generic;
using ScooterRental;
using ScooterRental.Exceptions;
using Xunit;

namespace ScooterRentalTests
{
    public class ScooterServiceTests
    {
        private IScooterService ScooterServiceInstance;
        public ScooterServiceTests()
        {
            var scooterList = new List<Scooter>(){new Scooter("1111", 0.5m)};
            ScooterServiceInstance = new ScooterService(scooterList);
        }

        [Fact]
        public void ScooterServiceShouldContainInitializedList()
        {
            IScooterService localInstance = new ScooterService();
            Assert.NotNull(localInstance.GetScooters());
        }

        [Fact]
        public void AddScooter_ShouldBeAbleToAddNewScooterToList()
        {
            var expectedCount = 1;
            IScooterService localInstance = new ScooterService();
            localInstance.AddScooter("11111",0.5m);
            Assert.Equal(expectedCount,localInstance.GetScooters().Count);
        }
        [Fact]
        public void AddScooter_ShouldThrowExceptionWhenDuplicateIdAdded()
        {
            Scooter existingScooter = ScooterServiceInstance.GetScooters()[0];
            Assert.Throws<DuplicateScooterIdException>(()
                => ScooterServiceInstance.AddScooter(existingScooter.Id,existingScooter.PricePerMinute));
        }

        [Fact]
        public void GetScooterById_ShouldReturnScooterByGivenId()
        {
            string scooterId = "1";
            ScooterServiceInstance.AddScooter(scooterId,0.5m);
            var scooter = ScooterServiceInstance.GetScooterById(scooterId);
            
            Assert.Equal(scooterId,scooter.Id);
        }
        [Fact]
        public void GetScooterById_ShouldThrowExceptionIfNotFound()
        {
            string scooterId = "1";
            string testId = "2";
            ScooterServiceInstance.AddScooter(scooterId,0.5m);

            Assert.Throws<InvalidScooterIdException>(() => ScooterServiceInstance.GetScooterById(testId));
        }
        [Fact]
        public void RemoveScooter_ShouldRemoveCorrectScooterFromListByIdOrThrowException()
        {
            string testId = "2";
            ScooterServiceInstance.AddScooter("1",0.5m);
            ScooterServiceInstance.AddScooter(testId,0.5m);
            ScooterServiceInstance.RemoveScooter(testId);

            Assert.Throws<InvalidScooterIdException>(() => ScooterServiceInstance.RemoveScooter(testId));
        }

        [Fact]
        public void GetScooters_ShouldReturnUnrentedScooters()
        {
            int expectedValue = 1;
            ScooterServiceInstance=new ScooterService();
            ScooterServiceInstance.AddScooter("1",0.5m);
            ScooterServiceInstance.AddScooter("2",0.5m);
            ScooterServiceInstance.GetScooterById("2").IsRented = true;
            
            Assert.Equal(expectedValue, ScooterServiceInstance.GetScooters().Count);
        }

    }
}
