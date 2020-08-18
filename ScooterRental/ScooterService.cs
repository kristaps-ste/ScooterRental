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
            }
            else
            {
                ScooterList.Add(new Scooter(id,pricePerMinute));  
            }
            
        }

        public void RemoveScooter(string id)
        {
            if (!IsScooterExistInList(id))
            {
                throw new  ArgumentException($"Scooter with id: {id} does not exist.","scooterId");
            }
            else
            {
                ScooterList = ScooterList.Where(it => it.Id != id).ToList();
            }
        }

        public IList<Scooter> GetScooters()
        {
            return ScooterList.Where(it=>it.IsRented==false).ToList();
        }

        public Scooter GetScooterById(string scooterId)
        {
            if (!IsScooterExistInList(scooterId))
            {
                throw new  ArgumentException($"Scooter with id: {scooterId} does not exist.","scooterId");
            }
            else
            {
                return ScooterList.First(it => it.Id == scooterId);  
            }
        }

        private bool IsScooterExistInList(string id)
        {
            return ScooterList.Any(it => it.Id == id);
        }
        
    }
}
