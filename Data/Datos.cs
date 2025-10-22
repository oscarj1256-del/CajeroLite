using System;

namespace CajeroLite.App
{
    public static class Datos
    {
        // Arreglos paralelos: cada índice representa al mismo usuario
        private static string[] Usuarios = { "1001", "2002" };
        private static string[] Pines = { "1234", "5678" };
        private static decimal[] Saldos = { 500000m, 1200000m };


        // acá esta vaina va a devolver el ID del usuario si el login es exitoso; si no pos retorna null.
        public static string? IniciarSesion()
        {
            int intentosRestantes = 3;               // Contadordeintentos: lo empezamos con 3 intentos.
            string? usuarioAutenticado = null;       // Aún no hay usuario autenticado.(se ponse string? para que admita null)

            while (intentosRestantes > 0 && usuarioAutenticado is null)   // hacemos ciclo mientras queden intentos y no haya login.
            {
                // Solicitar credenciales 
                string id = IO.LeerTexto("Ingrese su ID de usuario: ");
                string pin = IO.LeerPIN("Ingrese su PIN: ");

                // comporbamos si existe el usuario con el medoto de DATOS
                if (!Datos.ExisteUsuario(id))
                {
                    IO.MostrarMensaje("Usuario no encontrado.", "error");
                    intentosRestantes--;                          //le vamo a restar un intento
                    IO.MostrarMensaje($"Intentos restantes: {intentosRestantes}", "otro");
                    continue;                                     // repetir desde inicio del bucle
                }

                //Validar PIN desde Datos
                if (!Datos.ValidarPIN(id, pin))
                {
                    IO.MostrarMensaje("PIN incorrecto.", "error");
                    intentosRestantes--;
                    IO.MostrarMensaje($"Intentos restantes: {intentosRestantes}", "otro");
                    continue;
                }

                //Si pasa ambas validaciones, éxito
                IO.MostrarMensaje("Inicio de sesión exitoso.", "info");
                usuarioAutenticado = id;
            }

            //Si no se autenticó, retorna null; si sí, retorna el id
            return usuarioAutenticado;
        }

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
