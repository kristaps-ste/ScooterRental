using System;

namespace ScooterRental.InRentRegister
{
    public interface IRentRegisterRecord
        {
            Scooter Scooter { get; } 
            DateTime RentStarTime { get; }
        }
}
