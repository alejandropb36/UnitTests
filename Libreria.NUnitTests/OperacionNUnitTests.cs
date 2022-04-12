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
    }
}
