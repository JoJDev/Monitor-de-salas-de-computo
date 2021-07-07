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

        public object getPropiedadNum(int index)
        {
            switch (index)
            {
                case 0:
                    return ConfId;

                case 1:
                    return SalaId;

                case 2:
                    return TiempoEnEspera;

                case 3:
                    return PermitirUSB;

                case 4:
                    return TiempoDeActalizacion;

                case 5:
                    return NumRegistrosMostrados;

                default:
                    return null;
            }
        }

        public void setPropiedadNum(int index, object valor)
        {
            switch (index)
            {
                case 0:
                    ConfId = (int)valor;
                    break;
                case 1:
                    SalaId = (int)valor;
                    break;
                case 2:
                    TiempoEnEspera = (DateTime)valor;
                    break;
                case 3:
                    PermitirUSB = (bool)valor;
                    break;
                case 4:
                    TiempoDeActalizacion = (DateTime)valor;
                    break;
                case 5:
                    NumRegistrosMostrados = (int)valor;
                    break;
            }
        }
    }
}
