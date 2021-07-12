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

using System.IO;

namespace Monitor_de_salas_de_computo
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : Window
    {
        AdministradorControl controlador;
        List<CeldaControl> celdas;
        bool editando = false;

        public Administrador()
        {
            InitializeComponent();
            controlador = new AdministradorControl();
            celdas = new List<CeldaControl>();
        }

        public void PrepararVentana(Modelo.Usuario usuario, Computadora computadora, Window own)
        {
            controlador.PrepararVentana(usuario, computadora, this);

            dg_Registros.DataContext = controlador.Registros;
            dg_Usuarios.DataContext = controlador.Usuarios;
            dg_Computadoras.DataContext = controlador.Computadoras;
            dg_Salas.DataContext = controlador.Salas;
            lab_administrador.Content = $"Sesion: {usuario.Nombre} " +
                $"{usuario.ApePaterno.Substring(0, 1) + usuario.ApeMaterno.Substring(0, 1)}   &gt;Administrador";
        }

        private void ActualizarDatos()
        {
            controlador.ActualizarRegistros();
            dg_Registros.DataContext = controlador.Registros;
            dg_Usuarios.DataContext = controlador.Usuarios;
            dg_Computadoras.DataContext = controlador.Computadoras;
            dg_Salas.DataContext = controlador.Salas;

            celdas.Clear();
            bt_aplicarCambiosReg.IsEnabled = false;
        }


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


        /*----------------------------- Seccion de: PC´s activas -----------------------------*/

        /*----------------------------- Fin de seccion de: PC´s activas -----------------------------*/


        /*----------------------------- Seccion de: Registros -----------------------------*/
        private void dg_Registros_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int numFila = e.Row.GetIndex();
            CeldaControl celdaAuxiliar;
            editando = false;

            if (!e.Row.IsNewItem)
            {
                celdaAuxiliar = new CeldaControl(controlador.Registros.ElementAt<Registro>(numFila), "edi-r", numFila);

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
                    //((DataGrid)sender).SelectedCells. Background = Brushes.Yellow;
                    bt_aplicarCambiosReg.IsEnabled = true;

                }
            }
        }

        private void dg_Registros_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Subtract || e.Key == Key.Delete) && !editando)
            {

                int numFila = dg_Registros.SelectedIndex;
                CeldaControl celdaAuxiliar = new CeldaControl(controlador.Registros.ElementAt<Registro>(numFila), "eli-r", numFila);
                // TO DO: optimizar con una instruccion de predicados
                bool edicionDuplicada = false;
                foreach (CeldaControl celda in celdas)
                {
                    if (celda.IdElemento.Equals(celdaAuxiliar.IdElemento) && celda.Operacion.Equals(celdaAuxiliar.Operacion))
                        edicionDuplicada = true;
                }

                if (!edicionDuplicada)
                {
                    celdas.Add(celdaAuxiliar);
                    //((DataGrid)sender).sel .Background = Brushes.Red;
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
                    case "edi-r":
                        operaciones.Actualizar(controlador.Registros.ElementAt<Registro>(celda.IdElemento));
                        break;

                    case "eli-r":
                        operaciones.Eliminar(controlador.Registros.ElementAt<Registro>(celda.IdElemento));
                        break;

                    case "cre-r":
                        operaciones.Insertar((Registro)celda.DatoOriginal);
                        break;

                    default:
                        break;
                }
            }
            ActualizarDatos();
            celdas.Clear();
            bt_aplicarCambiosReg.IsEnabled = false;
        }

        private void dg_Registros_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            int numFila = e.Row.GetIndex();
            CeldaControl celdaAuxiliar;
            editando = false;

            if (e.Row.IsNewItem)
            {
                //Registro nuevoReg = new Registro(-1, e.Row.Item);
                celdaAuxiliar = new CeldaControl((Registro)e.Row.Item, "cre-r", numFila);
                e.Row.Background = Brushes.Green;
            }
        }
        /*----------------------------- Fin de seccion de: Registros -----------------------------*/


        /*----------------------------- Seccion de: Usuarios -----------------------------*/
        private void dg_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            editando = true;
        }

        private void dg_Usuarios_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int numFila = e.Row.GetIndex();
            CeldaControl celdaAuxiliar;
            editando = false;

            if (!e.Row.IsNewItem)
            {
                celdaAuxiliar = new CeldaControl(controlador.Usuarios.ElementAt<Modelo.Usuario>(numFila), "edi-u", numFila);

                // TO DO: optimizar con una instruccion de predicados
                bool edicionDuplicada = false;
                foreach (CeldaControl celda in celdas)
                {
                    if (celda.IdElemento.Equals(celdaAuxiliar.IdElemento) && celda.Operacion.Equals(celdaAuxiliar.Operacion))
                        edicionDuplicada = true;
                }

                if (!edicionDuplicada)
                {
                    celdas.Add(celdaAuxiliar);
                    //((DataGrid)sender).SelectedCells. Background = Brushes.Yellow;
                    bt_AplicarCambiosUsu.IsEnabled = true;
                }
            }
        }

        private void dg_Usuarios_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Subtract || e.Key == Key.Delete) && !editando)
            {
                int numFila = dg_Usuarios.SelectedIndex;
                CeldaControl celdaAuxiliar = new CeldaControl(controlador.Usuarios.ElementAt<Modelo.Usuario>(numFila), "eli-u", numFila);
                // TO DO: optimizar con una instruccion de predicados
                bool edicionDuplicada = false;
                foreach (CeldaControl celda in celdas)
                {
                    if (celda.IdElemento.Equals(celdaAuxiliar.IdElemento) && celda.Operacion.Equals(celdaAuxiliar.Operacion))
                        edicionDuplicada = true;
                }

                if (!edicionDuplicada)
                {
                    celdas.Add(celdaAuxiliar);
                    //((DataGrid)sender).sel .Background = Brushes.Red;
                    bt_AplicarCambiosUsu.IsEnabled = true;

                }
            }
        }

        private void dg_Usuarios_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            int numFila = e.Row.GetIndex();
            CeldaControl celdaAuxiliar;
            editando = false;

            if (e.Row.IsNewItem)
            {
                //Registro nuevoReg = new Registro(-1, e.Row.Item);
                celdaAuxiliar = new CeldaControl((Modelo.Usuario)e.Row.Item, "cre-u", numFila);
                e.Row.Background = Brushes.Green;
                bt_AplicarCambiosUsu.IsEnabled = true;
            }
        }

        private void bt_AplicarCambiosUsu_Click(object sender, RoutedEventArgs e)
        {
            foreach (CeldaControl celda in celdas)
            {
                UsuarioORM operaciones = new UsuarioORM();
                switch (celda.Operacion)
                {
                    case "edi-u":
                        operaciones.Actualizar(controlador.Usuarios.ElementAt<Modelo.Usuario>(celda.IdElemento));
                        break;

                    case "eli-u":
                        operaciones.Eliminar(controlador.Usuarios.ElementAt<Modelo.Usuario>(celda.IdElemento));
                        break;

                    case "cre-u":
                        operaciones.Insertar((Modelo.Usuario)celda.DatoOriginal);
                        break;
                    
                    default:
                        break;
                }
            }
            ActualizarDatos();
            celdas.Clear();
            bt_AplicarCambiosUsu.IsEnabled = false;
        }
        /*----------------------------- Fin de seccion de: Usuarios -----------------------------*/


        /*----------------------------- Seccion de: Computadoras -----------------------------*/
        private void dg_Computadoras_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int numFila = e.Row.GetIndex();
            CeldaControl celdaAuxiliar;
            editando = false;

            if (!e.Row.IsNewItem)
            {
                celdaAuxiliar = new CeldaControl(controlador.Computadoras.ElementAt<Computadora>(numFila), "edi-c", numFila);

                // TO DO: optimizar con una instruccion de predicados
                bool edicionDuplicada = false;
                foreach (CeldaControl celda in celdas)
                {
                    if (celda.IdElemento.Equals(celdaAuxiliar.IdElemento) && celda.Operacion.Equals(celdaAuxiliar.Operacion))
                        edicionDuplicada = true;
                }

                if (!edicionDuplicada)
                {
                    celdas.Add(celdaAuxiliar);
                    //((DataGrid)sender).SelectedCells. Background = Brushes.Yellow;
                    bt_AplicarCambiosComp.IsEnabled = true;

                }
            }
        }

        private void dg_Computadoras_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Subtract || e.Key == Key.Delete) && !editando)
            {
                int numFila = dg_Computadoras.SelectedIndex;
                CeldaControl celdaAuxiliar = new CeldaControl(controlador.Computadoras.ElementAt<Computadora>(numFila), "eli-c", numFila);
                // TO DO: optimizar con una instruccion de predicados
                bool edicionDuplicada = false;
                foreach (CeldaControl celda in celdas)
                {
                    if (celda.IdElemento.Equals(celdaAuxiliar.IdElemento) && celda.Operacion.Equals(celdaAuxiliar.Operacion))
                        edicionDuplicada = true;
                }

                if (!edicionDuplicada)
                {
                    celdas.Add(celdaAuxiliar);
                    //((DataGrid)sender).sel .Background = Brushes.Red;
                    bt_AplicarCambiosComp.IsEnabled = true;

                }
            }
        }

        private void dg_Computadoras_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            int numFila = e.Row.GetIndex();
            CeldaControl celdaAuxiliar;
            editando = false;

            if (e.Row.IsNewItem)
            {
                //Registro nuevoReg = new Registro(-1, e.Row.Item);
                celdaAuxiliar = new CeldaControl((Computadora)e.Row.Item, "cre-c", numFila);
                e.Row.Background = Brushes.Green;
                bt_AplicarCambiosComp.IsEnabled = true;
            }
        }
        private void bt_AplicarCambiosComp_Click(object sender, RoutedEventArgs e)
        {
            foreach (CeldaControl celda in celdas)
            {
                ComputadoraORM operaciones = new ComputadoraORM();
                switch (celda.Operacion)
                {
                    case "edi-c":
                        operaciones.Actualizar(controlador.Computadoras.ElementAt<Computadora>(celda.IdElemento));
                        break;

                    case "eli-c":
                        operaciones.Eliminar(controlador.Computadoras.ElementAt<Computadora>(celda.IdElemento));
                        break;

                    case "cre-c":
                        operaciones.Insertar((Computadora)celda.DatoOriginal);
                        break;

                    default:
                        break;
                }
            }
            ActualizarDatos();
            celdas.Clear();
            bt_AplicarCambiosComp.IsEnabled = false;
        }
        /*----------------------------- Fin de seccion de: Computadoras -----------------------------*/

        /*----------------------------- Seccion de: Salas -----------------------------*/
        private void dg_Salas_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int numFila = e.Row.GetIndex();
            CeldaControl celdaAuxiliar;
            editando = false;

            if (!e.Row.IsNewItem)
            {
                celdaAuxiliar = new CeldaControl(controlador.Salas.ElementAt<Sala>(numFila), "edi-s", numFila);

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
                    //((DataGrid)sender).SelectedCells. Background = Brushes.Yellow;
                    bt_AplicarCambiosSal.IsEnabled = true;

                }
            }
        }

        private void dg_Salas_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Subtract || e.Key == Key.Delete) && !editando)
            {
                int numFila = dg_Salas.SelectedIndex;
                CeldaControl celdaAuxiliar = new CeldaControl(controlador.Salas.ElementAt<Sala>(numFila), "eli-s", numFila);
                // TO DO: optimizar con una instruccion de predicados
                bool edicionDuplicada = false;
                foreach (CeldaControl celda in celdas)
                {
                    if (celda.IdElemento.Equals(celdaAuxiliar.IdElemento) && celda.Operacion.Equals(celdaAuxiliar.Operacion))
                        edicionDuplicada = true;
                }

                if (!edicionDuplicada)
                {
                    celdas.Add(celdaAuxiliar);
                    //((DataGrid)sender).sel .Background = Brushes.Red;
                    bt_AplicarCambiosSal.IsEnabled = true;
                }
            }
        }

        private void dg_Salas_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            int numFila = e.Row.GetIndex();
            CeldaControl celdaAuxiliar;
            editando = false;

            if (e.Row.IsNewItem)
            {
                //Registro nuevoReg = new Registro(-1, e.Row.Item);
                celdaAuxiliar = new CeldaControl((Sala)e.Row.Item, "cre-s", numFila);
                e.Row.Background = Brushes.Green;
                bt_AplicarCambiosSal.IsEnabled = true;
            }
        }

        private void bt_AplicarCambiosSal_Click(object sender, RoutedEventArgs e)
        {
            foreach (CeldaControl celda in celdas)
            {
                SalaORM operaciones = new SalaORM();
                switch (celda.Operacion)
                {
                    case "edi-s":
                        operaciones.Actualizar(controlador.Salas.ElementAt<Sala>(celda.IdElemento));
                        break;

                    case "eli-s":
                        operaciones.Eliminar(controlador.Salas.ElementAt<Sala>(celda.IdElemento));
                        break;

                    case "cre-s":
                        operaciones.Insertar((Sala)celda.DatoOriginal);
                        break;

                    default:
                        break;
                }
            }
            ActualizarDatos();
            celdas.Clear();
            bt_AplicarCambiosSal.IsEnabled = false;

        }

        private void bt_UrlImpUsu_Click(object sender, RoutedEventArgs e)
        {
            openF
        }
        /*----------------------------- Fin de seccion de: Salas -----------------------------*/

        /*----------------------------- Seccion de: Exportar/Importar -----------------------------*/

        /*----------------------------- Fin de seccion de: Exportar/Importar -----------------------------*/

        /*----------------------------- Seccion de: Configuraciones -----------------------------*/

        /*----------------------------- Fin de seccion de: Configuraciones -----------------------------*/

    }
}
