using System;
using CajeroLite.IO;
using CajeroLite.POO;

namespace CajeroLite.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IO.IO.MostrarMensaje("===========================================","info");
            Console.WriteLine   ("                Cajero Lite                "  );
            IO.IO.MostrarMensaje("===========================================","info");
            Console.WriteLine();   
            var cajero = new Cajero();
            cajero.Iniciar();
            
        }
    }
}
