using System;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using Xunit;
using ScooterRental;
namespace ScooterRentalTests
{
    public class FinancialRecordsTests
    {
        [Fact]
        public void FinancialRecord_ShouldBeInitialized()
        {
            var record = new FinancialRecord("test",DateTime.UtcNow, 0);

            foreach (PropertyInfo prop in record.GetType().GetProperties())
            {
               Assert.NotNull(prop.GetValue(record));
            }
        }
    }
}