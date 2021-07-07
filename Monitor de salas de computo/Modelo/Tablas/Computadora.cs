using System;

namespace Monitor_de_salas_de_computo.Modelo
{
    public class Computadora
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

        public object getPropiedadNum(int index)
        {
            switch (index)
            {
                case 0:
                    return CompId;

                case 1:
                    return SalaId;

                case 2:
                    return Nombre;

                case 3:
                    return Ip;
             
                case 4:
                    return Submascara;
             
                case 5:
                    return FechaAdqui;

                default:
                    return null;
            }
        }

        public void setPropiedadNum(int index,object valor)
        {
            switch (index)
            {
                case 0:
                    CompId = (int)valor;
                    break;
                case 1:
                    SalaId = (int)valor;
                    break;
                case 2:
                    Nombre = (string)valor;
                    break;
                case 3:
                    Ip = (string)valor;
                    break;
                case 4:
                    Submascara = (string)valor;
                    break;
                case 5:
                    FechaAdqui = (DateTime)valor;
                    break;
            }
        }
    }
}
