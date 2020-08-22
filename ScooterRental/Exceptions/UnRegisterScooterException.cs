using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental.Exceptions
{
    public class UnRegisterScooterException : Exception
        {
            public UnRegisterScooterException(string id)
                : base($"Cannot return scooter ! Scooter with id: {id} does not exist in  register")
            {
            }
        }
    
}
