using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor_de_salas_de_computo.Controladores
{
    class CeldaControl
    {
        public string DatoOriginal { get; set; }
        public string Operacion { get; set; }
        /* 
         * Codigo de operaciones:
         * "eli" = Eliminar
         * "mod" = modificar
         * "cre" = crear
         */
        public int IdElemento { get; }

        public CeldaControl(string datoOriginal, string operacion, int idElemento)
        {
            DatoOriginal = datoOriginal;
            Operacion = operacion;
            IdElemento = idElemento;
        }
    }
}
