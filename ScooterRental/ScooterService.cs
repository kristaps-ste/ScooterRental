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
            if (IsScooterExistInList(id))
            {
                throw new  ArgumentException($"Scooter with id: {id} already exists in list.","id");
                return;
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
            if (!IsScooterExistInList(scooterId))
            {
                throw new  ArgumentException($"Scooter with id: {scooterId} already exists in list.","scooterId");
            }

            return ScooterList.First(it => it.Id == scooterId);
        }

        private bool IsScooterExistInList(string id)
        {
            return ScooterList.Any(it => it.Id == id);
        }
        
    }
}
