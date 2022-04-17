namespace Libreria
{
    public class Operacion
    {
        public List<int> NumeroImpares = new();
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

        public List<int> GetListaNumeroImpares(int intervaloMinimo, int intervaloMaximo)
        {
            NumeroImpares.Clear();
            for(int i = intervaloMinimo; i<=intervaloMaximo; i++)
            {
                if (i % 2 != 0)
                {
                    NumeroImpares.Add(i);
                }
            }

            return NumeroImpares;
        }
    }
}