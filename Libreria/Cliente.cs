namespace Libreria
{
    public class Cliente
    {
        public string? NombreCliente { get; set; }
        public int Descuento { get; set; } = 10;
        public int OrderTotal { get; set; }

        public string CrearNombreCompleto(string nombre, string apellido)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre esta en blanco");
            }
            Descuento = 30;
            NombreCliente = $"{nombre} {apellido}";
            return NombreCliente;
        }

        public TipoCliente GetClienteDetalle()
        {
            if (OrderTotal < 500)
            {
                return new ClienteBasico();
            }

            return new ClientePremium();
        }
    }

    public class TipoCliente
    {

    }

    public class ClienteBasico : TipoCliente
    {

    }

    public class ClientePremium : TipoCliente
    {

    }
}
