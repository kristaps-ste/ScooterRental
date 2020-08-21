using System;
using ScooterRental;
using ScooterRental.Exceptions;
using Xunit;

namespace ScooterRentalTests
{
    public class RentalCompanyTests
    {
        private string ExpectedName = "DemoCompany";
        private string _testIdScooter = "1";
        private IRentalCompany RentalInstance;

        public RentalCompanyTests()
        {
            
            IScooterService scooterService = new ScooterService();
            scooterService.AddScooter(_testIdScooter,0.5m);
            IFinancialRecords financialRecords= new FinancialRecords();
            IChargeCalculator chrgCalc= new ChargeCalculator();
            RentalInstance = new RentalCompany(ExpectedName,scooterService, financialRecords,chrgCalc);
        }
        [Fact]
        public void RentalCompanyInstanceInitializationWithCorrectName()
        {
            Assert.Equal(ExpectedName, RentalInstance.Name);
        }
        
        [Fact]
        public void StartRent_ShouldThrowExceptionIfOccupied()
        {
            RentalInstance.StartRent(_testIdScooter);
            Assert.Throws<OccupiedScooterException>(() => RentalInstance.StartRent(_testIdScooter));
        }
        [Fact]
        public void EndRent_ShouldThrowExceptionIfUnOccupied()
        {
            RentalInstance.StartRent(_testIdScooter);
            RentalInstance.EndRent(_testIdScooter);
            Assert.Throws<UnOccupiedScooterEndRentException>(() => RentalInstance.EndRent(_testIdScooter));
        }
        [Fact]
        public void EndRent_ShouldReturnDecimalCharge()
        {
            RentalInstance.StartRent(_testIdScooter);
            var result=RentalInstance.EndRent(_testIdScooter);
            Assert.IsType<decimal>(result);
        }
    }
}
