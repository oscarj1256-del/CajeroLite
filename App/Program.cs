using System;

namespace CajeroLite.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IO.MostrarMensaje("===========================================","info");
            Console.WriteLine("  Cajero- Lite Oscar Vanegas / Linda Ortiz");
            IO.MostrarMensaje("===========================================","info");
            Console.WriteLine();                  
            
            var usuarioId = Datos.IniciarSesion();

            if (usuarioId is null)
            {
                IO.MostrarMensaje("Acceso bloqueado. Demasiados intentos fallidos.", "error");
                return;
            }

            bool continuar = true;
            while (continuar)
            {
               string opcion = IO.MostrarMenu(usuarioId);
               continuar = Operaciones.EjecutarOperacion(usuarioId, opcion);
            }            
        }
    }
}
