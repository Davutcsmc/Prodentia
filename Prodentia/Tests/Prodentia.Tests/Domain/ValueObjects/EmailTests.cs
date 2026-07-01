using Prodentia.Domain.Exceptions;
using Prodentia.Domain.ValueObjects;

namespace Prodentia.Tests.Domain.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void Constructor_WhenEmailIsNullOrEmpty_Throw()
        {
            var exception = Assert.ThrowsExactly<BusinessRuleException>(() => new Email(null!));
        }

        [TestMethod]
        public void Constructor_WhenEmailWithoutAtSymbol_Throw()
        {
            var exception = Assert.ThrowsExactly<BusinessRuleException>(() => new Email("invalidemail.com"));
        }

        [TestMethod]
        public void Constructor_WhenEmailIsValid_CreatesInstance()
        {
            var email = new Email("test@example.com");
            Assert.AreEqual("test@example.com", email.Value);
        }
    }
}
