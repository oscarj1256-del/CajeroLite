using System;

namespace CajeroLite.IO
{
    public static class IO
    {
        public static void MostrarEncabezado()
        {
            Console.Clear();
            IO.MostrarMensaje("===========================================", "info");
            IO.MostrarMensaje("              Cajero- Lite ", "exito");
            IO.MostrarMensaje("===========================================", "info");
            Console.WriteLine();
        }

        internal static void MostrarMensajeBloqueo()
        {
            MostrarMensaje("Ha excedido el número de intentos. Su cuenta ha sido bloqueada.", "error");
        }

        public static void MostrarMensaje(string mensaje, string tipo = "info")
        {
            ConsoleColor colorOriginal = Console.ForegroundColor;

            switch (tipo.ToLower())
            {
                case "exito":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "info":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "error":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            Console.WriteLine(mensaje);
            Console.ForegroundColor = colorOriginal;
        }

        public static string LeerTexto(string prompt = "")
        {
            if (!string.IsNullOrEmpty(prompt))
            {
                Console.Write(prompt);
            }

            return Console.ReadLine() ?? string.Empty;
        }

        public static string LeerPIN(string mensaje)
        {
            Console.Write(mensaje);

            string pin = string.Empty;
            ConsoleKeyInfo tecla;

            do
            {
                tecla = Console.ReadKey(intercept: true); // intercept evita mostrar la tecla

                if (tecla.Key == ConsoleKey.Enter)
                {
                    // Si el usuario presiona Enter y no ha escrito nada
                    if (string.IsNullOrWhiteSpace(pin))
                    {
                        MostrarMensaje("\nEl PIN no puede estar vacío. Intente nuevamente.", "error");
                        Console.Write(mensaje);
                        continue;
                    }
                    break;
                }

                if (tecla.Key == ConsoleKey.Backspace)
                {
                    // Permitir borrar un dígito
                    if (pin.Length > 0)
                    {
                        pin = pin[..^1]; // elimina el último carácter
                        Console.Write("\b \b"); // borra un asterisco en pantalla
                    }
                }
                else if (char.IsDigit(tecla.KeyChar))
                {
                    if (pin.Length < 4) // solo permite 4 dígitos
                    {
                        pin += tecla.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        // opcional: hacer un sonido si intenta escribir más
                        Console.Beep();
                    }
                }

                else
                {
                    // Si presiona otra tecla, se ignora
                    continue;
                }

            } while (true);

            Console.WriteLine(); // salto de línea al terminar
            return pin;
        }

        
    }
}