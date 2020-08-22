using System;
using System.Collections.Generic;
using System.Linq;
using ScooterRental.Exceptions;

namespace ScooterRental.InRentRegister
{
    public class RentRegister : IRentRegister
    {
        private IList<IRentRegisterRecord> _scootersInRent = new List<IRentRegisterRecord>();

        public RentRegister()
        {
        }

        public RentRegister(IList<IRentRegisterRecord> records)
        {
            _scootersInRent = records;
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

            IRentRegisterRecord record = _scootersInRent.First(it => it.Scooter.Id == scooter.Id);
            TimeSpan duration = DateTime.UtcNow - record.RentStarTime;
            _scootersInRent.Remove(record);
            return duration;
        }

        public IList<IRentRegisterRecord> GetRecords()
        {
            return _scootersInRent;
        }

        public IList<IRentRegisterRecord> GetRecords(DateTime startedIn)
        {
            if (startedIn.Year==1)
            {
                return _scootersInRent;
            }
            return _scootersInRent.Where(it => it.RentStarTime.Year == startedIn.Year).ToList();
        }

        private bool IsScooterInRent(string id)
        {
            return _scootersInRent.Any(it => it.Scooter.Id == id);
        }
    }
}
