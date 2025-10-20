using System;

namespace CajeroLite.App
{
    public static class Datos
    {
        // Arreglos paralelos: cada índice representa al mismo usuario
        private static string[] Usuarios = { "1001", "2002" };
        private static string[] Pines = { "1234", "5678" };
        private static decimal[] Saldos = { 500000m, 1200000m };

       // Verifica si el usuario existe en el sistema.
       
        public static bool ExisteUsuario(string id)
        {
            return Array.IndexOf(Usuarios, id) >= 0;
        }        
        // Valida que el PIN corresponda al usuario.        
        public static bool ValidarPIN(string id, string pin)
        {
            int index = Array.IndexOf(Usuarios, id);
            if (index == -1) return false;
            return Pines[index] == pin;
        }   
        // Devuelve el saldo actual del usuario.
        
        public static decimal ObtenerSaldo(string id)
        {
            int index = Array.IndexOf(Usuarios, id);
            if (index == -1)
                throw new Exception("Usuario no encontrado.");
            return Saldos[index];
        }
        // Actualiza el saldo después de un depósito o retiro.
      
        public static void ActualizarSaldo(string id, decimal nuevoSaldo)
        {
            int index = Array.IndexOf(Usuarios, id);
            if (index == -1)
                throw new Exception("Usuario no encontrado.");

            Saldos[index] = nuevoSaldo;
        }
    }
}
