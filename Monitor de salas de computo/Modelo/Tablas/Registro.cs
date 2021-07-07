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

        public Registro(int idRegistro, int idUsuario, int idCompu, DateTime fechaIncio, TimeSpan duracionTiempo, string tipoDesconexion)
        {
            RegistroId = idRegistro;
            UsuarioId = idUsuario;
            CompId = idCompu;
            FechaInicio = fechaIncio;
            DuracionTiempo = duracionTiempo;
            TipoDesconexion = tipoDesconexion;
        }

        public Registro()
        {
        }
        public object getPropiedadNum(int index)
        {
            switch (index)
            {
                case 0:
                    return RegistroId;

                case 1:
                    return UsuarioId;

                case 2:
                    return CompId;

                case 3:
                    return FechaInicio;

                case 4:
                    return DuracionTiempo;

                case 5:
                    return TipoDesconexion;

                default:
                    return null;
            }
        }

        public void setPropiedadNum(int index, object valor)
        {
            switch (index)
            {
                case 0:
                    RegistroId = (int)valor;
                    break;
                case 1:
                    UsuarioId = (int)valor;
                    break;
                case 2:
                    CompId = (int)valor;
                    break;
                case 3:
                    FechaInicio = (DateTime)valor;
                    break;
                case 4:
                    DuracionTiempo = (TimeSpan)valor;
                    break;
                case 5:
                    TipoDesconexion = (string)valor;
                    break;
            }
        }

    }
}
