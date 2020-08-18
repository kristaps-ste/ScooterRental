using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental
{
    public class RentalCompany :IRentalCompany
    {
        public string Name { get; }
        public IScooterService ScooterService { get; }
        public RentalCompany(string name)
        {
            Name = name;
            ScooterService= new ScooterService();
        }
        public void StartRent(string id)
        {
            if (ScooterService.GetScooterById(id).IsRented == true)
            {
                throw new ArgumentException($"Scooter with id {id} is occupied already","id");
            }
            else
            {
                var scooter=ScooterService.GetScooterById(id);
                scooter.IsRented=true; 
                scooter.RentedAt=DateTime.UtcNow;
            }
        }

        public decimal EndRent(string id)
        {
            var endRentAt = DateTime.UtcNow;
            var scooter=ScooterService.GetScooterById(id);
            scooter.IsRented = false;
            return CalculateCharge(scooter.PricePerMinute, endRentAt - scooter.RentedAt);
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            throw new NotImplementedException();
        }

        private decimal CalculateCharge(decimal rate ,TimeSpan period)
        {
            decimal perDayMaxCharge = 20m;
            decimal chargeToPay = 0m;
            decimal expectedPayPerDay=rate * (decimal)new TimeSpan(1,0,0,0).TotalMinutes;

            if (period.Days > 0)
            {
                chargeToPay = expectedPayPerDay * period.Days < perDayMaxCharge * period.Days ? 
                    expectedPayPerDay * period.Days : perDayMaxCharge * period.Days;
                
                period = period.Subtract(new TimeSpan(period.Days, 0, 0, 0));
            }

            expectedPayPerDay = rate * (decimal) Math.Round(period.TotalMinutes);
            chargeToPay += perDayMaxCharge < expectedPayPerDay ? perDayMaxCharge : expectedPayPerDay;
            
            return chargeToPay ;
        }
    }
}
