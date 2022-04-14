using NUnit.Framework;

namespace Libreria
{
    [TestFixture]
    public class OperacionNUnitTests
    {
        [Test]
        public void SumaNumeros_InputDosNumeros_GetValorCorrecto()
        {
            // Arrange
            Operacion operacion = new();
            int a = 50;
            int b = 69;

            // Act
            int resultado = operacion.SumarNumeros(a, b);

            // Assert
            Assert.AreEqual(119, resultado);
        }

        [Test]
        [TestCase(7, ExpectedResult = false)]
        [TestCase(9, ExpectedResult = false)]
        [TestCase(223, ExpectedResult = false)]
        public bool IsValorPar_InputNumeroImpar_GetValorFalse(int numero)
        {
            // Arrange
            Operacion operacion = new();

            // Act
            return operacion.IsValorPar(numero);
        }

        [Test]
        [TestCase(6)]
        [TestCase(8)]
        [TestCase(222)]
        public void IsValorPar_InputNumeroPar_GetValorTrue(int numero)
        {
            // Arrange
            Operacion operacion = new();

            // Act
            bool resultado = operacion.IsValorPar(numero);

            // Assert
            Assert.IsTrue(resultado);
            Assert.That(resultado, Is.EqualTo(true));
        }
    }
}
