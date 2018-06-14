using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_TestyJednostkowe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace _01_TestyJednostkowe.Tests
{
    [TestClass()]
    public class BasicOperationsTests
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod()]
        [TestCategory("Add")]
        [Priority(0)]
        public void AddTest()
        {
            BasicOperations target = new BasicOperations(); // TODO: Initialize to an appropriate value
            int numberA = 0; // TODO: Initialize to an appropriate value
            int numberB = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Add(numberA, numberB);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [TestCategory("Add")]
        [Priority(0)]
        public void SubtractTest()
        {
            BasicOperations target = new BasicOperations(); // TODO: Initialize to an appropriate value
            int numberA = 0; // TODO: Initialize to an appropriate value
            int numberB = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Subtract(numberA, numberB);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory("Multiply")]
        [Priority(0)]
        public void MultiplyTest()
        {
            BasicOperations target = new BasicOperations(); // TODO: Initialize to an appropriate value
            int numberA = 0; // TODO: Initialize to an appropriate value
            int numberB = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Multiply(numberA, numberB);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory("Divide")]
        [Priority(0)]
        public void DivideTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        [TestCategory("Divide")]
        [Priority(1)]
        public void DivideTestEx()
        {
            BasicOperations target = new BasicOperations();
            int numberA = 1; // TODO: Initialize to an appropriate value
            int numberB = 0; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Divide(numberA, numberB);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataSource("System.Data.SqlClient",
            @"Data Source=(localdb)\MyInstance;Integrated Security=True",
            "dbo.Multiply_test",
            DataAccessMethod.Sequential)]
        public void MultiplDBTest()
        {
            BasicOperations target = new BasicOperations();
            int x = Convert.ToInt32(TestContext.DataRow["arg1"]);
            int y = Convert.ToInt32(TestContext.DataRow["arg2"]);
            int expected = Convert.ToInt32(TestContext.DataRow["result"]);
            int actual = target.Multiply(x, y);
            Assert.AreEqual(expected, actual);
        }
    }
}
