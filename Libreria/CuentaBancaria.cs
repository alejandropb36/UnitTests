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
            _loggerGeneral.Message("Es otro texto");
            _loggerGeneral.Message("Visita alex.com");
            _loggerGeneral.PrioridadLogger = 100;
            var prioridadLogger = _loggerGeneral.PrioridadLogger;
            return true;
        }

        public bool Retiro(int monto)
        {
            if (monto <= _balance)
            {
                _balance -= monto;
                _loggerGeneral.LogDatabase($"Retiro exitoso por el monto: {monto}, balance restante: {_balance}");
                return _loggerGeneral.LogBalanceDespuesRetiro(_balance);
            }

            _loggerGeneral.LogDatabase($"Error en el retiro, el monto: {monto} es superior al balance: {_balance}");
            return _loggerGeneral.LogBalanceDespuesRetiro(_balance - monto);
        }

        public int GetBalance()
        {
            _loggerGeneral.Message($"Consulta de balance: {_balance}");
            return _balance;
        }
    }
}
