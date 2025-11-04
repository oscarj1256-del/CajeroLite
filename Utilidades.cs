using CajeroLite.IO;

namespace CajeroLite.Utilidades
{
    public static class Utilidades
    {
        // que el monto sea numérico y mayor que cero
        public static bool ValidarMonto(string montoTexto)
        {
            if (decimal.TryParse(montoTexto, out decimal monto))
            {
                return monto > 0;
            }
            return false;
        }

        // que la opción ingresada esté dentro del rango permitido
        public static bool ValidarOpcionMenu(string opcion)
        {
            return opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4";
        }

        //  para pausar la consola de forma consistente
        public static void Pausar()
        {
            Console.WriteLine();
            IO.IO.LeerTexto("Presione ENTER para continuar...");
        }
    }
}
