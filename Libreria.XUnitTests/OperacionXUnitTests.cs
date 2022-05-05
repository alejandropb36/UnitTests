using Xunit;

namespace Libreria
{
    public class OperacionXUnitTests
    {
        [Fact]
        public void SumaNumeros_InputDosNumeros_GetValorCorrecto()
        {
            // Arrange
            Operacion operacion = new();
            int a = 50;
            int b = 69;

            // Act
            int resultado = operacion.SumarNumeros(a, b);

            // Assert
            Assert.Equal(119, resultado);
        }

        [Theory]
        [InlineData(7, false)]
        [InlineData(9, false)]
        [InlineData(223, false)]
        public void IsValorPar_InputNumeroImpar_GetValorFalse(int numero, bool expected)
        {
            // Arrange
            Operacion operacion = new();

            // Act
            var result = operacion.IsValorPar(numero);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(222)]
        public void IsValorPar_InputNumeroPar_GetValorTrue(int numero)
        {
            // Arrange
            Operacion operacion = new();

            // Act
            bool resultado = operacion.IsValorPar(numero);

            // Assert
            Assert.True(resultado);
        }

        [Theory]
        [InlineData(2.2, 1.2)] // 3.4
        [InlineData(2.23, 1.24)] // 3.47
        public void SumarDecimal_InputDosNumeros_GetValorCorrecto(double numero1, double numero2)
        {
            // Arrange
            Operacion operacion = new();

            // Act
            double resultado = operacion.SumarDecimal(numero1, numero2);

            // Assert
            Assert.Equal(3.4, resultado, 0);
        }

        [Fact]
        public void GetListaNumeroImpares_InputMinimoMaximoIntervalos_ReturnListaImpares()
        {
            // Arrange
            Operacion op = new();
            List<int> numerosImparesEsperado = new() { 5, 7, 9 };

            // Act
            var result = op.GetListaNumeroImpares(5, 10);

            // Asserts
            Assert.Equal(numerosImparesEsperado, result);
            Assert.Contains(5, result);
            Assert.Contains(5, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(100, result);
            Assert.Equal(result.OrderBy(u => u), result);
        }
    }
}
