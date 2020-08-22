using System;
using System.Collections.Generic;
using ScooterRental.InRentRegister;

namespace ScooterRental
{
    public interface IRentRegister
    {
        void RegisterScooterInRent(Scooter scooter);
        TimeSpan ReturnScooter(Scooter scooter);
        IList<IRentRegisterRecord> GetRecords();
    }
}