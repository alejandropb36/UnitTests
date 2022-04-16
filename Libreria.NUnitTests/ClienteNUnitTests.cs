using NUnit.Framework;

namespace Libreria
{
    [TestFixture]
    public class ClienteNUnitTests
    {
        [Test]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            // Arrange
            Cliente cliente = new();

            // Act
            string nombreCompleto = cliente.CrearNombreCompleto("Alejandro", "Ponce");

            // Assert
            Assert.That(nombreCompleto, Is.EqualTo("Alejandro Ponce"));
        }
    }
}
