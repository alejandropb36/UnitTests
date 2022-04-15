namespace Libreria
{
    public class Operacion
    {
        public int SumarNumeros(int a, int b)
        {
            return a + b;
        }

        public bool  IsValorPar(int number)
        {
            return number % 2 == 0;
        }

        public double SumarDecimal(double numero1, double numero2)
        {
            return numero1 + numero2;
        }
    }
}