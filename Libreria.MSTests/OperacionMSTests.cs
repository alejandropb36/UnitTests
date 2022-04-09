using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Libreria.MSTests
{
    [TestClass]
    public class OperacionMSTests
    {
        [TestMethod]
        public void SumaNumeros_InputDosNumeros_GetValorCorrecto()
        {
            // Arrange
            // Inicializacion de los valores que se necesitan
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
