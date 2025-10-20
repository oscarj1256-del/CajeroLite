using System;

namespace CajeroLite.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Prueba del módulo IO";

            Console.WriteLine("=======================================");
            Console.WriteLine("  PRUEBA DE LA CLASE IO (Entrada/Salida)");
            Console.WriteLine("=======================================");
            Console.WriteLine();

            //IO.MostrarMensaje("Este es un mensaje informativo (verde).", "info");
            //IO.MostrarMensaje("Este es un mensaje de error (rojo).", "error");
            //IO.MostrarMensaje("Y este es un mensaje neutro (gris).", "otro");
            //Console.WriteLine();

            string nombre = IO.LeerTexto("Por favor, ingrese su nombre: ");
            IO.MostrarMensaje($"Hola, {nombre}! Ingresa Bienvenido al simulador", "info");

            Console.WriteLine();
            Console.Write("Presione cualquier tecla Para CONTINUAR...");
            //Console.ReadKey(intercept: true);
            //string pin = IO.LeerPIN("Ingrese su PIN: ");
            //IO.MostrarMensaje($"PIN ingresado correctamente. (Valor oculto: {pin})", "info");

            Console.WriteLine("=== PRUEBA DE DATOS ===");
            Console.Write("Ingrese un ID de usuario: ");
            string id = Console.ReadLine() ?? "";

            if (Datos.ExisteUsuario(id))
            {
                Console.Write("Ingrese el PIN: ");
                string pin = Console.ReadLine() ?? "";

                if (Datos.ValidarPIN(id, pin))
                {
                    decimal saldo = Datos.ObtenerSaldo(id);
                    Console.WriteLine($"Acceso correcto. Su saldo actual es: {saldo:C}");
                }
                else
                {
                    Console.WriteLine("PIN incorrecto.");
                }
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }


        }

        



    }
}
