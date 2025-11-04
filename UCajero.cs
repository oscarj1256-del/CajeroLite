namespace CajeroLite.POO
{
    public class Cajero
    {

        private List<Usuario> usuarios = new()
        {
            new Usuario("1001", "1234", "Oscar Vanegas", new Cuenta(1000)),
            new Usuario("1002", "5678", "Linda Ortiz", new Cuenta(1500)),
            new Usuario("1003", "9012", "Ana Gomez", new Cuenta(2000))
        };

        public void Iniciar()
        {
            IO.IO.MostrarEncabezado();
            var usuario = IniciarSesion();   // pa' que me retorne el usuario autenticado
            if (usuario is null)
                IO.IO.MostrarMensajeBloqueo();
            else
                MostrarMenu(usuario);
        }

        public Usuario? IniciarSesion()
        {

            int intentosRestantes = 3;      // Contar intentos: empezamos con 3 intentos.
            while (intentosRestantes > 0)   // hacemos ciclo mientras queden intentos y no haya login.
            {
                // Solicitar credenciales 
                string id = IO.IO.LeerTexto("Ingrese su ID de usuario: ");
                var usuario = usuarios.FirstOrDefault(user => user.Id == id);


                // Validar credenciales
                if (usuario == null)
                {
                    IO.IO.MostrarMensaje("Usuario no encontrado.", "error");
                    intentosRestantes--;                    // le quitamos un pinchi intento
                    IO.IO.MostrarMensaje($"Intentos restantes: {intentosRestantes}", "otro");
                    continue;   // volver a intentar desde el inicio del ciclo
                }
                else
                {
                    string pin = IO.IO.LeerPIN("Ingrese su PIN: ");
                    if (usuario.Pin == pin)
                    {
                        IO.IO.MostrarMensaje($"¡Bienvenido, {usuario.Nombre}!", "exito");
                        Utilidades.Utilidades.Pausar();
                        return usuario; // Devuelve el usuario autenticado
                    }
                    else
                    {
                        IO.IO.MostrarMensaje("PIN incorrecto.", "error");
                        intentosRestantes--;                      // le quitamos un pinchi intento
                        IO.IO.MostrarMensaje($"Intentos restantes: {intentosRestantes}", "otro");
                    }
                }
            }
            return null; // Si falla todos los intentos, devolvemos null
        }

        
        public void MostrarMenu(Usuario usuarioAutenticado)
        {
            bool repetir = true;

            while (repetir)
            {
                Console.Clear();
                Console.WriteLine($"Usuario conectado: {usuarioAutenticado.Nombre} |  Saldo: {usuarioAutenticado.Cuenta.ConsultarSaldo():C}");
                Console.WriteLine("-------------------------------------");
                IO.IO.MostrarMensaje("======== MENÚ PRINCIPAL ========", "info");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                IO.IO.MostrarMensaje("4. Salir", "info");
                Console.WriteLine();

                string opcion = IO.IO.LeerTexto("Seleccione una opción (1-4): ");

                switch (opcion)
                {
                    case "1":
                        IO.IO.MostrarMensaje($"Saldo actual: {usuarioAutenticado.Cuenta.ConsultarSaldo():C}", "info");
                        break;

                    case "2":
                        string montoDeposito = IO.IO.LeerTexto("Monto a depositar: ");
                        if (Utilidades.Utilidades.ValidarMonto(montoDeposito))
                        {
                            usuarioAutenticado.Cuenta.Depositar(decimal.Parse(montoDeposito));
                            IO.IO.MostrarMensaje("Depósito exitoso.", "exito");
                            IO.IO.MostrarMensaje($"Nuevo saldo: {usuarioAutenticado.Cuenta.ConsultarSaldo():C}", "info");
                        }
                        else
                        {
                            IO.IO.MostrarMensaje("Monto inválido.", "error");
                        }
                        break;

                    case "3":
                        string montoRetiro = IO.IO.LeerTexto("Monto a retirar: ");
                        if (Utilidades.Utilidades.ValidarMonto(montoRetiro))
                        {
                            decimal retiro = decimal.Parse(montoRetiro);
                            if (usuarioAutenticado.Cuenta.Retirar(retiro))
                            {
                                IO.IO.MostrarMensaje("Retiro exitoso.", "exito");
                                IO.IO.MostrarMensaje($"Nuevo saldo: {usuarioAutenticado.Cuenta.ConsultarSaldo():C}", "info");
                            }
                            else
                            {
                                IO.IO.MostrarMensaje("Fondos insuficientes.", "error");
                            }
                        }
                        else
                        {
                            IO.IO.MostrarMensaje("Monto inválido.", "error");
                        }
                        break;

                    case "4":
                        IO.IO.MostrarMensaje("Gracias por usar CajeroLite. ¡Hasta pronto!", "exito");
                        repetir = false;
                        break;

                    default:
                        IO.IO.MostrarMensaje("Opción no válida.", "error");
                        break;
                }

                if (repetir) Utilidades.Utilidades.Pausar();
            }
        }

    }
}