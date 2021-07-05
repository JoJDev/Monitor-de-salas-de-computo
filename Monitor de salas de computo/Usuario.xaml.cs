using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Monitor_de_salas_de_computo.Controladores;
using Monitor_de_salas_de_computo.Modelo;

namespace Monitor_de_salas_de_computo
{
    /// <summary>
    /// Lógica de interacción para Usuario.xaml
    /// </summary>
    public partial class Usuario : Window
    {
        UsuarioControl controlador;
        public Usuario()
        {
            InitializeComponent();
            controlador = new UsuarioControl();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void PrepararVentana(Modelo.Usuario usu, Computadora comp, Window own)
        {
            controlador.PrepararVentana(usu, comp, own);
            lab_usuario.Content = "Usuario: " + controlador.usu.Nombre + " "
                + controlador.usu.ApePaterno.Substring(0, 1)
                + controlador.usu.ApeMaterno.Substring(0, 1);
            lab_plantel.Content = "Plantel: " + controlador.sala.Nombre;
            lab_carrera.Content = "Carrera: " + controlador.usu.Carrera;
            lab_Semstre.Content = "Semestre: " + controlador.usu.FechaInicio.Date;

            lab_nombrePC.Content = controlador.comp.Nombre;
            lab_ip.Content = controlador.comp.Ip;
            lab_submascara.Content = controlador.comp.Submascara;
            lab_gateway.Content = "TODO: corregir este campo inexistente (crearlo)";

            lab_fechaInicioSesion.Content = controlador.fechaInicioSesion;
            lab_duracionSesion.Content = controlador.duracionSesion;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            controlador.duracionSesion += TimeSpan.FromSeconds(1.0);
            lab_duracionSesion.Content = controlador.duracionSesion;
        }

        private void ButtonSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonCerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow iniSesion = new MainWindow();
            iniSesion.Show();
            Close();
        }


    }
}
