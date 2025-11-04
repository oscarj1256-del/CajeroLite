namespace CajeroLite.POO
{
    public class Cuenta
    {
        public decimal Saldo { get; private set; }

        public Cuenta(decimal saldoInicial)
        {
            Saldo = saldoInicial;
        }

        public void Depositar(decimal monto)
        {
            Saldo += monto;
        }

        public bool Retirar(decimal monto)
        {
            if (monto <= Saldo)
            {
                Saldo -= monto;
                return true;
            }
            return false;
        }

        public decimal ConsultarSaldo()
        {
            return Saldo;
        }
    }
}
