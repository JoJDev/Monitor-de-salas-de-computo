using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Monitor_de_salas_de_computo.Modelo;

namespace Monitor_de_salas_de_computo.Controladores
{
    class AdministradorControl
    {
        public Modelo.Usuario usu { get; set; }
        public Computadora comp { get; set; }
        public Sala sala { get; set; }
        public DateTime fechaInicioSesion { get; set; }
        public TimeSpan duracionSesion { get; set; }
        Registro registro;
        public void PrepararVentana(Modelo.Usuario usuario,Computadora computadora, Window own)
        {

        }
    }
}
