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
        public Ayudante()
        {
            InitializeComponent();
        }

        private void ButtonCerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow iniSesion = new MainWindow();
            iniSesion.Show();
            this.Close();
        }
        private void ButtonSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
