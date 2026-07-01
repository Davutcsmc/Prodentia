using Prodentia.Domain.Entities;
using Prodentia.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Domain.Entities
{
    [TestClass]
    public class DentalOfficeTests
    {
        [TestMethod]
        public void Constructor_WhenNameIsNull_Throw()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() => new DentalOffice(null!));
        }

        [TestMethod]
        public void Constructor_ValidDentalOffice_CreatesInstance()
        {
            var name = "Test Dental Office";

            var dentalOffice = new DentalOffice(name);

            Assert.AreEqual(name, dentalOffice.Name);
        }
    }
}
