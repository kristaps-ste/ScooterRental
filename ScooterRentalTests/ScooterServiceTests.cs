using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using FluentAssertions;
using ScooterRental;
using ScooterRental.Exceptions;
using Xunit;
using Xunit.Sdk;

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
            Assert.Throws<DuplicateScooterIdException>(() => ScooterServiceInstance.AddScooter("11111", 0.5m));
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

            ScooterServiceInstance.AddScooter("1",0.5m);
            ScooterServiceInstance.AddScooter("2",0.5m);
            ScooterServiceInstance.GetScooterById("2").IsRented = true;
            
            Assert.Equal(expectedValue, ScooterServiceInstance.GetScooters().Count);
        }

    }
}
