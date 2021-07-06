using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using Monitor_de_salas_de_computo.Modelo;
using System.Windows;

namespace Monitor_de_salas_de_computo.Controladores
{
    class InicioSesionControl
    {
        public static void AccederSesion(string usu, string pass, Window own)
        {
            Modelo.Usuario usuario;
            Computadora computadora;

            usuario = ObtenerUsuario(usu, pass);
            
            computadora = VerificarComputadora();

            if (computadora == null)
            {
                // TO DO: crear un registro general de operaciones
                MessageBox.Show(own,"Error al encontrar los datos de la compu");
            }
            
            // seccion para acceder a la ventana correspondiente
            if (usuario != null)
            {
                switch (usuario.Tipo)
                {
                    case "0":
                        Administrador windowAdm = new Administrador();
                        windowAdm.PrepararVentana(usuario, computadora, own);

                        windowAdm.Show();
                        own.Close();
                        break;

                    case "1":
                        Ayudante windowAyudante = new Ayudante();
                        windowAyudante.PrepararVentana(usuario, computadora, own);

                        windowAyudante.Show();
                        own.Close();
                        break;

                    case "2":
                        Usuario windowUsuario = new Usuario();
                        windowUsuario.PrepararVentana(usuario, computadora, own);

                        windowUsuario.Show();
                        own.Close();
                        break;

                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("usuario o contraseña incorrectos");
            }
        }
        private static Modelo.Usuario ObtenerUsuario(string usu, string pass)
        {
            try
            {
                UsuarioORM usuORM = new UsuarioORM();
                Modelo.Usuario obtUsuario = usuORM.Buscar(usu,pass);
                if (obtUsuario == null)
                {
                    
                }
                return obtUsuario;
            }
            catch (Exception ex)
            {
                throw ex ;
                
            }
        }

        // TO DO: optimizar la verificacion de la compu
        private static Computadora VerificarComputadora()
        {
            string strHostName = string.Empty;
            // Getting Ip address of local machine…
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            // Then using host name, get the IP address list..
            IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);

            ComputadoraORM compORM = new ComputadoraORM();
            IEnumerable<Computadora> compus = compORM.GetAll();
            for (int i = 0; i < hostIPs.Length; i++)
            {
                foreach(Computadora comp in compus)
                {
                    if (comp.Ip.Equals(hostIPs[i].ToString())
                        && comp.Nombre.Equals(strHostName))
                    {
                        return comp;
                    }
                }
                 
            }
            return null;
        }
    }
    
}
