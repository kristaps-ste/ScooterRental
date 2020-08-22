using System;
namespace ScooterRental.Exceptions
{
    public class OccupiedScooterException : Exception
    {
        public OccupiedScooterException(string id)
            : base($"Scooter not available! Scooter with id: {id} is rented out.")
        {
        }
    }
}
