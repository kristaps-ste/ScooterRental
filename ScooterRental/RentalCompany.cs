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
            var charge = rate * (decimal) Math.Round(period.TotalMinutes);
            return charge ;
        }
    }
}
