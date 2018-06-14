using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Library_methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLibraryTests
{
    [TestClass]
    public class ProjectTests
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException), "The parameters can't be less than zero!")]
        public void BMICalculatingNegativeParameters()
        {
            var lib = new Library();
            var weight = -57;
            var height = -1.72;
            var bmi = lib.BMICalculator(weight, height);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BMICalculatingNullParameters()
        {
            var lib = new Library();
            var weight = 0;
            var height = 1.80;
            var bmi = lib.BMICalculator(weight, height);
        }
        [TestMethod]
        public void BMICalculating()
        {
            var lib = new Library();
            var weight = 57;
            var height = 1.72;
            var bmi = lib.BMICalculator(weight, height);
            var expectedValue = 19.2671714440238;
            Assert.AreEqual(expectedValue, bmi);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Unknow value as a parameter")]
        public void BMIDescriptionIvalidParameters()
        {
            var lib = new Library();
            var bmi = -13;
            var bmiDescriptionExpectedValue = lib.BMIDescription(bmi);
        }

        [TestMethod]
        public void IsOver18Check()
        {
            var lib = new Library();
            var passingYear = 1945;
            var result = lib.Over18Check(passingYear);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Person should be over 18.")]
        public void IsOver18CheckRaiseError()
        {
            var lib = new Library();
            var failingYear = 2010;
            var result = lib.Over18Check(failingYear);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\data.csv", "data#csv", DataAccessMethod.Sequential),
            DeploymentItem("data.csv"), TestMethod]
        public void AgeCheckingTest()
        {
            var lib = new Library();
            var yearOfBirth = Int32.Parse(TestContext.DataRow["Year"].ToString());
            bool expectedValue = true;
            var result = lib.Over18Check(yearOfBirth);
            Assert.AreEqual(expectedValue, result);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
       "|DataDirectory|\\data.csv", "data#csv", DataAccessMethod.Sequential),
       DeploymentItem("data.csv"), TestMethod]
        public void ObeseCheckingTest()
        {
            var lib = new Library();
            Regex obese = new Regex(@"/[obese]/");
            var weight = Double.Parse(TestContext.DataRow["Weight"].ToString());
            var height = Double.Parse(TestContext.DataRow["Height"].ToString());
            var bmi = lib.BMICalculator(weight, height);
            var bmiDescriptionExpectedValue = lib.BMIDescription(bmi);
            StringAssert.DoesNotMatch(bmiDescriptionExpectedValue, obese);
        }

        [TestMethod]
        public void SortingTest()
        {
            var lib = new Library();
            List<string> myList = new List<string>() { "Malgorzata", "Kamil", "Aleksandra", "Ewa" };
            var result = lib.Alphabetical(myList);
            List<string> expected = new List<string>() { "Aleksandra", "Ewa", "Malgorzata", "Kamil" };
            CollectionAssert.Equals(expected, myList);
        }
    }
}

