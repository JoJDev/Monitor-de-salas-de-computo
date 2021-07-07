namespace Monitor_de_salas_de_computo.Modelo
{
    public class Sala
    {
        public Sala()
        {
        }

        public Sala(int id, string nombre, string plantel, string ipInicial, string ipFinal, string gateway, string servidor, string encargado, string telefono)
        {
            SalaId = id;
            Nombre = nombre;
            Plantel = plantel;
            IpInicial = ipInicial;
            IpFinal = ipFinal;
            Gateway = gateway;
            Servidor = servidor;
            Encargado = encargado;
            Telefono = telefono;
        }

        public int SalaId { get; set; }
        public string Nombre { get; set; }
        public string Plantel { get; set; }
        public string IpInicial { get; set; }
        public string IpFinal { get; set; }
        public string Gateway { get; set; }
        public string Servidor { get; set; }
        public string Encargado { get; set; }
        public string Telefono { get; set; }

        public object getPropiedadNum(int index)
        {
            switch (index)
            {
                case 0:
                    return SalaId;

                case 1:
                    return Nombre;

                case 2:
                    return Plantel;

                case 3:
                    return IpInicial;

                case 4:
                    return IpFinal;

                case 5:
                    return Gateway;

                case 6:
                    return Servidor;

                case 7:
                    return Encargado;

                case 8:
                    return Telefono;

                default:
                    return null;
            }
        }

        public void setPropiedadNum(int index, object valor)
        {
            switch (index)
            {
                case 0:
                    SalaId = (int)valor;
                    break;
                case 1:
                    Nombre = (string)valor;
                    break;
                case 2:
                    Plantel = (string)valor;
                    break;
                case 3:
                    IpInicial = (string)valor;
                    break;
                case 4:
                    IpFinal = (string)valor;
                    break;
                case 5:
                    Gateway = (string)valor;
                    break;
                case 6:
                    Servidor = (string)valor;
                    break;
                case 7:
                    Encargado = (string)valor;
                    break;
                case 8:
                    Telefono = (string)valor;
                    break;
            }
        }
    }
}
