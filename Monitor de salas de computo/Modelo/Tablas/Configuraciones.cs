using System;

namespace Monitor_de_salas_de_computo.Modelo
{
    public class Configuraciones
    {
        public Configuraciones()
        {
        }

        public Configuraciones(int id, int idSala, DateTime tiempoEnEspera, DateTime tiempoDeActalizacion, bool permitirUSB, int numRegistrosMostrados)
        {
            ConfId = id;
            SalaId = idSala;
            TiempoEnEspera = tiempoEnEspera;
            TiempoDeActalizacion = tiempoDeActalizacion;
            PermitirUSB = permitirUSB;
            NumRegistrosMostrados = numRegistrosMostrados;
        }

        public int ConfId { get; set; }
        public int SalaId { get; set; }
        public DateTime TiempoEnEspera { get; set; }
        public bool PermitirUSB { get; set; }
        public DateTime TiempoDeActalizacion { get; set; }
        public int NumRegistrosMostrados { get; set; }
    }
}
