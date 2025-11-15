namespace CajeroLite.POO

{
    public class Usuario
    {
        public string Id { get; private set; }
        public string Pin { get; private set; }
        public string Nombre { get; private set; }
        public Cuenta Cuenta { get; private set; }


        public Usuario(string id, string pin, string nombre, Cuenta cuenta)
        {
            Id = id;
            Pin = pin;
            Nombre = nombre;
            Cuenta = cuenta;
        }
    public static bool ValidarPIN(string nuevoPin)
        {
            // Validar que el PIN tenga 4 dígitos numéricos
            if (nuevoPin.Length != 4 || !nuevoPin.All(char.IsDigit))
            {
                IO.IO.MostrarMensaje("El PIN debe tener exactamente 4 dígitos numéricos.", "error");
                return false;
            }
            IO.IO.MostrarMensaje($"PIN válido: {nuevoPin}", "exito");

            return true;
        }
        
    }
}
