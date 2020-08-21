using System;
namespace ScooterRental.Exceptions
{
    public class DuplicateScooterIdException : Exception
    {
        public DuplicateScooterIdException()
        {
        }
        public DuplicateScooterIdException(string id)
            : base( $"Duplicate Id !  Scooter with id: {id} already exists in system.")
        {

        }
    }
}
