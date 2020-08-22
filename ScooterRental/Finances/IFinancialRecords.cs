using System.Collections.Generic;
using ScooterRental.Finances;

namespace ScooterRental
{
    public interface IFinancialRecords
    {
        IList<IFinancialRecord> FinancialRecordRegister { get; }
        void AddRecord(IFinancialRecord record);
        decimal CalculateIncome(int? year);
    }
}
