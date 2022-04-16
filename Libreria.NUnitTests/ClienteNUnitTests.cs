using NUnit.Framework;

namespace Libreria
{
    [TestFixture]
    public class ClienteNUnitTests
    {
        private Cliente cliente;

        [SetUp]
        public void SetUp()
        {
            cliente = new Cliente();
        }

        [Test]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            // Act
            cliente.CrearNombreCompleto("Alejandro", "Ponce");

            // Assert
            Assert.That(cliente.NombreCliente, Is.EqualTo("Alejandro Ponce"));
            Assert.AreEqual(cliente.NombreCliente, "Alejandro Ponce");
            Assert.That(cliente.NombreCliente, Does.Contain("Ponce"));
            Assert.That(cliente.NombreCliente, Does.Contain("ponce").IgnoreCase);
            Assert.That(cliente.NombreCliente, Does.StartWith("alejandro").IgnoreCase);
            Assert.That(cliente.NombreCliente, Does.EndWith("ponce").IgnoreCase);
        }

        [Test]
        public void NombreCliente_NoValues_ReturnNull()
        {
            Assert.IsNull(cliente.NombreCliente);
        }
    }
}
