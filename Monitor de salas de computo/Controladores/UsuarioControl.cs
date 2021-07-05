using System;
using System.Collections.Generic;
using System.Text;
using Monitor_de_salas_de_computo.Modelo;
using System.Windows;
using System.Windows.Controls;

namespace Monitor_de_salas_de_computo.Controladores
{
    class UsuarioControl
    {
        public Modelo.Usuario usu { get; set; }
        public Computadora comp { get; set; }
        public Sala sala { get; set; }
        public DateTime fechaInicioSesion { get; set; }
        public TimeSpan duracionSesion { get; set; }
        Registro registro;

        public void PrepararVentana(Modelo.Usuario usuario, Computadora computadora, Window own)
        {
            usu = usuario;
            comp = computadora;

            if (comp != null)
            {
                SalaORM salaORM = new SalaORM();
                sala = salaORM.Detalle(comp.SalaId);
            }
            fechaInicioSesion =  DateTime.Now;
            duracionSesion = new TimeSpan(0);

            CrearRegistro();
        }

        private void CrearRegistro()
        {
            registro = new Registro(1, usu.UsuarioId, comp.CompId, fechaInicioSesion, new DateTime(0), ((int)Registro.Desconecciones.Conectado).ToString());
            RegistroORM registroORM = new RegistroORM();

            registroORM.Insertar(registro);
            try
            {
                registro.RegistroId = registroORM.RegresarRegistro(usu.UsuarioId, comp.CompId, fechaInicioSesion.).RegistroId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo registrar correctamente la desconexion del usuario\n{ ex.Message}");
            }

            //return registro;
        }

        public void CerrarSesion()
        {
            registro.TipoDesconexion = ((int)Registro.Desconecciones.DesconexionNormal).ToString();
            registro.DuracionTiempo.AddSeconds(duracionSesion.Seconds);
            try
            {
                RegistroORM regORM = new RegistroORM();
                regORM.Actualizar(registro);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: No se pudo registrar correctamente la desconexion del usuario");
            }
        }

        public void Reloj(Label lab)
        {
            duracionSesion += TimeSpan.FromSeconds(1.0);
            lab.Content = duracionSesion;

            if ((duracionSesion.Minutes % 5 == 0) && (duracionSesion.Seconds == 0))
            {
                RegistroORM regORM = new RegistroORM();
                regORM.Actualizar(registro);
            }
        }

    }
}
