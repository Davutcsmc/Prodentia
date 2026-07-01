using Prodentia.Domain.Exceptions;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Domain.ValueObjects
{
    [TestClass]
    public class TimeIntervalTests
    {
        [TestMethod]
        public void Constructor_WhenStartIsLaterThanEnd_Throw()
        {
            var startTime = DateTime.UtcNow;
            var endTime = startTime.AddDays(-1);
            var exception = Assert.ThrowsExactly<BusinessRuleException>(() => new TimeInterval(startTime, endTime));
        }

        [TestMethod]
        public void Constructor_WhenStartIsEarlierThanEnd_CreatesInstance()
        {
            var startTime = DateTime.UtcNow;
            var endTime = startTime.AddDays(1);
            var timeInterval = new TimeInterval(startTime, endTime);
            Assert.AreEqual(startTime, timeInterval.Start);
            Assert.AreEqual(endTime, timeInterval.End);
        }
    }
}
