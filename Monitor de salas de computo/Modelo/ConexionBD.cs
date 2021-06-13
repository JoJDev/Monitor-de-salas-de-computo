using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Npgsql;
using System.Windows;
using System.Data;

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

        public NpgsqlConnection Conn { get => conn; set => conn = value; }

        public NpgsqlConnection conectar()
        {
            try
            {
                Conn = new NpgsqlConnection("Server = " + server
                    + "; User id = " + userId
                    + "; Password = " + password
                    + "; Database =" + database);
            }
            catch (NpgsqlException Ex)
            {
                MessageBox.Show("Error: Falla con la conexion a la base de datos", "Error con la conexion");
            }
            return Conn;
        }
    }

    class Usuario
    {
        private int _id, _tipo;
        private string _apePaterno, _apeMaterno, _nickname, _contrasena, _email, _numCuenta;
        private DateTime _fechaInicio, _fechaNacim;
        public Window w;

        enum Tipo
        {
            Administrador,
            Ayudante,
            Ususario
        }


        public Usuario(Window ventanaPadre, int id, string nombre, string apePaterno, string apeMaterno, string nickname, string contrasena, string email, string tipo, string numCuenta, DateTime fechaInicio, DateTime fechaNacim)
        {
            w = ventanaPadre;
            Id = id;
            switch (tipo.ToLower())
            {
                case "admin":
                case "administrador":
                case "0":
                    Tipo1 = (int)Tipo.Administrador;
                    break;
                case "ayu":
                case "ayudante":
                case "1":
                    Tipo1 = (int)Tipo.Ayudante;
                    break;
                default:
                    Tipo1 = (int)Tipo.Ususario;
                    break;
            }
            Nombre = nombre;
            ApePaterno = apePaterno;
            ApeMaterno = apeMaterno;
            Nickname = nickname;
            Contrasena = contrasena;
            Email = email;
            NumCuenta = numCuenta;
            FechaInicio = fechaInicio;
            FechaNacim = fechaNacim;
        }

        public Usuario()
        {
        }

        public string Nombre { get; set; }
        public string ApePaterno { get => _apePaterno; set => _apePaterno = value; }
        public string ApeMaterno { get => _apeMaterno; set => _apeMaterno = value; }
        public string Nickname { get => _nickname; set => _nickname = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public string Email { get => _email; set => _email = value; }
        public string NumCuenta { get => _numCuenta; set => _numCuenta = value; }
        public int Id { get => _id; set => _id = value; }
        public int Tipo1 { get => _tipo; set => _tipo = value; }
        public DateTime FechaInicio { get => _fechaInicio; set => _fechaInicio = value; }
        public DateTime FechaNacim { get => _fechaNacim; set => _fechaNacim = value; }

        public Usuario GetUsuario(int id = 0)
        {
            ConexionBD conn = new ConexionBD(w);
            string query = "SELECT * FROM 'usuarios'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn.conectar());
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable table = new DataTable();
            datos.Fill(table);
            //Id = from celda in table.AsEnumerable() select * ;
            return this;
        }
    }

    class Computadora
    {
        //id, idSala, nombre, ip, submascara, fechaAdqui
        private int _id, _idSala;
        private string _nombre, _ip, _submascar;
        private DateTime _fechaAdqui;

        public Computadora()
        {
        }

        public Computadora(int id, int idSala, string nombre, string ip, string submascar, DateTime fechaAdqui)
        {
            Id = id;
            IdSala = idSala;
            Nombre = nombre;
            Ip = ip;
            Submascar = submascar;
            FechaAdqui = fechaAdqui;
        }

        public int Id { get => _id; set => _id = value; }
        public int IdSala { get => _idSala; set => _idSala = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Ip { get => _ip; set => _ip = value; }
        public string Submascar { get => _submascar; set => _submascar = value; }
        public DateTime FechaAdqui { get => _fechaAdqui; set => _fechaAdqui = value; }
    }

    class Sala
    {
        // id, nombre, plantel, ipInicial, ipFinal, gateway, servidor, encargado, telefono
        private int _id;
        private string _nombre, _plantel, _ipInicial, _ipFinal, _gateway, _servidor, _encargado, _telefono;

        public Sala()
        {
        }

        public Sala(int id, string nombre, string plantel, string ipInicial, string ipFinal, string gateway, string servidor, string encargado, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Plantel = plantel;
            IpInicial = ipInicial;
            IpFinal = ipFinal;
            Gateway = gateway;
            Servidor = servidor;
            Encargado = encargado;
            Telefono = telefono;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Plantel { get => _plantel; set => _plantel = value; }
        public string IpInicial { get => _ipInicial; set => _ipInicial = value; }
        public string IpFinal { get => _ipFinal; set => _ipFinal = value; }
        public string Gateway { get => _gateway; set => _gateway = value; }
        public string Servidor { get => _servidor; set => _servidor = value; }
        public string Encargado { get => _encargado; set => _encargado = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
    }

    class Registro
    {
        //id, idUsuario, idCompu, fechaIncio, duracionTiempo, tipoDesconexion, 
        private int _id, _idUsuario, _idCompu, _tipoDesconexion;
        private DateTime _fechaIncio, _duracionTiempo;

        public int Id { get => _id; set => _id = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int IdCompu { get => _idCompu; set => _idCompu = value; }
        public int TipoDesconexion { get => _tipoDesconexion; set => _tipoDesconexion = value; }
        public DateTime FechaIncio { get => _fechaIncio; set => _fechaIncio = value; }
        public DateTime DuracionTiempo { get => _duracionTiempo; set => _duracionTiempo = value; }

        //Tipos de desconexion:
        // conecado = conectado
        // desconexionNormal = desconexion normal
        // desconexionInesperada = desconexion por apagado de maqui repentino
        // desconexionInactivo = desconexion por tiempo en espera escesivo
        // desconexionAdministrada = desconexion por admin (en desarrollo)
        enum desconecciones
        {
            conecado,
            desconexionNormal,
            desconexionInesperada,
            desconexionInactivo,
            desconexionAdministrada
        }

        public Registro(int id, int idUsuario, int idCompu, DateTime fechaIncio, DateTime duracionTiempo, int tipoDesconexion)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdCompu = idCompu;
            FechaIncio = fechaIncio;
            DuracionTiempo = duracionTiempo;
            TipoDesconexion = tipoDesconexion;
        }

        public Registro()
        {
        }
    }

    class Configuraciones
    {
        //id, idSala, tiempoEnEspera, permitirUSB
        private int _id, _idSala;
        private DateTime _tiempoEnEspera;
        private bool _permitirUSB/*en desarrollo*/;

        public Configuraciones()
        {
        }

        public Configuraciones(int id, int idSala, DateTime tiempoEnEspera, bool permitirUSB)
        {
            Id = id;
            IdSala = idSala;
            TiempoEnEspera = tiempoEnEspera;
            PermitirUSB = permitirUSB;
        }

        public int Id { get => _id; set => _id = value; }
        public int IdSala { get => _idSala; set => _idSala = value; }
        public DateTime TiempoEnEspera { get => _tiempoEnEspera; set => _tiempoEnEspera = value; }
        public bool PermitirUSB { get => _permitirUSB; set => _permitirUSB = value; }
    }
}
