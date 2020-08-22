using System;
using ScooterRental.Exceptions;
using ScooterRental.Finances;
using ScooterRental.InRentRegister;

namespace ScooterRental
{
    public class RentalCompany :IRentalCompany
    {
        public string Name { get; }
        private IScooterService ScooterService { get; }
        private IFinancialRecords FinancialRecords { get; }
        private IRentRegister RentalRecords { get; }
        private IChargeCalculator ChargeCalculator { get; }

        public RentalCompany(string name, IScooterService scooterService, IFinancialRecords financialRecords, 
            IRentRegister rentalRecords, IChargeCalculator chargeCalculator)
        {
            Name = name;
            ScooterService = scooterService;
            FinancialRecords = financialRecords;
            RentalRecords = rentalRecords;
            ChargeCalculator = chargeCalculator;
        }
        public void StartRent(string id)
        {
            var scooter = ScooterService.GetScooterById(id);
            if (scooter.IsRented)
            {
                throw new OccupiedScooterException(id);
            }
            scooter.IsRented=true; 
            RentalRecords.RegisterScooterInRent(scooter);
        }

        public decimal EndRent(string id)
        {
            var scooter = ScooterService.GetScooterById(id);
            if (scooter.IsRented == false)
            {
                throw new UnOccupiedScooterEndRentException(id);
            }
            
            var rentTime=RentalRecords.ReturnScooter(scooter);
            scooter.IsRented = false;
            var toPay= ChargeCalculator.CalculateCharge(scooter.PricePerMinute, rentTime);
            FinancialRecords.FinancialRecordRegister.Add(new FinancialRecord(id,DateTime.UtcNow, toPay));
            return toPay;
        }
        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            decimal income = FinancialRecords.CalculateIncome(year);

            if (includeNotCompletedRentals)
            {
                int startedIn = year.HasValue  ? year.Value : 1;
                var rentedList = RentalRecords.GetRecords(new DateTime(startedIn,1,1));
                foreach (var record in rentedList)
                {
                    income += ChargeCalculator.CalculateCharge(record.Scooter.PricePerMinute, DateTime.UtcNow - record.RentStarTime);
                }
            }
            return income;
        }
    }
}
