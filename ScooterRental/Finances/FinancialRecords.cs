using System.Collections.Generic;
using System.Linq;

namespace ScooterRental.Finances
{
    public class FinancialRecords : IFinancialRecords
    {
        public IList<IFinancialRecord> FinancialRecordRegister { get; }

        public FinancialRecords()
        {
            FinancialRecordRegister = new List<IFinancialRecord>();
        }

        public void AddRecord(IFinancialRecord record)
        {
            FinancialRecordRegister.Add(record);
        }

        public decimal CalculateIncome(int? year)
        {
            if (year == null || year == 0)
            {
                return FinancialRecordRegister.Sum(it => it.MoneyCharged);
            }
            return FinancialRecordRegister.Where(it => it.DateTime.Year == year).Sum(it => it.MoneyCharged);
        }
    }
}