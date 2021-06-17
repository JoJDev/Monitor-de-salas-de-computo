using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monitor_de_salas_de_computo.Modelo
{
    public class Usuario
    {

        public enum Tipos
        {
            Administrador,
            Ayudante,
            Ususario
        }



        public Usuario(int id, string nombre, string apePaterno, string apeMaterno, string nickname, string contrasena, string numCuenta, string email, string tipo, string carrera, DateTime fechaInicio, DateTime fechaNacimiento)
        {
            Id = id;
            Nombre = nombre;
            ApePaterno = apePaterno;
            ApeMaterno = apeMaterno;
            Nickname = nickname;
            Contrasena = contrasena;
            NumCuenta = numCuenta;
            Email = email;
            Tipo = tipo;
            Carrera = carrera;
            FechaInicio = fechaInicio;
            FechaNacimiento = fechaNacimiento;
        }

        public Usuario()
        {
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Nickname { get; set; }
        public string Contrasena { get; set; }
        public string NumCuenta { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }
        public string Carrera { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaNacimiento { get; set; }


        /* public DataTable GetTablaUsuario(int id = 0)
         {
             ConexionBD conn = new ConexionBD(w);
             string query = "SELECT * FROM \"usuarios\"";
             try
             {
                 NpgsqlCommand conector = new NpgsqlCommand(query, conn.conectar());
                 NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
                 DataTable table = new DataTable("tabla");
                 datos.Fill(table);
                 return table;
             }catch(Exception ex)
             {
                 MessageBox.Show("Error al rellenar la tabla con los datos\n" + ex.Message);
                 return null;

             }
             return null;
             //Id = from celda in table.AsEnumerable() select * ;

         }*/
    }
}
