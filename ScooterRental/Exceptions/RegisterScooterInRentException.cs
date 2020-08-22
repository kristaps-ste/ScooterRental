using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental.Exceptions
{
    public class RegisterScooterInRentException : Exception
    {
        public RegisterScooterInRentException(string id)
            : base($"Cannot register scooter as rented! Scooter with id: {id} is already in register")
        {
        }
    }
}
