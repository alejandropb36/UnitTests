using Xunit;

namespace Libreria
{
    public class ClienteXUnitTests
    {
        private Cliente cliente;

        public ClienteXUnitTests()
        {
            cliente = new Cliente();
        }

        [Fact]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            // Act
            cliente.CrearNombreCompleto("Alejandro", "Ponce");

            // Assert
            Assert.Equal("Alejandro Ponce", cliente.NombreCliente);
            Assert.Contains("Ponce",cliente.NombreCliente);
            Assert.StartsWith("Alejandro", cliente.NombreCliente);
            Assert.EndsWith("Ponce", cliente.NombreCliente);
        }

        [Fact]
        public void NombreCliente_NoValues_ReturnNull()
        {
            Assert.Null(cliente.NombreCliente);
        }

        [Fact]
        public void DescuentoEvaluacion_DefaultCliente_ReturnsDecuentoIntervalo()
        {
            int descuento = cliente.Descuento;

            Assert.InRange(descuento, 5, 24);
        }

        [Fact]
        public void CrearNombreCompleto_InputNombre_ReturnNotNull()
        {
            // Act
            cliente.CrearNombreCompleto("Vaxi", "");

            Assert.NotNull(cliente.NombreCliente);
            Assert.False(string.IsNullOrEmpty(cliente.NombreCliente));
        }

        [Fact]
        public void CrearNombreCompleto_InputNombreEnBlanco_ThrowException()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Ponce"));

            Assert.Equal("El nombre esta en blanco", exceptionDetalle.Message);

            Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Ponce"));
        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
        {
            cliente.OrderTotal = 150;

            var result = cliente.GetClienteDetalle();

            Assert.IsType<ClienteBasico>(result);
        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClientePremium()
        {
            cliente.OrderTotal = 501;

            var result = cliente.GetClienteDetalle();

            Assert.IsType<ClientePremium>(result);
        }
    }
}
