using System;

namespace Monitor_de_salas_de_computo.Modelo
{
    class Computadora
    {
        //id, idSala, nombre, ip, submascara, fechaAdqui
        private int _id, _idSala;
        private string _nombre, _ip, _submascar;
        private DateTime _fechaAdqui;

        public Computadora()
        {
        }

        public Computadora(int id, int idSala, string nombre, string ip, string submascar, DateTime fechaAdqui)
        {
            Id = id;
            IdSala = idSala;
            Nombre = nombre;
            Ip = ip;
            Submascar = submascar;
            FechaAdqui = fechaAdqui;
        }

        public int Id { get => _id; set => _id = value; }
        public int IdSala { get => _idSala; set => _idSala = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Ip { get => _ip; set => _ip = value; }
        public string Submascar { get => _submascar; set => _submascar = value; }
        public DateTime FechaAdqui { get => _fechaAdqui; set => _fechaAdqui = value; }
    }
}
