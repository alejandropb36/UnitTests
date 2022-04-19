namespace Libreria
{
    public class Cliente
    {
        public string? NombreCliente { get; set; }
        public int Descuento { get; set; } = 10;

        public string CrearNombreCompleto(string nombre, string apellido)
        {
            Descuento = 30;
            NombreCliente = $"{nombre} {apellido}";
            return NombreCliente;
        }
    }
}
