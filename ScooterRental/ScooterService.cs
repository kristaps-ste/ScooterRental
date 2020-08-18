using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental
{
    public class ScooterService : IScooterService
    {
        private IList<Scooter> ScooterList;

        public ScooterService()
        {
            ScooterList =new List<Scooter>();
        }
        public void AddScooter(string id, decimal pricePerMinute)
        {
            throw new NotImplementedException();
        }

        public void RemoveScooter(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Scooter> GetScooters()
        {
            return ScooterList;
        }

        public Scooter GetScooterById(string scooterId)
        {
            throw new NotImplementedException();
        }
    }
}
