﻿using System;
using System.Collections.Generic;
using System.Linq;

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

        public decimal CalculateIncome(int? year)
        {

            if (year == null || year == 0)
            {
                return FinancialRecordRegister.Sum(it => it.MoneyCharged);
            }

            return FinancialRecordRegister.Where(it => it.DateTime.Year == year).Sum(it => it.MoneyCharged);
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