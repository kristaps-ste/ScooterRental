using System;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using Xunit;
using ScooterRental;
namespace ScooterRentalTests
{
    public class FinancialRecordsTests
    {
        private FinancialRecords FinancialRecordsInstance { get; set; }

        public FinancialRecordsTests()
        {
            FinancialRecordsInstance=new FinancialRecords();
        }

        [Fact]
        public void FinancialRecord_ShouldBeInitialized()
        {
            var record = new FinancialRecord("test",DateTime.UtcNow, 0);

            foreach (PropertyInfo prop in record.GetType().GetProperties())
            {
               Assert.NotNull(prop.GetValue(record));
            }
        }

        [Fact]

        public void FinancialRecordsRegisterShouldBeInitialized()
        {
            var financialRecordsInstance= new FinancialRecords();
            Assert.NotNull(financialRecordsInstance.FinancialRecordRegister);
        }

        [Fact]
        public void AddRecord_ShouldBeAbleToAddNewRecordToRegister()
        {
            int expected = 1;
            FinancialRecordsInstance.AddRecord(new FinancialRecord("1", new DateTime(),0));

            Assert.Equal(expected,FinancialRecordsInstance.FinancialRecordRegister.Count);
        }

    }
}