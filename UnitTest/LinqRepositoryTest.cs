using System;
using BussinesErrorDashboard.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void QueueItemsRepository_Tests()
        {
            LinqToSQLRepository repo = new LinqToSQLRepository();
            DateTime? from = null;
            DateTime? to = null;
            string query = "dyn";
            string pName = "";
            

            var test = repo.getData(from, to, query,pName);
            Assert.IsNotNull(test);

        }
    }
}
