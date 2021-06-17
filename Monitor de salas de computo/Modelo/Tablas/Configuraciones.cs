using System;

namespace Monitor_de_salas_de_computo.Modelo
{
    class Configuraciones
    {
        //id, idSala, tiempoEnEspera, permitirUSB
        private int _id, _idSala;
        private DateTime _tiempoEnEspera, _tiempoDeActalizacion;
        private bool _permitirUSB/*en desarrollo*/;

        public Configuraciones()
        {
        }

        public Configuraciones(int id, int idSala, DateTime tiempoEnEspera, DateTime tiempoDeActalizacion, bool permitirUSB)
        {
            Id = id;
            IdSala = idSala;
            TiempoEnEspera = tiempoEnEspera;
            TiempoDeActalizacion = tiempoDeActalizacion;
            PermitirUSB = permitirUSB;
        }

        public int Id { get => _id; set => _id = value; }
        public int IdSala { get => _idSala; set => _idSala = value; }
        public DateTime TiempoEnEspera { get => _tiempoEnEspera; set => _tiempoEnEspera = value; }
        public bool PermitirUSB { get => _permitirUSB; set => _permitirUSB = value; }
        public DateTime TiempoDeActalizacion { get => _tiempoDeActalizacion; set => _tiempoDeActalizacion = value; }
    }
}
