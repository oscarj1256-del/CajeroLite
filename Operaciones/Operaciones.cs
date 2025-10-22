using System;

namespace CajeroLite.App
{
    public static class Operaciones
    {
        public static bool EjecutarOperacion(string idUsuario, string opcion)
        {
            // Validamos que la opción sea válida usando Utilidades
            if (!Utilidades.ValidarOpcionMenu(opcion))
            {
                IO.MostrarMensaje("Opción no válida. Intente de nuevo.", "error");
                Utilidades.Pausar();
                return true;
            }

            switch (opcion)
            {
                case "1": // Consultar saldo
                    decimal saldo = Datos.ObtenerSaldo(idUsuario);
                    IO.MostrarMensaje($"Su saldo actual es: {saldo:C}", "info");
                    break;

                case "2": // Depósito
                    string montoDepositoTexto = IO.LeerTexto("Ingrese el monto a depositar: ");
                    if (Utilidades.ValidarMonto(montoDepositoTexto))
                    {
                        decimal montoDeposito = decimal.Parse(montoDepositoTexto);
                        decimal saldoActual = Datos.ObtenerSaldo(idUsuario);
                        saldoActual += montoDeposito;
                        Datos.ActualizarSaldo(idUsuario, saldoActual);
                        IO.MostrarMensaje($"Depósito exitoso. ", "exito");
                        IO.MostrarMensaje($"Nuevo saldo: {saldoActual:C}", "info");
                    }
                    else
                    {
                        IO.MostrarMensaje("Monto inválido. Intente nuevamente.", "error");
                    }
                    break;

                case "3": // Retiro
                    string montoRetiroTexto = IO.LeerTexto("Ingrese el monto a retirar: ");
                    if (Utilidades.ValidarMonto(montoRetiroTexto))
                    {
                        decimal montoRetiro = decimal.Parse(montoRetiroTexto);
                        decimal saldoDisponible = Datos.ObtenerSaldo(idUsuario);
                        if (montoRetiro <= saldoDisponible)
                        {
                            saldoDisponible -= montoRetiro;
                            Datos.ActualizarSaldo(idUsuario, saldoDisponible);
                            IO.MostrarMensaje($"Retiro exitoso. ", "exito");
                            IO.MostrarMensaje($"Nuevo saldo: {saldoDisponible:C}", "info");                            
                        }
                        else
                        {
                            IO.MostrarMensaje("Fondos insuficientes.", "error");
                        }
                    }
                    else
                    {
                        IO.MostrarMensaje("Monto inválido. Intente nuevamente.", "error");
                    }
                    break;

                case "4": // Salir
                    IO.MostrarMensaje("¡Gracias por usar CajeroLite!", "exito");
                    return false;
            }

            Utilidades.Pausar();
            return true;
        }
    }
}
