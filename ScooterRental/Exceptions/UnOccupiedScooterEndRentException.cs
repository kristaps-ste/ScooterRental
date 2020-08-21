using System;

namespace ScooterRental.Exceptions
{
    public class UnOccupiedScooterEndRentException : Exception
    {
        public UnOccupiedScooterEndRentException(string id)
            : base($"Invalid Scooter End Rent operation! Scooter with id: {id} is not in rent")
        {
        }
    }
}
