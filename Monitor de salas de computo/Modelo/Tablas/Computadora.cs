using System;

namespace Monitor_de_salas_de_computo.Modelo
{
    class Computadora
    {
        //id, idSala, nombre, ip, submascara, fechaAdqui
        
        public Computadora()
        {
        }

        public Computadora(int id, int sala, string nombre, string ip, string submascar, DateTime fechaAdqui)
        {
            CompId = id;
            SalaId = sala;
            Nombre = nombre;
            Ip = ip;
            Submascara = submascar;
            FechaAdqui = fechaAdqui;
        }

        public int CompId { get; set; }
        public int SalaId { get; set; }
        public string Nombre { get; set; }
        public string Ip { get; set; }
        public string Submascara { get; set; }
        public DateTime FechaAdqui { get; set; }
    }
}
