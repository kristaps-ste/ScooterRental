using System;
using System.Collections.Generic;
using System.Linq;

namespace ScooterRental
{
    public class FinancialRecords : IFinancialRecords
    {
        public IList<FinancialRecord> FinancialRecordRegister { get; }

        public FinancialRecords()
        {
            FinancialRecordRegister=new List<FinancialRecord>();
        }

        public void AddRecord(FinancialRecord record)
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