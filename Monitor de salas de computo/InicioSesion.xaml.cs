using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monitor_de_salas_de_computo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string usu = txt_usu.Text;
            string pass = txt_psw.Password.ToString();

            try
            {
                Controlador.InicioSesionControl.AccederSesion(usu, pass, this);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Usuario o contraseña incorrecta\n{ex.Message}", " Error de ");
            }

            /*
            switch (usu)
            {
                case "admin":
                    if (pass.Equals("admin"))
                    {
                        Administrador windowAdm = new Administrador();
                        windowAdm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecta", " Error de ");
                    }
                    break;

                case "ayudante":
                    if (pass.Equals("ayudante"))
                    {
                        Ayudante windowAyu = new Ayudante();
                        windowAyu.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecta", " Error de ");
                    }
                    break;

                case "usuario":
                    if (pass.Equals("usuario"))
                    {
                        Usuario windowUsu = new Usuario();
                        windowUsu.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecta", " Error de ");
                    }
                    break;

                default:
                    MessageBox.Show("Usuario o contraseña incorrecta", " Error de ");
                    break;
            }*/
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
