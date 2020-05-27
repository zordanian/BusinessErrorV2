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
            QueueItemsRepository repo = new QueueItemsRepository();
            DateTime? from = null;
            DateTime? to = null;
            String query = "dyn";
            

            var test = repo.getData(from, to, query);
            Assert.IsNotNull(test);

        }
    }
}
