using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Monitor_de_salas_de_computo.Modelo;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace Monitor_de_salas_de_computo
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : Window
    {
        public Administrador()
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

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
          //  Modelo.Usuario usu = new Modelo.Usuario(this);
           // dg_PCsActivas.ItemsSource = usu.GetTablaUsuario().DefaultView;
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
           /* DataTable data = new DataTable();
            using (var dbUsu = new ConexionBD(this))
            {
                var usuarios = dbUsu.Usuarios.ToList();
                data.Load(usuarios);
            }
            dg_Usuarios.SelectedItem = data.DefaultView;
                //data = Usuario.*/
        }

        private void bt_CrearComp_Click(object sender, RoutedEventArgs e)
        {
            using (var dbUsu = new ConexionBD(this))
            {
                MessageBox.Show("Prueba: " + dbUsu.Usuarios.ToList().FirstOrDefault().usuario_nombre);
            }
            
        }
    }
}
