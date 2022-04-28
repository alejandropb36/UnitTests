using Moq;
using NUnit.Framework;

namespace Libreria
{
    [TestFixture]
    public class CuentaBancariaNUnitTests
    {
        private CuentaBancaria cuenta;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Deposito_InputMonto100LoggerFake_ReturnTrue()
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerFake());
            int monto = 100;
            var resultado = cuentaBancaria.Deposito(monto);

            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance(), Is.EqualTo(monto));
        }

        [Test]
        public void Deposito_InputMonto100Mocking_ReturnTrue()
        {
            var LoggerMocking = new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(LoggerMocking.Object);
            int monto = 100;
            var resultado = cuentaBancaria.Deposito(monto);

            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance(), Is.EqualTo(monto));
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retiro)
        {
            // Arrange
            var loggerMocking = new Mock<ILoggerGeneral>();
            loggerMocking.Setup(l => l.LogDatabase(It.IsAny<string>())).Returns(true);
            loggerMocking.Setup(l => l.LogBalanceDespuesRetiro(It.Is<int>(x => x > 0))).Returns(true);
            CuentaBancaria cuenta = new(loggerMocking.Object);
            cuenta.Deposito(balance);

            // Act
            var result = cuenta.Retiro(retiro);

            // Asserts
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(200, 300)]
        public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retiro)
        {
            // Arrange
            var loggerMocking = new Mock<ILoggerGeneral>();
            //loggerMocking.Setup(l => l.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false);
            loggerMocking.Setup(l => l.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);
            CuentaBancaria cuenta = new(loggerMocking.Object);
            cuenta.Deposito(balance);

            // Act
            var result = cuenta.Retiro(retiro);

            // Asserts
            Assert.IsFalse(result);
        }
    }
}
