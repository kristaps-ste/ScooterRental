using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental
{
    public interface IFinancialRecords
    {
        IList<FinancialRecord> FinancialRecordRegister { get; }
        void AddRecord(FinancialRecord record);
        decimal CalculateIncome(int? year);
    }
}
