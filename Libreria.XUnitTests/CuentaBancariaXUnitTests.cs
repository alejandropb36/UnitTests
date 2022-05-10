using Moq;
using Xunit;

namespace Libreria
{
    public class CuentaBancariaXUnitTests
    {
        private CuentaBancaria cuenta;

        [Fact]
        public void Deposito_InputMonto100LoggerFake_ReturnTrue()
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerFake());
            int monto = 100;
            var resultado = cuentaBancaria.Deposito(monto);

            Assert.True(resultado);
            Assert.Equal(monto, cuentaBancaria.GetBalance());
        }

        [Fact]
        public void Deposito_InputMonto100Mocking_ReturnTrue()
        {
            var LoggerMocking = new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(LoggerMocking.Object);
            int monto = 100;
            var resultado = cuentaBancaria.Deposito(monto);

            Assert.True(resultado);
            Assert.Equal(monto, cuentaBancaria.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
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
            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 300)]
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
            Assert.False(result);
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMocking_ReturnTrue()
        {
            var loggerMocking = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola mundo";
            loggerMocking.Setup(l => l.MessageConReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());

            var result = loggerMocking.Object.MessageConReturnString("holA MundO");

            Assert.Equal(textoPrueba, result);
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingOutPut_ReturnsTrue()
        {
            var loggerGeneral = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola";

            loggerGeneral.Setup(l => l.MessageConOutParametroReturnBoolean(It.IsAny<string>(), out textoPrueba)).Returns(true);

            string patamtroOut = "";
            var result = loggerGeneral.Object.MessageConOutParametroReturnBoolean("Alejandro", out patamtroOut);

            Assert.True(result);
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingObjetoReferencia_ReturnsTrue()
        {
            var loggerGeneral = new Mock<ILoggerGeneral>();
            Cliente cliente = new();
            Cliente clienteNoUsando = new();
            loggerGeneral.Setup(l => l.MessageConObjetoReferenciaReturnBoolean(ref cliente)).Returns(true);

            var result = loggerGeneral.Object.MessageConObjetoReferenciaReturnBoolean(ref cliente);

            Assert.True(result);
            Assert.False(loggerGeneral.Object.MessageConObjetoReferenciaReturnBoolean(ref clienteNoUsando));
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_LogMockingPropiedadPrioridadTipo_ReturnsTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            loggerGeneralMock.SetupAllProperties();
            loggerGeneralMock.Setup(l => l.TipoLogger).Returns("warning");
            loggerGeneralMock.Setup(l => l.PrioridadLogger).Returns(10);

            Assert.Equal(10, loggerGeneralMock.Object.PrioridadLogger);
            Assert.Equal("warning", loggerGeneralMock.Object.TipoLogger);

            // Callbacks
            string textoTemp = "Alejandro";
            loggerGeneralMock.Setup(l => l.LogDatabase(It.IsAny<string>()))
                .Returns(true)
                .Callback((string parametro) => textoTemp += parametro);

            loggerGeneralMock.Object.LogDatabase("Ponce");

            Assert.Equal("AlejandroPonce", textoTemp);

            int contador = 5;
            loggerGeneralMock.Setup(l => l.LogDatabase(It.IsAny<string>()))
                .Returns(true)
                .Callback(() => contador++);

            loggerGeneralMock.Object.LogDatabase("Ponce");

            Assert.Equal(6, contador);
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_VerifyEjemplo()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            CuentaBancaria cuenta = new(loggerGeneralMock.Object);
            cuenta.Deposito(100);
            Assert.Equal(100, cuenta.GetBalance());

            // Verifica cuantas veces el mock llama al metodo .Message
            loggerGeneralMock.Verify(v => v.Message(It.IsAny<string>()), Times.Exactly(4));

            loggerGeneralMock.Verify(v => v.Message("Visita alex.com"), Times.AtLeastOnce);

            loggerGeneralMock.VerifySet(v => v.PrioridadLogger = 100, Times.Once);

            loggerGeneralMock.VerifyGet(v => v.PrioridadLogger, Times.Once);
        }

    }
}
