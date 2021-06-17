using System.Text;
using System.Linq;
using System.Windows;
using System.Data;
using System.ComponentModel.DataAnnotations;
using Npgsql;

namespace Monitor_de_salas_de_computo.Modelo
{
    class ConexionBD
    {
        protected string Server { get; set; }
        protected string UserId { get; set; }
        protected string Password { get; set; }
        protected string Database { get; set; }
        public NpgsqlConnection Conn { get; set; }


        public ConexionBD()
        {
            Server = "localhost";
            UserId = "postgres";
            Password = "localhost";
            Database = "monitor_salas_computo";

        }
        public ConexionBD(string server, string userId, string password, string database)
        {
            Server = server;
            UserId = userId;
            Password = password;
            Database = database;
        }

        public NpgsqlConnection conectar()
        {
            try
            {
                string connectionString = "Server = " + Server
                + "; User id = " + UserId
                + "; Password = " + Password
                + "; Database =" + Database;
                Conn = new NpgsqlConnection(connectionString);
            }
            catch (NpgsqlException Ex)
            {
                throw Ex;
            }
            return Conn;
        }
    }
}
