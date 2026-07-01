using Prodentia.Domain.Entities;
using Prodentia.Domain.Exceptions;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Domain.Entities
{
    [TestClass]
    public class DentistTests
    {
        [TestMethod]
        public void Constructor_WhenNameIsNull_Throw()
        {
            var email = new Email("test@test.com");
            Assert.ThrowsExactly<BusinessRuleException>(() => new Dentist(null!, email));
        }

        [TestMethod]
        public void Constructor_WhenEmailIsNull_Throw()
        {
            var name = "Test Dentist";
            Assert.ThrowsExactly<BusinessRuleException>(() => new Dentist(name, null!));
        }

        [TestMethod]
        public void Constructor_ValidDentist_CreatesInstance()
        {
            var name = "Test Dentist";
            var email = new Email("test@test.com");
            var dentist = new Dentist(name, email);
            Assert.AreEqual(name, dentist.Name);
            Assert.AreEqual(email, dentist.Email);
        }
    }
}
