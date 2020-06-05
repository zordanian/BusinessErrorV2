using BusinessErrorV2.Repository;
using System;
using Xunit;

namespace Tests
{
    public class LinqRepoTests
    {
        [Theory]
        [InlineData("", "1109671270", 0)]
        [InlineData("", "Illikvide aktier", 100)]
        public void GetData_should_return_records(string processName, string reference, int expected)
        {

            LinqToSQLRepository repo = new LinqToSQLRepository();
            DateTime? dateFrom = null;
            DateTime? dateTo = null;

            var actual = repo.GetData(processName,reference, dateFrom, dateTo).Count;

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void GetWithOnlyDate_should_return_100()
        {
            LinqToSQLRepository repo = new LinqToSQLRepository();
            DateTime? dateFrom = new DateTime(2019, 1, 1);
            DateTime? dateTo = DateTime.Now;

            var actual = repo.GetData("", "", dateFrom, dateTo).Count;
            int expected = 100;

            Assert.Equal(actual, expected);

        }
    }
}
