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
                MessageBox.Show(own,"Error al encontrar los datos de la compu");
            }
            
            switch (usuario.Tipo)
            {
                case "0":
                    Administrador windowAdm = new Administrador();

                    AdministradorControl.PrepararVentana(usuario,own);
                    windowAdm.Show();
                    
                    own.Close();
                    break;
                
                case "1":
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
        /*Computadora ObtenerComputadoras(string ip, string nombreHost)
        {
            try
            {
                ComputadoraORM compORM = new ComputadoraORM();
                Computadora obtCompu = compORM.Buscar(ip, nombreHost);
                if (obtCompu == null)
                {
                    throw Exception;
                }
                return obtCompu;
            }
            catch (Exception)
            {
                throw Exception;

            }
        }*/

        private static Computadora VerificarComputadora()
        {
            string strIp = "";
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
