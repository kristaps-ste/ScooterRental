using System;

namespace ScooterRental.Exceptions
{
    public  class InvalidScooterIdException :Exception
    {
        public InvalidScooterIdException(string id)
                : base($"Id not found! Scooter with id: {id} does not exist in system.")
            {

            }
    }
}
