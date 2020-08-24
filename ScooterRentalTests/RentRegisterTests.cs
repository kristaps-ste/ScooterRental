using System;
using System.Collections.Generic;
using ScooterRental;
using ScooterRental.Exceptions;
using ScooterRental.InRentRegister;
using Xunit;

namespace ScooterRentalTests
{
    public class RentRegisterTests
    {
        private IRentRegister RentRegisterInstance { get; }= new RentRegister();
        private Scooter ScooterInstance { get; }= new Scooter("11",0.5m);
        
        [Fact]
        public void RegisterScooterInRent_ShouldAddScooterToListOrThrowException()
        {
            RentRegisterInstance.RegisterScooterInRent(ScooterInstance);
            Assert.Throws<RegisterScooterInRentException>(()=> RentRegisterInstance.RegisterScooterInRent(ScooterInstance));
        }

        [Fact]
        public void GetRecords_ShouldReturnAllRecordsFromList()
        {
            int expectedRecords=2;
           
            RentRegisterInstance.RegisterScooterInRent(new Scooter("11",0.5m));
            RentRegisterInstance.RegisterScooterInRent(new Scooter("12",0.5m));
            
            Assert.Equal(expectedRecords,RentRegisterInstance.GetRecords().Count);
        }
        [Fact]
        public void ReturnScooter_ShouldRemoveScooterFromListOrThrowException()
        {
            RentRegisterInstance.RegisterScooterInRent(ScooterInstance);
            RentRegisterInstance.ReturnScooter(ScooterInstance);
            Assert.Throws<UnRegisterScooterException>(()=> RentRegisterInstance.ReturnScooter(ScooterInstance));
        }

        [Fact]

        public void ReturnScooter_ShouldReturnCorrectTimespan()
        {
            double expectedRentTimeHours = 1;
            IRentRegisterRecord r = new RentRegisterRecord(ScooterInstance, DateTime.UtcNow.AddHours(-expectedRentTimeHours));
            var localInstance  = new RentRegister(new List<IRentRegisterRecord>(){r});
            var timeSpent = localInstance.ReturnScooter(ScooterInstance);
            Assert.Equal(expectedRentTimeHours,timeSpent.Hours);
        }
    }
}
