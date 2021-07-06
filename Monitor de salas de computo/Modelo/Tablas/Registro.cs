using System;

namespace Monitor_de_salas_de_computo.Modelo
{
    public class Registro
    {
        //id, idUsuario, idCompu, fechaIncio, duracionTiempo, tipoDesconexion, 

        public int RegistroId { get; set; }
        public int UsuarioId { get; set; }
        public int CompId { get; set; }
        public DateTime FechaInicio { get; set; }
        public TimeSpan DuracionTiempo { get; set; }
        public string TipoDesconexion { get; set; }


        //Tipos de desconexion:
        // conecado = conectado
        // desconexionNormal = desconexion normal
        // desconexionInesperada = desconexion por apagado de maqui repentino
        // desconexionInactivo = desconexion por tiempo en espera escesivo
        // desconexionAdministrada = desconexion por admin (en desarrollo)
        public enum Desconecciones
        {
            Conectado,
            DesconexionNormal,
            DesconexionInesperada,
            DesconexionInactivo,
            DesconexionAdministrada
        }

        public Registro(int id, int idUsuario, int idCompu, DateTime fechaIncio, TimeSpan duracionTiempo, string tipoDesconexion)
        {
            RegistroId = id;
            UsuarioId = idUsuario;
            CompId = idCompu;
            FechaInicio = fechaIncio;
            DuracionTiempo = duracionTiempo;
            TipoDesconexion = tipoDesconexion;
        }

        public Registro()
        {
        }
    }
}
