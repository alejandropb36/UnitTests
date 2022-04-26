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
    }
}
