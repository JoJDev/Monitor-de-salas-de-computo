using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Monitor_de_salas_de_computo.Modelo;

namespace Monitor_de_salas_de_computo.Controladores
{
    class AdministradorControl
    {
        public Modelo.Usuario usu { get; set; }
        public Computadora comp { get; set; }
        //public Sala sala { get; set; }
        public DateTime fechaInicioSesion { get; set; }
        public TimeSpan duracionSesion { get; set; }

        IEnumerable<Registro> _registros;
        IEnumerable<Modelo.Usuario> _usuarios;
        IEnumerable<Computadora> _computadoras;
        IEnumerable<Sala> _salas;
        IEnumerable<Configuraciones> _configuraciones;
        public IEnumerable<Registro> Registros { get => _registros; }
        public IEnumerable<Modelo.Usuario> Usuarios { get => _usuarios; }
        public IEnumerable<Computadora> Computadoras { get => _computadoras;  }
        public IEnumerable<Sala> Salas { get => _salas;}
        public IEnumerable<Configuraciones> Configuraciones { get => _configuraciones;}

        ControlDeRegistros registrador;
       
        public void PrepararVentana(Modelo.Usuario usuario, Computadora computadora, Window own)
        {
            usu = usuario;
            comp = computadora;

            registrador = new ControlDeRegistros(usu, comp);

            _registros = new RegistroORM().GetAll();
            _usuarios = new UsuarioORM().GetAll();
            _computadoras = new ComputadoraORM().GetAll();
            _salas = new SalaORM().GetAll();            
            _configuraciones = new ConfiguracionesORM().GetAll();
        }

        public void ActualizarRegistros()
        {
            _registros = new RegistroORM().GetAll();
            _usuarios = new UsuarioORM().GetAll();
            _configuraciones = new ConfiguracionesORM().GetAll();
            _salas = new SalaORM().GetAll();
            _computadoras = new ComputadoraORM().GetAll();
        }

        public void RegistrarCerrarSesion()
        {
            registrador.CerrarSesion();
        }
    }
}
