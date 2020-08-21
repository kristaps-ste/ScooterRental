using System;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using Xunit;
using ScooterRental;
namespace ScooterRentalTests
{
    public class FinancesTests
    {
        private FinancialRecords FinancialRecordsInstance { get; set; }

        public FinancesTests()
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

        [Theory]
        [InlineData(0,13)]
        [InlineData(2000,7)]
        [InlineData(2020,0)]
        [InlineData(2005,6)]
       public void CalculateIncome_ShouldSumAllIncomeForGivenYear(int year, decimal expected)
        {
            FinancialRecordsInstance.AddRecord(new FinancialRecord("1", new DateTime(2000,1,1),1));
            FinancialRecordsInstance.AddRecord(new FinancialRecord("2", new DateTime(2000,6,1),6));
            FinancialRecordsInstance.AddRecord(new FinancialRecord("1", new DateTime(2005,1,1),6));
            Assert.Equal(expected,FinancialRecordsInstance.CalculateIncome(year));
        }


    }
}