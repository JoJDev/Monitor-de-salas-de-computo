namespace Monitor_de_salas_de_computo.Modelo
{
    class Sala
    {
        // id, nombre, plantel, ipInicial, ipFinal, gateway, servidor, encargado, telefono
        private int _id;
        private string _nombre, _plantel, _ipInicial, _ipFinal, _gateway, _servidor, _encargado, _telefono;

        public Sala()
        {
        }

        public Sala(int id, string nombre, string plantel, string ipInicial, string ipFinal, string gateway, string servidor, string encargado, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Plantel = plantel;
            IpInicial = ipInicial;
            IpFinal = ipFinal;
            Gateway = gateway;
            Servidor = servidor;
            Encargado = encargado;
            Telefono = telefono;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Plantel { get => _plantel; set => _plantel = value; }
        public string IpInicial { get => _ipInicial; set => _ipInicial = value; }
        public string IpFinal { get => _ipFinal; set => _ipFinal = value; }
        public string Gateway { get => _gateway; set => _gateway = value; }
        public string Servidor { get => _servidor; set => _servidor = value; }
        public string Encargado { get => _encargado; set => _encargado = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
    }
}
