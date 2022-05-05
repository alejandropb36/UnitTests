//using NUnit.Framework;

//namespace Libreria
//{
//    [TestFixture]
//    public class ClienteXUnitTests
//    {
//        private Cliente cliente;

//        [SetUp]
//        public void SetUp()
//        {
//            cliente = new Cliente();
//        }

//        [Test]
//        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
//        {
//            // Act
//            cliente.CrearNombreCompleto("Alejandro", "Ponce");

//            // Assert
//            Assert.Multiple(() =>
//            {
//                Assert.That(cliente.NombreCliente, Is.EqualTo("Alejandro Ponce"));
//                Assert.AreEqual(cliente.NombreCliente, "Alejandro Ponce");
//                Assert.That(cliente.NombreCliente, Does.Contain("Ponce"));
//                Assert.That(cliente.NombreCliente, Does.Contain("ponce").IgnoreCase);
//                Assert.That(cliente.NombreCliente, Does.StartWith("alejandro").IgnoreCase);
//                Assert.That(cliente.NombreCliente, Does.EndWith("ponce").IgnoreCase);
//            });
//        }

//        [Test]
//        public void NombreCliente_NoValues_ReturnNull()
//        {
//            Assert.IsNull(cliente.NombreCliente);
//        }

//        [Test]
//        public void DescuentoEvaluacion_DefaultCliente_ReturnsDecuentoIntervalo()
//        {
//            int descuento = cliente.Descuento;

//            Assert.That(descuento, Is.InRange(4, 24));
//        }

//        [Test]
//        public void CrearNombreCompleto_InputNombre_ReturnNotNull()
//        {
//            // Act
//            cliente.CrearNombreCompleto("Vaxi", "");

//            Assert.IsNotNull(cliente.NombreCliente);
//            Assert.IsFalse(string.IsNullOrEmpty(cliente.NombreCliente));
//        }

//        [Test]
//        public void CrearNombreCompleto_InputNombreEnBlanco_ThrowException()
//        {
//            var exceptionDetalle = Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Ponce"));

//            Assert.AreEqual("El nombre esta en blanco", exceptionDetalle.Message);

//            Assert.That(() => 
//                cliente.CrearNombreCompleto("", ""),
//                Throws.ArgumentException.With.Message.EqualTo("El nombre esta en blanco")
//            );

//            Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Ponce"));
//            Assert.That(() =>
//                cliente.CrearNombreCompleto("", ""),
//                Throws.ArgumentException
//            );
//        }

//        [Test]
//        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
//        {
//            cliente.OrderTotal = 150;

//            var result = cliente.GetClienteDetalle();

//            Assert.That(result, Is.TypeOf<ClienteBasico>());
//        }

//        [Test]
//        public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClientePremium()
//        {
//            cliente.OrderTotal = 501;

//            var result = cliente.GetClienteDetalle();

//            Assert.That(result, Is.TypeOf<ClientePremium>());
//        }
//    }
//}
