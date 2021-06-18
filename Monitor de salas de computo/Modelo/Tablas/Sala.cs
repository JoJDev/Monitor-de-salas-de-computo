namespace Monitor_de_salas_de_computo.Modelo
{
    class Sala
    {
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

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Plantel { get; set; }
        public string IpInicial { get; set; }
        public string IpFinal { get; set; }
        public string Gateway { get; set; }
        public string Servidor { get; set; }
        public string Encargado { get; set; }
        public string Telefono { get; set; }
    }
}
