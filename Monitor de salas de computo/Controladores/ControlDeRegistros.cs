using Monitor_de_salas_de_computo.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Monitor_de_salas_de_computo.Controladores
{
    class ControlDeRegistros
    {
        public DateTime fechaInicioSesion { get; set; }
        public TimeSpan duracionSesion { get; set; }

        public Registro registro;
        DispatcherTimer timer;


        public ControlDeRegistros(Modelo.Usuario usu, Computadora comp)
        {
            fechaInicioSesion = DateTime.Now;
            CrearRegistro(usu, comp);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void CrearRegistro(Modelo.Usuario usu, Computadora comp)
        {
            registro = new Registro(1, usu.UsuarioId, comp.CompId, fechaInicioSesion, new TimeSpan(0), ((int)Registro.Desconecciones.Conectado).ToString());
            RegistroORM registroORM = new RegistroORM();

            registroORM.Insertar(registro);
            try
            {
                registro.RegistroId = registroORM.RegresarIdRegistro(registro);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: No se pudo registrar correctamente al usuario\n{ ex.Message}");
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            duracionSesion += TimeSpan.FromSeconds(1.0);
            //string tiempoDeDuracionSesion = duracionSesion.ToString("HH:mm:ss");

            if ((duracionSesion.Minutes % 5 == 0) && (duracionSesion.Seconds == 0))
            {
                RegistroORM regORM = new RegistroORM();
                regORM.Actualizar(registro);
            }
        }

        public void CerrarSesion()
        {
            registro.TipoDesconexion = ((int)Registro.Desconecciones.DesconexionNormal).ToString();
            registro.DuracionTiempo = registro.DuracionTiempo + duracionSesion;
            try
            {
                RegistroORM regORM = new RegistroORM();
                regORM.Actualizar(registro);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: No se pudo registrar correctamente la desconexion del usuario");
            }

            timer.Stop();
        }
    }
}
