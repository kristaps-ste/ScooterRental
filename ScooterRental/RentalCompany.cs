using System;
using ScooterRental.Exceptions;

namespace ScooterRental
{
    public class RentalCompany :IRentalCompany
    {
        public string Name { get; }
        private IScooterService ScooterService { get; }
        private IFinancialRecords FinancialRecords { get; }
        private IChargeCalculator ChargeCalculator { get; }

        public RentalCompany(string name, IScooterService scooterService, IFinancialRecords finRecords, IChargeCalculator chargeClc)
        {
            Name = name;
            ScooterService = scooterService;
            FinancialRecords = finRecords;
            ChargeCalculator = chargeClc;
        }
        public void StartRent(string id)
        {
            var scooter = ScooterService.GetScooterById(id);
            if (scooter.IsRented)
            {
                throw new OccupiedScooterException(id);
            }
            scooter.IsRented=true; 
            scooter.RentedAt=DateTime.UtcNow;
        }

        public decimal EndRent(string id)
        {
            var endRentAt = DateTime.UtcNow;

            var scooter = ScooterService.GetScooterById(id);
            if (scooter.IsRented == false)
            {
                throw new UnOccupiedScooterEndRentException(id);
            }
            scooter.IsRented = false;
            var toPay= ChargeCalculator.CalculateCharge(scooter.PricePerMinute, endRentAt - scooter.RentedAt);
            FinancialRecords.FinancialRecordRegister.Add(new FinancialRecord(id,endRentAt,toPay));
            return toPay;
        }
        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            decimal income = FinancialRecords.CalculateIncome(year);
            if (includeNotCompletedRentals)
            {
                var scootersInUse = ScooterService.GetScootersInUse();
                foreach (var scooter in scootersInUse)
                {
                    income += ChargeCalculator.CalculateCharge(scooter.PricePerMinute, DateTime.UtcNow - scooter.RentedAt);
                }
            }
            return income;
        }
    }
}
