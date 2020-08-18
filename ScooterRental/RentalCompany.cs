﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental
{
    public class RentalCompany :IRentalCompany
    {
        public string Name { get; }
        public ScooterService ScooterService { get; }
        private FinancialRecords FinancialRecords { get; }
        public RentalCompany(string name)
        {
            Name = name;
            ScooterService= new ScooterService();
            FinancialRecords = new FinancialRecords();
        }
        public void StartRent(string id)
        {
            if (ScooterService.GetScooterById(id).IsRented == true)
            {
                throw new ArgumentException($"Scooter with id {id} is occupied already","id");
            }
            else
            {
                var scooter=ScooterService.GetScooterById(id);
                scooter.IsRented=true; 
                scooter.RentedAt=DateTime.UtcNow;
            }
        }

        public decimal EndRent(string id)
        {
            var endRentAt = DateTime.UtcNow;
            var scooter=ScooterService.GetScooterById(id);
            scooter.IsRented = false;
            var toPay= FinancialRecords.CalculateCharge(scooter.PricePerMinute, endRentAt - scooter.RentedAt);
            FinancialRecords.FinancialRecordRegister.Add(new FinancialRecord(id,endRentAt,toPay));
            return toPay;
        }
        public decimal CalculateIncome(int? year, bool includeNotCompletedRentals)
        {
            
            decimal income = FinancialRecords.CalculateIncome(year);
            if (includeNotCompletedRentals)
            {
                var scootersInUse = ScooterService.GetScootersInUse();
                foreach (var scooter in scootersInUse)
                {
                    income += FinancialRecords.CalculateCharge(scooter.PricePerMinute, DateTime.UtcNow - scooter.RentedAt);
                }
            }

            return income;
        }

        
    }
}
