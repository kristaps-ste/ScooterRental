using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental
{
    public class RentRegisterRecord
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
