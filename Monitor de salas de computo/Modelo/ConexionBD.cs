using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Windows;

namespace Monitor_de_salas_de_computo.Modelo
{
    class ConexionBD
    {
        protected string server, userId, password, database;
        NpgsqlConnection conn;
        Window w;


        public ConexionBD(Window ventanaPadre)
        {
            this.server = "localhost";
            this.userId = "postgres";
            this.password = "localhost";
            this.database = "monitor_salas_computo";
            this.w = ventanaPadre;
        }
        public ConexionBD(Window ventanaPadre, string server, string userId, string password, string database)
        {
            this.server = server;
            this.userId = userId;
            this.password = password;
            this.database = database;
            this.w = ventanaPadre;
        }

        public NpgsqlConnection conectar()
        {
            try
            {
                conn = new NpgsqlConnection("Server = " + server
                    + "; User id = " + userId
                    + "; Password = " + password
                    + "; Database =" + database);
            }
            catch (NpgsqlException Ex)
            {
                MessageBox.Show("Error: Falla con la conexion a la base de datos", "Error con la conexion");
            }
            return conn;
        }
    }

    class Usuario
    {

    }

    class Computadora
    {

    }

    class Sala
    {

    }

    class Registro
    {

    }

    class Configuraciones
    {

    }
}
