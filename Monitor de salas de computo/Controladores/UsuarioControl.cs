using System;
using System.Collections.Generic;
using System.Text;
using Monitor_de_salas_de_computo.Modelo;
using System.Windows;

namespace Monitor_de_salas_de_computo.Controladores
{
    class UsuarioControl
    {
        public Modelo.Usuario usu { get; set; }
        public Computadora comp { get; set; }
        public Sala sala { get; set; }
        DateTime fechaInicioSesion{ get; set; }
        TimeSpan duracionSesion { get; set; }

        public void PrepararVentana(Modelo.Usuario usuario,Computadora computadora , Window own)
        {
            usu = usuario;
            comp = computadora;

            if (comp != null)
            {
                SalaORM salaORM = new SalaORM();
                sala = salaORM.Detalle(comp.SalaId);
            }
            fechaInicioSesion = new DateTime();
            duracionSesion = new TimeSpan(0);
        }


    }
}
