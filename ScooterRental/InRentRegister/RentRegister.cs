using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScooterRental.Exceptions;

namespace ScooterRental
{
    public class RentRegister : IRentRegister
    {
        private IList<RentRegisterRecord> _scootersInRent = new List<RentRegisterRecord>();

        public RentRegister()
        {
        }

        public RentRegister(RentRegisterRecord record)
        {
            _scootersInRent.Add(record);
        }

        public void RegisterScooterInRent(Scooter scooter)
        {
            if (IsScooterInRent(scooter.Id))
            {
                throw new RegisterScooterInRentException(scooter.Id);
            }
            _scootersInRent.Add(new RentRegisterRecord(scooter));
        }

        public TimeSpan ReturnScooter(Scooter scooter)
        {

            if (IsScooterInRent(scooter.Id) == false)
            {
                throw new UnRegisterScooterException(scooter.Id);
            }

            RentRegisterRecord record = _scootersInRent.First(it => it.Scooter.Id == scooter.Id);
            TimeSpan duration = DateTime.UtcNow - record.RentStarTime;
            _scootersInRent.Remove(record);
            return duration;
        }

        public IList<RentRegisterRecord> GetRecords()
        {
            return _scootersInRent;
        }

        private bool IsScooterInRent(string id)
        {
            return _scootersInRent.Any(it => it.Scooter.Id == id);
        }

    }

}
