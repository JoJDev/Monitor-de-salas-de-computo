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
using Monitor_de_salas_de_computo.Controladores;

namespace Monitor_de_salas_de_computo
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : Window
    {
        /*IEnumerable<Registro> _registros;
        IEnumerable<Modelo.Usuario> _usuarios;
        IEnumerable<Computadora> _computadoras;
        IEnumerable<Sala> _salas;
        IEnumerable<Configuraciones> _configuraciones;*/
        AdministradorControl controlador;
        List<CeldaControl> celdas;

        public Administrador()
        {
            InitializeComponent();
            controlador = new AdministradorControl();
            celdas = new List<CeldaControl>();
            /*_registros = new RegistroORM().GetAll();
            dg_Registros.DataContext = _registros;
            _usuarios = new UsuarioORM().GetAll();
            dg_Usuarios.DataContext = _usuarios;
            _computadoras = new ComputadoraORM().GetAll();
            dg_Computadoras.DataContext = _computadoras;
            _salas = new SalaORM().GetAll();
            dg_Salas.DataContext = _salas;
            _configuraciones = new ConfiguracionesORM().GetAll();*/

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

        /* bool BuscarUsuario(Object obj)
         {

             switch (tb_BuscarComp.Text)
             {
                 case obj.ToString():
                     break;
                 default:
                     break;

             }
             return false;//if obj.
         }*/

        private void ButtonActualizar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDatos();
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

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            //this.ActualizarRegistros();
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

          // ConexionBD dbUsu = new ConexionBD();
            //MessageBox.Show("Prueba: " + dbUsu.Usuarios.ToList().FirstOrDefault().usuario_nombre);

        }

        private void bt_CrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            UsuarioORM nuevoUsuario = new UsuarioORM();
            nuevoUsuario.Insertar(new Modelo.Usuario(2,"Maria","Mendez", "Martinez", "MarAdmin", "MarAdmin", "1478522","email@gmail.com"
                ,"0","ICO", new DateTime(2016,03,04), new DateTime(2000,10,14)));
            controlador.ActualizarRegistros();
        }

        private void tb_BuscarUsuarios_TextChanged(object sender, TextChangedEventArgs e)
        {
            

            //dg_Usuarios.ItemsSource = dg_Usuarios.Items.Filter(new Predicate<ItemsControl> (usu => usutb_BuscarUsuarios.Text));
            //dg_Usuarios.fil
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var compORM = new ComputadoraORM();
            //compORM.Eliminar(_computadoras[]);

            //dg_Usuarios.ItemsSource = dg_Usuarios.Items.Filter(new Predicate<ItemsControl> (usu => usutb_BuscarUsuarios.Text));
            //dg_Usuarios.fil
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var compORM = new ComputadoraORM();
            //compORM.Eliminar(_computadoras]);

            //dg_Usuarios.ItemsSource = dg_Usuarios.Items.Filter(new Predicate<ItemsControl> (usu => usutb_BuscarUsuarios.Text));
            //dg_Usuarios.fil
        }

        private void dg_Registros_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int NumFila = e.Row.GetIndex();
            // Codigo para obtener el valor de la celda editada a travez del enumerador Registro
            //string valorInicialCelda = controlador.Registros.ElementAt(NumFila).getPropiedadNum(e.Column.DisplayIndex).ToString();

            /*MessageBox.Show($"{e.Row.GetIndex()} es el id de objeto actualizado\n" +
                $" y la celda es : {controlador.Registros.ToArray()[e.Row.GetIndex()]}" +
                $" columna: { e.Column.DisplayIndex} and = {valorCelda}");*/
            CeldaControl celdaAuxiliar = new CeldaControl("", "edi", NumFila);
            // TO DO: optimizar con una instruccion de predicados
            bool edicionDuplicada = false;
            foreach(CeldaControl celda in celdas)
            {
                if (celda.IdElemento.Equals(celdaAuxiliar.IdElemento)
                    && celda.Operacion.Equals(celdaAuxiliar.Operacion))
                    edicionDuplicada = true;
            }

            if (!edicionDuplicada)
            {
                celdas.Add(celdaAuxiliar);
                //e.Row.Background = Brushes.Yellow;
                bt_aplicarCambiosReg.IsEnabled = true;

            }



        }

        private void dg_Usuarios_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            /*var usuORM = new UsuarioORM();
            int fila = e.Row.GetIndex();
            Modelo.Usuario usu = _usuarios.ElementAt(e.Row.GetIndex());
            dg_Usuarios.Items.IndexOf(fila);//Header = e.Column.GetCellContent;
            MessageBox.Show($"{e.Row.GetIndex()} es el id de objeto actualizado\n" +
                $"{_usuarios.ElementAt(e.Row.GetIndex()).UsuarioId} es su id\n" +
                $"{_usuarios.ElementAt(e.Row.GetIndex()).ApeMaterno} es su toString");
            usuORM.Actualizar(_usuarios.ElementAt(e.Row.GetIndex()));
            */

        }

        private void dg_Registros_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Subtract || e.Key == Key.Delete)
            {
                
                int numFila = dg_Registros.SelectedIndex;
                CeldaControl celdaAuxiliar = new CeldaControl("", "eli", numFila);
                // TO DO: optimizar con una instruccion de predicados
                bool edicionDuplicada = false;
                foreach (CeldaControl celda in celdas)
                {
                    if (celda.IdElemento.Equals(celdaAuxiliar.IdElemento)
                        && celda.Operacion.Equals(celdaAuxiliar.Operacion))
                        edicionDuplicada = true;
                }

                if (!edicionDuplicada)
                {
                    celdas.Add(celdaAuxiliar);
                    //  = Brushes.Red;
                    bt_aplicarCambiosReg.IsEnabled = true;
                }
            }
        }

        private void bt_aplicarCambiosReg_Click(object sender, RoutedEventArgs e)
        {
            foreach (CeldaControl celda in celdas)
            {
                RegistroORM operaciones = new RegistroORM();
                switch (celda.Operacion)
                {
                    case "edi":
                        operaciones.Actualizar(controlador.Registros.ElementAt<Registro>(celda.IdElemento));
                        ActualizarDatos();
                        break;

                    case "eli":
                        operaciones.Eliminar(controlador.Registros.ElementAt<Registro>(celda.IdElemento));
                        ActualizarDatos();
                        break;

                    case "cre":
                        /*operaciones.Insertar(new Registro(1, 1, 1, new DateTime(), "Mendez", "Martinez", "MarAdmin", "MarAdmin", "1478522", "email@gmail.com"
                            , "0", "ICO", new DateTime(2016, 03, 04), new DateTime(2000, 10, 14)));
                        controlador.ActualizarRegistros();*/
                        break;
                }
            }

            celdas.Clear();
            bt_aplicarCambiosReg.IsEnabled = false;
        }

        private void dg_Registros_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            int numFila = -1;
            CeldaControl celdaAuxiliar = new CeldaControl("", "cre", numFila);
            // TO DO: optimizar con una instruccion de predicados
            bool edicionDuplicada = false;
            foreach (CeldaControl celda in celdas)
            {
                if (celda.IdElemento.Equals(celdaAuxiliar.IdElemento)
                    && celda.Operacion.Equals(celdaAuxiliar.Operacion))
                    edicionDuplicada = true;
            }

            if (!edicionDuplicada)
            {
                celdas.Add(celdaAuxiliar);
                //  = Brushes.Red;
                bt_aplicarCambiosReg.IsEnabled = true;
            }
        }
    }
}
