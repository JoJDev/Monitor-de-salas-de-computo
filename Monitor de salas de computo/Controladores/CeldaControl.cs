using System;
using System.Collections.Generic;
using System.Text;
using Monitor_de_salas_de_computo.Modelo;

namespace Monitor_de_salas_de_computo.Controladores
{
    class CeldaControl
    {
        public object DatoOriginal { get; set; }
        public string Operacion { get; set; }
        /* 
         * Codigo de operaciones:
         * "eli" = Eliminar
         * "mod" = modificar
         * "cre" = crear
         */
        public int IdElemento { get; }

        public CeldaControl(Registro datoOriginal, string operacion, int idElemento)
        {
            DatoOriginal = datoOriginal;
            Operacion = operacion;
            IdElemento = idElemento;
        }

        public CeldaControl(Usuario datoOriginal, string operacion, int idElemento)
        {
            DatoOriginal = datoOriginal;
            Operacion = operacion;
            IdElemento = idElemento;
        }

        public CeldaControl(Sala datoOriginal, string operacion, int idElemento)
        {
            DatoOriginal = datoOriginal;
            Operacion = operacion;
            IdElemento = idElemento;
        }

        public CeldaControl(Computadora datoOriginal, string operacion, int idElemento)
        {
            DatoOriginal = datoOriginal;
            Operacion = operacion;
            IdElemento = idElemento;
        }

        public CeldaControl(Configuraciones datoOriginal, string operacion, int idElemento)
        {
            DatoOriginal = datoOriginal;
            Operacion = operacion;
            IdElemento = idElemento;
        }
    }
}
