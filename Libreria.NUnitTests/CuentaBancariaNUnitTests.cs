using NUnit.Framework;

namespace Libreria
{
    [TestFixture]
    public class CuentaBancariaNUnitTests
    {
        private CuentaBancaria cuentaBancaria;

        [SetUp]
        public void SetUp()
        {
            cuentaBancaria = new CuentaBancaria(new LoggerFake());
        }

        [Test]
        public void Deposito_InputMonto100_ReturnTrue()
        {
            int monto = 100;
            var resultado = cuentaBancaria.Deposito(monto);

            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance(), Is.EqualTo(monto));
        }
    }
}
