using System;
using System.Collections.Generic;

namespace ScooterRental
{
    public interface IRentRegister
    {
        void RegisterScooterInRent(Scooter scooter);
        TimeSpan ReturnScooter(Scooter scooter);
        IList<RentRegisterRecord> GetRecords();
    }
}