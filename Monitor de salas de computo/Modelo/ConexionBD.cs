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
        private int _id, _tipo;
        private string _nombre, _apePaterno, _apeMaterno, _nickname, _contrasena, _email, _numCuenta;
        private DateTime _fechaInicio, _fechaNacim;

        enum Tipo
        {
            Administrador,
            Ayudante,
            Ususario
        }

        public Usuario(int id, string nombre, string apePaterno, string apeMaterno, string nickname, string contrasena, string email, string tipo, string numCuenta, DateTime fechaInicio, DateTime fechaNacim)
        {
            _id = id;
            switch (tipo.ToLower())
            {
                case "admin":
                case "administrador":
                case "0":
                    _tipo = (int)Tipo.Administrador;
                    break;
                case "ayu":
                case "ayudante":
                case "1":
                    _tipo = (int)Tipo.Ayudante;
                    break;
                default:
                    _tipo = (int)Tipo.Ususario;
                    break;
            }
            _nombre = nombre;
            _apePaterno = apePaterno;
            _apeMaterno = apeMaterno;
            _nickname = nickname;
            _contrasena = contrasena;
            _email = email;
            _numCuenta = numCuenta;
            _fechaInicio = fechaInicio;
            _fechaNacim = fechaNacim;
        }


    }

    class Computadora
    {
        //id, idSala, nombre, ip, submascara, fechaAdqui
        private int _id, _idSala;
        private string _nombre, _ip, _submascar;
        private DateTime _fechaAdqui;

        public Computadora(int id, int idSala, string nombre, string ip, string submascar, DateTime fechaAdqui)
        {
            _id = id;
            _idSala = idSala;
            _nombre = nombre;
            _ip = ip;
            _submascar = submascar;
            _fechaAdqui = fechaAdqui;
        }
    }

    class Sala
    {
        // id, nombre, plantel, ipInicial, ipFinal, gateway, servidor, encargado, telefono
        private int _id;
        private string _nombre, _plantel, _ipInicial, _ipFinal, _gateway, _servidor, _encargado, _telefono;

        public Sala(int id, string nombre, string plantel, string ipInicial, string ipFinal, string gateway, string servidor, string encargado, string telefono)
        {
            _id = id;
            _nombre = nombre;
            _plantel = plantel;
            _ipInicial = ipInicial;
            _ipFinal = ipFinal;
            _gateway = gateway;
            _servidor = servidor;
            _encargado = encargado;
            _telefono = telefono;
        }
    }

    class Registro
    {
        //id, idUsuario, idCompu, fechaIncio, duracionTiempo, tipoDesconexion, 
        private int _id, _idUsuario, _idCompu;
        private DateTime _fechaIncio, _duracionTiempo;
        private string _tipoDesconexion;

        enum desconecciones
        {

        }
        public Registro(int id, int idUsuario, int idCompu, DateTime fechaIncio, DateTime duracionTiempo, string tipoDesconexion)
        {
            _id = id;
            _idUsuario = idUsuario;
            _idCompu = idCompu;
            _fechaIncio = fechaIncio;
            _duracionTiempo = duracionTiempo;
            _tipoDesconexion = tipoDesconexion;
        }
    }

    class Configuraciones
    {
        //id, idSala, tiempoEnEspera, permitirUSB
    }
}
