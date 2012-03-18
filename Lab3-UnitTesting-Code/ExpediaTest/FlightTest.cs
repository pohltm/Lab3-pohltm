using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		//TODO Task 7 items go here
        private readonly DateTime startDate = new DateTime(2007, 10, 21);
        private readonly DateTime endDate = new DateTime(2007, 11, 1);
        private readonly int someMiles = 50;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(startDate, endDate, someMiles);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnInvalidDates()
        {
            DateTime badStartDate = new DateTime(2007, 11, 5);
            new Flight(badStartDate, endDate, someMiles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnInvalidMiles()
        {
            new Flight(startDate, endDate, -50);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayFlight()
        {
            DateTime thisEndDate = new DateTime(2007, 10, 22);
            var target = new Flight(startDate, thisEndDate, someMiles);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayFlight()
        {
            DateTime thisEndDate = new DateTime(2007, 10, 23);
            var target = new Flight(startDate, thisEndDate, someMiles);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayFlight()
        {
            DateTime thisEndDate = new DateTime(2007, 10, 31);
            var target = new Flight(startDate, thisEndDate, someMiles);
            Assert.AreEqual(400, target.getBasePrice());
        }
	}
}
