using Moq;
using NUnit.Framework;

namespace Libreria
{
    [TestFixture]
    public class ProductoXUnitTests
    {
        [Test]
        public void GetPrecio_PremiumCliente_ReturnPrecioDescuento()
        {
            // Arrange
            Producto producto = new()
            {
                Precio = 50
            };

            // Act
            var resultado = producto.GetPrecio(new Cliente { IsPremium = true });

            // Assert
            Assert.That(resultado, Is.EqualTo(40));
        }

        [Test]
        public void GetPrecio_PremiumClienteMockingCliente_ReturnPrecioDescuento()
        {
            // Arrange
            Producto producto = new()
            {
                Precio = 50
            };

            var cliente = new Mock<ICliente>();
            cliente.Setup(c => c.IsPremium).Returns(true);

            // Act
            var resultado = producto.GetPrecio(cliente.Object);

            // Assert
            Assert.That(resultado, Is.EqualTo(40));
        }
    }
}
