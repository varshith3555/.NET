using EmployeeApp.Core;
using Moq;
using NUnit.Framework;

namespace EmployeeApp.Tests
{
    [TestFixture]
    public class VarshithTest
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            int a = 1;
            int b = 2;

            // Act
            int res = _calculator.Add(a, b);

            // Assert
            Assert.That(res, Is.EqualTo(3));
        }
    }
}