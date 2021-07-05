using System;

namespace Monitor_de_salas_de_computo.Modelo
{
    public class Registro
    {
        //id, idUsuario, idCompu, fechaIncio, duracionTiempo, tipoDesconexion, 

        public int RegistroId { get; set; }
        public int UsuarioId { get; set; }
        public int CompId { get; set; }
        public DateTime FechaIncio { get; set; }
        public DateTime DuracionTiempo { get; set; }
        public int TipoDesconexion { get; set; }


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
            RegistroId = id;
            UsuarioId = idUsuario;
            CompId = idCompu;
            FechaIncio = fechaIncio;
            DuracionTiempo = duracionTiempo;
            TipoDesconexion = tipoDesconexion;
        }

        public Registro()
        {
        }
    }
}
