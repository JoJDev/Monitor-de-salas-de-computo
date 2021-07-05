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
using Monitor_de_salas_de_computo.Controladores;

namespace Monitor_de_salas_de_computo
{
    /// <summary>
    /// Lógica de interacción para Usuario.xaml
    /// </summary>
    public partial class Usuario : Window
    {
        UsuarioControl controlador = new UsuarioControl();
        public Usuario()
        {
            InitializeComponent();
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

        private void Window_ContentRendered(object sender, EventArgs e)
        {
             controlador
        }
    }
}
