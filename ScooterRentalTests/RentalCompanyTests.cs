using System;
using System.Collections.Generic;
using System.Linq;
using ScooterRental;
using ScooterRental.Exceptions;
using ScooterRental.Finances;
using ScooterRental.InRentRegister;
using Xunit;

namespace ScooterRentalTests
{
    public class RentalCompanyTests
    {
        private string ExpectedName = "DemoCompany";
        private string _testIdScooter = "1";
        private decimal _scooterRentPrice = 1;
        private IRentalCompany _rentalInstance;
        private IScooterService _scooterService;
        private IFinancialRecords _financialRecords;
        private IRentRegister _rentRegister;
        private IChargeCalculator _chargeCalculator;

        public RentalCompanyTests()
        {
            _scooterService = new ScooterService();
            _scooterService.AddScooter(_testIdScooter, _scooterRentPrice);

            _financialRecords = new FinancialRecords();
            _rentRegister = new RentRegister();
            _chargeCalculator = new ChargeCalculator();

            _rentalInstance = SetUpCompanyInstance();
        }

        private RentalCompany SetUpCompanyInstance()
        {
            return new RentalCompany(ExpectedName, _scooterService, _financialRecords,
                _rentRegister, _chargeCalculator);
        }
        [Fact]
        public void RentalCompanyInstanceInitializationWithCorrectName()
        {
            Assert.Equal(ExpectedName, _rentalInstance.Name);
        }

        [Fact]
        public void StartRent_ShouldThrowExceptionIfOccupied()
        {
            _rentalInstance.StartRent(_testIdScooter);
            Assert.Throws<OccupiedScooterException>(() => _rentalInstance.StartRent(_testIdScooter));
        }
        [Fact]
        public void EndRent_ShouldThrowExceptionIfUnOccupied()
        {
            _rentalInstance.StartRent(_testIdScooter);
            _rentalInstance.EndRent(_testIdScooter);
            Assert.Throws<UnOccupiedScooterEndRentException>(() => _rentalInstance.EndRent(_testIdScooter));
        }
        [Fact]
        public void EndRent_ShouldReturnDecimalCharge()
        {
            double minutes = 2;
            decimal expected = _scooterRentPrice * (decimal)minutes;
            DateTime startTime = DateTime.UtcNow.AddMinutes(-minutes);

            Scooter scooter = _scooterService.GetScooterById(_testIdScooter);
            scooter.IsRented = true;

            IRentRegisterRecord record = new RentRegisterRecord(scooter, startTime);
            _rentRegister = new RentRegister(new List<IRentRegisterRecord>() { record });
            _rentalInstance = SetUpCompanyInstance();

            var result = _rentalInstance.EndRent(_testIdScooter);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void CalculateIncome_ShouldCalculateIncomeAsRequested(int? year, bool includeUncompleted, decimal expected)
        {
            _financialRecords = new FinancialRecords();
            _financialRecords.AddRecord(new FinancialRecord(_testIdScooter, new DateTime(2000, 1, 1), 1));
            _financialRecords.AddRecord(new FinancialRecord(_testIdScooter, new DateTime(2000, 6, 1), 6));
            _financialRecords.AddRecord(new FinancialRecord(_testIdScooter, new DateTime(2005, 1, 1), 6));

            IList<IRentRegisterRecord> records = new List<IRentRegisterRecord>()
            {
                new RentRegisterRecord(new Scooter("1",1),DateTime.UtcNow.AddMinutes(-60)),
                new RentRegisterRecord(new Scooter("2",2),DateTime.UtcNow.AddMinutes(-5)),
                new RentRegisterRecord(new Scooter("3",2),DateTime.UtcNow.AddDays(-5)),
            };

            _rentRegister = new RentRegister(records);

            _rentalInstance = SetUpCompanyInstance();

            var result = _rentalInstance.CalculateIncome(year, includeUncompleted);

            Assert.Equal(expected, result);
        }
        public static IEnumerable<object[]> GetData()
        {
            var allData = new List<object[]>
            {
                new object[] { 2000, false, 7 },
                new object[] { null, false, 13 },
                new object[] { null, true, 143 },
                new object[] { 2004, true, 0 },
                new object[] { DateTime.UtcNow.Year, true, 130 }
            };
            return allData;
        }
    }
}
