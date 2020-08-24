using System;

namespace ScooterRental.Exceptions
{
    public class RegisterScooterInRentException : Exception
    {
        public RegisterScooterInRentException(string id)
            : base($"Cannot register scooter as rented! Scooter with id: {id} is already is rented")
        {
        }
    }
}
