using System;
using ScooterRental.InRentRegister;

namespace ScooterRental
{
    public class RentRegisterRecord : IRentRegisterRecord
    {
        public Scooter Scooter { get; }
        public  DateTime RentStarTime { get; }

        public RentRegisterRecord(Scooter scooter)
        {
            Scooter = scooter;
            RentStarTime = DateTime.UtcNow;
        }
        public RentRegisterRecord(Scooter scooter, DateTime startTime)
        {
            Scooter = scooter;
            RentStarTime = startTime;
        }
    }
}
