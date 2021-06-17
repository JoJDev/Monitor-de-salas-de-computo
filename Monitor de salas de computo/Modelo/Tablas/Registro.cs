using System;

namespace Monitor_de_salas_de_computo.Modelo
{
    class Registro
    {
        //id, idUsuario, idCompu, fechaIncio, duracionTiempo, tipoDesconexion, 
        private int _id, _idUsuario, _idCompu, _tipoDesconexion;
        private DateTime _fechaIncio, _duracionTiempo;

        public int Id { get => _id; set => _id = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdCompu { get => _idCompu; set => _idCompu = value; }
        public int TipoDesconexion { get => _tipoDesconexion; set => _tipoDesconexion = value; }
        public DateTime FechaIncio { get => _fechaIncio; set => _fechaIncio = value; }
        public DateTime DuracionTiempo { get => _duracionTiempo; set => _duracionTiempo = value; }

        //Tipos de desconexion:
        // conecado = conectado
        // desconexionNormal = desconexion normal
        // desconexionInesperada = desconexion por apagado de maqui repentino
        // desconexionInactivo = desconexion por tiempo en espera escesivo
        // desconexionAdministrada = desconexion por admin (en desarrollo)
        enum desconecciones
        {
            conecado,
            desconexionNormal,
            desconexionInesperada,
            desconexionInactivo,
            desconexionAdministrada
        }

        public Registro(int id, int idUsuario, int idCompu, DateTime fechaIncio, DateTime duracionTiempo, int tipoDesconexion)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdCompu = idCompu;
            FechaIncio = fechaIncio;
            DuracionTiempo = duracionTiempo;
            TipoDesconexion = tipoDesconexion;
        }

        public Registro()
        {
        }
    }
}
