using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental.Exceptions
{
    public  class InvalidScooterIdException :Exception
    {
        public InvalidScooterIdException()
            {
            }
        public InvalidScooterIdException(string id)
                : base($"Id not found! Scooter with id: {id} does not exist in system.")
            {

            }
    }
}
