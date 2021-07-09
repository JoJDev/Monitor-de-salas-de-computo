﻿using System;
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
                celdaAuxiliar = new CeldaControl(controlador.Registros.ElementAt<Registro>(numFila), "edi", numFila);

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
                MessageBox.Show("" + sender.GetType() + "\n" + sender.ToString());
                int numFila = dg_Registros.SelectedIndex;
                CeldaControl celdaAuxiliar = new CeldaControl(controlador.Registros.ElementAt<Registro>(numFila), "eli", numFila);
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
                    case "edi":
                        operaciones.Actualizar(controlador.Registros.ElementAt<Registro>(celda.IdElemento));
                        break;

                    case "eli":
                        operaciones.Eliminar(controlador.Registros.ElementAt<Registro>(celda.IdElemento));
                        break;

                    case "cre":
                        operaciones.Insertar((Registro)celda.DatoOriginal);
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
            MessageBox.Show("El item  es:" + e.Row.Item + "");
            editando = false;

            if (e.Row.IsNewItem)
            {
                //Registro nuevoReg = new Registro(-1, e.Row.Item);
                celdaAuxiliar = new CeldaControl((Registro)e.Row.Item, "cre", numFila);
                MessageBox.Show("El item  es:" + e.Row.Item.ToString() + "\n" + ((Registro)e.Row.Item).RegistroId);
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
                celdaAuxiliar = new CeldaControl(controlador.Usuarios.ElementAt(numFila), "edi", numFila);

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

        private void dg_Usuarios_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dg_Usuarios_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

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
                celdaAuxiliar = new CeldaControl(controlador.Computadoras.ElementAt<Computadora>(numFila), "edi", numFila);

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

        private void dg_Computadoras_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dg_Computadoras_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }
        /*----------------------------- Fin de seccion de: Computadoras -----------------------------*/

        /*----------------------------- Seccion de: Salas -----------------------------*/
        private void dg_Salas_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void dg_Salas_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dg_Salas_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }
        /*----------------------------- Fin de seccion de: Salas -----------------------------*/

        /*----------------------------- Seccion de: Exportar/Importar -----------------------------*/

        /*----------------------------- Fin de seccion de: Exportar/Importar -----------------------------*/

        /*----------------------------- Seccion de: Configuraciones -----------------------------*/

        /*----------------------------- Fin de seccion de: Configuraciones -----------------------------*/


    }
}
