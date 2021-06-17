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
                    "nombre = @Nombre, apepaterno = @ApePaterno" +
                    ",apematerno = @ApeMaterno, nickname = @Nickname" +
                    ", contrasena = @Contrasena, email = @Email" +
                    ",tipo = @Tipo, numcuenta = @NumCuenta" +
                    ",carrera = @Carrera, fechainicio = @FechaInicio" +
                    ",fechanacimiento = @FechaNacimiento)" +
                    "WHERE usuario_id = @Id";

                int result = bd.Execute(sentenciaSQL, new
                {
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
                    obj.FechaNacimiento,
                    obj.Id
                });
                return result > 0;
            }
        }

        public Usuario Detalle(int id)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "SELECT * FROM usuarios WHERE usuario_id = @Id";

                return bd.QueryFirstOrDefault<Usuario>(sentenciaSQL, new { Id = id });
            }
        }

        public bool Eliminar(Usuario obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "DELETE FROM public.usuarios WHERE usuario_id = @Id";
                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.Id
                });
                return result > 0;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            var bd = bdConexion();
            string sentenciaSQL = "SELECT * FROM usuarios";

            return bd.Query<Usuario>(sentenciaSQL);
        }

        public bool Insertar(Usuario obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "INSERT INTO public.usuarios (nombre, apepaterno,apematerno,nickname,contrasena,email,tipo,numcuenta,carrera,fechainicio,fechanacimiento)" +
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
    }
}
