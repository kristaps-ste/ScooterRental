using System;
using System.Reflection;
using Xunit;
using ScooterRental;
using ScooterRental.Finances;

namespace ScooterRentalTests
{
    public class FinancesTests
    {
        private IFinancialRecords FinancialRecordsInstance { get;}

        public FinancesTests()
        {
            FinancialRecordsInstance=new FinancialRecords();
        }

        [Fact]
        public void FinancialRecord_ShouldBeInitialized()
        {
            IFinancialRecord record = new FinancialRecord("test",DateTime.UtcNow, 0);

            foreach (PropertyInfo prop in record.GetType().GetProperties())
            {
               Assert.NotNull(prop.GetValue(record));
            }
        }

        [Fact]

        public void FinancialRecordsRegisterShouldBeInitialized()
        {
            Assert.NotNull(FinancialRecordsInstance.FinancialRecordRegister);
        }

        [Fact]
        public void AddRecord_ShouldBeAbleToAddNewRecordToRegister()
        {
            int expected = 1;

            IFinancialRecord record = new FinancialRecord("1", new DateTime(), 0);

            FinancialRecordsInstance.AddRecord(record);

            Assert.Equal(expected,FinancialRecordsInstance.FinancialRecordRegister.Count);
        }
    }
}