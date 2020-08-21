using System;

namespace ScooterRental.Exceptions
{
    public class OccupiedScooterException : Exception
    {
        public OccupiedScooterException(string id)
            : base($"Id not found! Scooter with id: {id} does not exist in system.")
        {
        }
    }
}
