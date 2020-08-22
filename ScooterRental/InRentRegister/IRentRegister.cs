using System;
using System.Collections.Generic;

namespace ScooterRental.InRentRegister
{
    public interface IRentRegister
    {
        void RegisterScooterInRent(Scooter scooter);
        TimeSpan ReturnScooter(Scooter scooter);
        IList<IRentRegisterRecord> GetRecords();
        IList<IRentRegisterRecord> GetRecords(DateTime startedIn);
    }
}