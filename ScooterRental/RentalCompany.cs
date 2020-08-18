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
            ScooterService.GetScooterById(id).IsRented=true;
            
        }

        public decimal EndRent(string id)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            throw new NotImplementedException();
        }
    }
}
