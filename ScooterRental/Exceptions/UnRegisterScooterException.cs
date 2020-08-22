using System;

namespace ScooterRental.Exceptions
{
    public class UnRegisterScooterException : Exception
    {
        public UnRegisterScooterException(string id)
            : base($"Cannot return scooter! Scooter with id: {id} does not exist in  register")
        {
        }
    }

}
