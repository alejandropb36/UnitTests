namespace Libreria
{
    public class Cliente
    {
        public string? NombreCliente { get; set; }

        public string CrearNombreCompleto(string nombre, string apellido)
        {
            NombreCliente = $"{nombre} {apellido}";
            return NombreCliente;
        }
    }
}
