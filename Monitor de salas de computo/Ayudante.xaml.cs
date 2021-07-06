using Monitor_de_salas_de_computo.Controladores;
using Monitor_de_salas_de_computo.Modelo;
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

namespace Monitor_de_salas_de_computo
{
    /// <summary>
    /// Lógica de interacción para Ayudante.xaml
    /// </summary>
    public partial class Ayudante : Window
    {
        AyudanteControl controlador;

        public Ayudante()
        {
            InitializeComponent();
            controlador = new AyudanteControl();
        }

        public void PrepararVentana(Modelo.Usuario usuario, Computadora computadora, Window own)
        {
            controlador.PrepararVentana(usuario, computadora, this);
            dg_Registros.DataContext = controlador.Registros;
            dg_Usuarios.DataContext = controlador.Usuarios;
            dg_Computadoras.DataContext = controlador.Computadoras;
            dg_Salas.DataContext = controlador.Salas;
        }

        private void ActualizarDatos()
        {
            controlador.ActualizarRegistros();
            dg_Registros.DataContext = controlador.Registros;
            dg_Usuarios.DataContext = controlador.Usuarios;
            dg_Computadoras.DataContext = controlador.Computadoras;
            dg_Salas.DataContext = controlador.Salas;
        }

        private void ButtonCerrar_Click(object sender, RoutedEventArgs e)
        {
            controlador.RegistrarCerrarSesion();

            MainWindow iniSesion = new MainWindow();
            iniSesion.Show();
            this.Close();
        }
        private void ButtonSalir_Click(object sender, RoutedEventArgs e)
        {
            controlador.RegistrarCerrarSesion();
            this.Close();
        }

        private void ButtonActualizar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDatos();
        }

        private void bt_CrearComp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
