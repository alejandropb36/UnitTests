namespace Libreria
{
    public interface ILoggerGeneral
    {
        int PrioridadLogger { get; set; }
        string TipoLogger { get; set; }
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceDespuesRetiro(int balance);
        string MessageConReturnString(string message);
        bool MessageConOutParametroReturnBoolean(string str, out string outputStr);
        bool MessageConObjetoReferenciaReturnBoolean(ref Cliente cliente);
    }

    public class LoggerGeneral : ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }

        public bool LogBalanceDespuesRetiro(int balance)
        {
            if (balance >= 0)
            {
                Console.WriteLine("Exito");
                return true;
            }

            Console.WriteLine("Error");
            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public bool MessageConObjetoReferenciaReturnBoolean(ref Cliente cliente)
        {
            return true;
        }

        public bool MessageConOutParametroReturnBoolean(string str, out string outputStr)
        {
            outputStr = "Hola " + str;
            return true;
        }

        public string MessageConReturnString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }

    public class LoggerFake : ILoggerGeneral
    {
        public int PrioridadLogger { get; set; }
        public string TipoLogger { get; set; }
        public bool LogBalanceDespuesRetiro(int balance) => true;

        public bool LogDatabase(string message) => true;

        public void Message(string message) { }

        public bool MessageConObjetoReferenciaReturnBoolean(ref Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool MessageConOutParametroReturnBoolean(string str, out string outputStr)
        {
            throw new NotImplementedException();
        }

        public string MessageConReturnString(string message)
        {
            return message;
        }
    }
}
