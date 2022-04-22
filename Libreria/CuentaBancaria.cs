namespace Libreria
{
    public class CuentaBancaria
    {
        private int _balance;

        public CuentaBancaria()
        {
            _balance = 0;
        }

        public bool Deposito(int monto)
        {
            _balance += monto;
            return true;
        }

        public bool Retiro(int monto)
        {
            if (monto <= _balance)
            {
                _balance -= monto;
                return true;
            }

            return false;
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}
