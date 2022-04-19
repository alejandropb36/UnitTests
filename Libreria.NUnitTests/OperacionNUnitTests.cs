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

        [Test]
        [TestCase(2.2, 1.2)] // 3.4
        [TestCase(2.23, 1.24)] // 3.47
        public void SumarDecimal_InputDosNumeros_GetValorCorrecto(double numero1, double numero2)
        {
            // Arrange
            Operacion operacion = new();

            // Act
            double resultado = operacion.SumarDecimal(numero1, numero2);

            // Assert
            Assert.AreEqual(3.4, resultado, 0.1);
        }

        [Test]
        public void GetListaNumeroImpares_InputMinimoMaximoIntervalos_ReturnListaImpares()
        {
            // Arrange
            Operacion op = new();
            List<int> numerosImparesEsperado = new() { 5, 7, 9 };

            // Act
            var result = op.GetListaNumeroImpares(5, 10);

            // Asserts
            Assert.That(result, Is.EqualTo(numerosImparesEsperado));
            Assert.AreEqual(numerosImparesEsperado, result);
            Assert.That(result, Does.Contain(5));
            Assert.Contains(5, result);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(100));
            Assert.That(result, Is.Ordered.Ascending);
            Assert.That(result, Is.Unique);
        }
    }
}
