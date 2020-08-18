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
            ScooterList=new List<Scooter>();
        }
        public void AddScooter(string id, decimal pricePerMinute)
        {
            if (ScooterList.Any(it => it.Id == id))
            {
                throw new  ArgumentException($"Scooter with id: {id} already exists in list.","id");
            }
            ScooterList.Add(new Scooter(id,pricePerMinute));
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
