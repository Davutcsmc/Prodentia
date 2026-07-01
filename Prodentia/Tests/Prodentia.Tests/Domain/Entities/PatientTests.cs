using Prodentia.Domain.Entities;
using Prodentia.Domain.Exceptions;
using Prodentia.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prodentia.Tests.Domain.Entities
{
    [TestClass]
    public class PatientTests
    {
        [TestMethod]
        public void Constructor_WhenNameIsNull_Throw()
        {
            var email = new Email("test@test.com");
            Assert.ThrowsExactly<BusinessRuleException>(() => new Patient(null!, email));
        }

        [TestMethod]
        public void Constructor_WhenEmailIsNull_Throw()
        {
            var name = "Test Patient";
            Assert.ThrowsExactly<BusinessRuleException>(() => new Patient(name, null!));
        }

        [TestMethod]
        public void Constructor_ValidPatient_CreatesInstance()
        {
            var name = "Test Patient";
            var email = new Email("test@test.com");
            var patient = new Patient(name, email);
            Assert.AreEqual(name, patient.Name);
            Assert.AreEqual(email, patient.Email);
        }
    }
}
