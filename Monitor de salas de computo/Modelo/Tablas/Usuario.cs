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
            UsuarioId = id;
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

        public int UsuarioId { get; set; }
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

        public object getPropiedadNum(int index)
        {
            switch (index)
            {
                case 0:
                    return UsuarioId;

                case 1:
                    return Nombre;

                case 2:
                    return ApePaterno;

                case 3:
                    return ApeMaterno;

                case 4:
                    return Nickname;

                case 5:
                    return Contrasena;

                case 6:
                    return NumCuenta;

                case 7:
                    return Email;

                case 8:
                    return Tipo;

                case 9:
                    return Carrera;

                case 10:
                    return FechaInicio;

                case 11:
                    return FechaNacimiento;

                default:
                    return null;
            }
        }

        public void setPropiedadNum(int index, object valor)
        {
            switch (index)
            {
                case 0:
                    UsuarioId = (int)valor;
                    break;
                case 1:
                    Nombre = (string)valor;
                    break;
                case 2:
                    ApePaterno = (string)valor;
                    break;
                case 3:
                    ApeMaterno = (string)valor;
                    break;
                case 4:
                    Nickname = (string)valor;
                    break;
                case 5:
                    Contrasena = (string)valor;
                    break;
                case 6:
                    NumCuenta = (string)valor;
                    break;
                case 7:
                    Email = (string)valor;
                    break;
                case 8:
                    Tipo = (string)valor;
                    break;
                case 9:
                    Carrera = (string)valor;
                    break;
                case 10:
                    FechaInicio = (DateTime)valor;
                    break;
                case 11:
                    FechaNacimiento = (DateTime)valor;
                    break;
            }
        }

    }
}
