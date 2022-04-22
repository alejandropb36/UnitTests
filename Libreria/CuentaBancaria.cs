namespace Libreria
{
    public class CuentaBancaria
    {
        private int _balance;
        private readonly ILoggerGeneral _loggerGeneral;

        public CuentaBancaria(ILoggerGeneral loggerGeneral)
        {
            _balance = 0;
            _loggerGeneral = loggerGeneral;
        }

        public bool Deposito(int monto)
        {
            _balance += monto;
            _loggerGeneral.Message($"El monto: {monto} fue depositado correctamente, balance: {_balance}");
            return true;
        }

        public bool Retiro(int monto)
        {
            if (monto <= _balance)
            {
                _balance -= monto;
                _loggerGeneral.Message($"Retiro exitoso por el monto: {monto}, balance restante: {_balance}");
                return true;
            }

            _loggerGeneral.Message($"Error en el retiro, el monto: {monto} es superior al balance: {_balance}");
            return false;
        }

        public int GetBalance()
        {
            _loggerGeneral.Message($"Consulta de balance: {_balance}");
            return _balance;
        }
    }
}
