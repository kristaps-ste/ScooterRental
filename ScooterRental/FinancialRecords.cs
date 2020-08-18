using System;
using System.Collections.Generic;

namespace ScooterRental
{
    public class FinancialRecords
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
        public static decimal CalculateCharge(decimal rate, TimeSpan period)
        {
            decimal perDayMaxCharge = 20m;
            decimal chargeToPay = 0m;
            decimal expectedPayPerDay = rate * (decimal)new TimeSpan(1, 0, 0, 0).TotalMinutes;

            if (period.Days > 0)
            {
                chargeToPay = expectedPayPerDay  < perDayMaxCharge  ? 
                    expectedPayPerDay * period.Days : perDayMaxCharge * period.Days;

                period = period.Subtract(new TimeSpan(period.Days, 0, 0, 0));
            }

            expectedPayPerDay = rate * (decimal)Math.Round(period.TotalMinutes);
            chargeToPay += perDayMaxCharge < expectedPayPerDay ? perDayMaxCharge : expectedPayPerDay;

            return chargeToPay;
        }
    }
}