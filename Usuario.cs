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
    }
}