using Dapper;
using Npgsql;
using Monitor_de_salas_de_computo.Modelo;
using System;
using System.Collections.Generic;

namespace Monitor_de_salas_de_computo.Modelo
{
    public class UsuarioORM : ICRUD<Usuario>
    {

        protected NpgsqlConnection bdConexion()
        {
            return new ConexionBD().conectar();
        }
        public bool Actualizar(Usuario obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "UPDATE public.usuarios SET " +
                    "usuario_nombre = @Nombre, usuario_ape_paterno = @ApePaterno" +
                    ",usuario_ape_materno = @ApeMaterno, usuario_nickname = @Nickname" +
                    ", usuario_contrasena = @Contrasena, usuario_email = @Email" +
                    ",usuario_tipo = @Tipo, usuario_numero_cuenta = @NumCuenta" +
                    ",usuario_carrera = @Carrera, usuario_fecha_inicio = @FechaInicio" +
                    ",usuario_fecha_nacimiento = @FechaNacimiento)" +
                    "WHERE usuario_id = @UsuarioId";

                
                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.UsuarioId,
                    obj.Nombre,
                    obj.ApePaterno,
                    obj.ApeMaterno,
                    obj.Nickname,
                    obj.Contrasena,
                    obj.NumCuenta,
                    obj.Email,
                    obj.Tipo,
                    obj.Carrera,
                    obj.FechaInicio,
                    obj.FechaNacimiento
                });
                return result > 0;
            }
        }

        public Usuario Detalle(int id)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "SELECT " +
                    "  usuario_id AS UsuarioId" +
                    ", usuario_nombre AS Nombre" +
                    ", usuario_ape_paterno AS ApePaterno" +
                    ", usuario_ape_materno AS ApeMaterno" +
                    ", usuario_nickname AS Nickname" +
                    ", usuario_contrasena As Contrasena" +
                    ", usuario_email AS Email" +
                    ", usuario_tipo AS Tipo" +
                    ", usuario_numero_cuenta AS NumCuenta" +
                    ", usuario_carrera AS Carrera" +
                    ", usuario_fecha_inicio AS FechaInicio" +
                    ", usuario_fecha_nacimiento AS FechaNacimiento" +
                    " FROM public.usuarios WHERE usuario_id = @UsuarioId";

                return bd.QueryFirstOrDefault<Usuario>(sentenciaSQL, new { UsuarioId = id });
            }
        }

        public bool Eliminar(Usuario obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "DELETE FROM public.usuarios WHERE usuario_id = @UsuarioId";
                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.UsuarioId
                });
                return result > 0;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            var bd = bdConexion();
            string sentenciaSQL = "SELECT " +
                    "  usuario_id AS UsuarioId" +
                    ", usuario_nombre AS Nombre" +
                    ", usuario_ape_paterno AS ApePaterno" +
                    ", usuario_ape_materno AS ApeMaterno" +
                    ", usuario_nickname AS Nickname" +
                    ", usuario_contrasena As Contrasena" +
                    ", usuario_email AS Email" +
                    ", usuario_tipo AS Tipo" +
                    ", usuario_numero_cuenta AS NumCuenta" +
                    ", usuario_carrera AS Carrera" +
                    ", usuario_fecha_inicio AS FechaInicio" +
                    ", usuario_fecha_nacimiento AS FechaNacimiento" +
                    " FROM public.usuarios";

            return bd.Query<Usuario>(sentenciaSQL);
        }

        public bool Insertar(Usuario obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "INSERT INTO public.usuarios " +
                    "( usuario_nombre" +
                    ", usuario_ape_paterno" +
                    ", usuario_ape_materno" +
                    ", usuario_nickname" +
                    ", usuario_contrasena" +
                    ", usuario_email" +
                    ", usuario_tipo" +
                    ", usuario_numero_cuenta" +
                    ", usuario_carrera" +
                    ", usuario_fecha_inicio" +
                    ", usuario_fecha_nacimiento)" +
                    " VALUES (@Nombre,@ApePaterno,@ApeMaterno,@Nickname,@Contrasena,@Email,@Tipo,@NumCuenta,@Carrera,@FechaInicio,@FechaNacimiento)";

                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.Nombre,
                    obj.ApePaterno,
                    obj.ApeMaterno,
                    obj.Nickname,
                    obj.Contrasena,
                    obj.Email,
                    obj.Tipo,
                    obj.NumCuenta,
                    obj.Carrera,
                    obj.FechaInicio,
                    obj.FechaNacimiento
                });
                return result > 0;
            }
        }

        public Usuario Buscar(string usu, string pass)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "SELECT " +
                    "  usuario_id AS UsuarioId" +
                    ", usuario_nombre AS Nombre" +
                    ", usuario_ape_paterno AS ApePaterno" +
                    ", usuario_ape_materno AS ApeMaterno" +
                    ", usuario_nickname AS Nickname" +
                    ", usuario_contrasena As Contrasena" +
                    ", usuario_email AS Email" +
                    ", usuario_tipo AS Tipo" +
                    ", usuario_numero_cuenta AS NumCuenta" +
                    ", usuario_carrera AS Carrera" +
                    ", usuario_fecha_inicio AS FechaInicio" +
                    ", usuario_fecha_nacimiento AS FechaNacimiento" +
                    " FROM public.usuarios " +
                    "WHERE usuario_nickname = @Nickname " +
                    " AND usuario_contrasena = @Contrasena";

                return bd.QueryFirstOrDefault<Usuario>(sentenciaSQL, new { @Nickname = usu, @Contrasena = pass });
            }
        }
    }
}
