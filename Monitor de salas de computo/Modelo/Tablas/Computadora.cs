using System;

namespace Monitor_de_salas_de_computo.Modelo
{
    class Computadora
    {
        //id, idSala, nombre, ip, submascara, fechaAdqui
        
        public Computadora()
        {
        }

        public Computadora(int id, Sala sala, string nombre, string ip, string submascar, DateTime fechaAdqui)
        {
            Id = id;
            Sala = sala;
            Nombre = nombre;
            Ip = ip;
            Submascar = submascar;
            FechaAdqui = fechaAdqui;
        }

        public int Id { get; set; }
        public Sala Sala { get; set; }
        public string Nombre { get; set; }
        public string Ip { get; set; }
        public string Submascar { get; set; }
        public DateTime FechaAdqui { get; set; }
    }
}
