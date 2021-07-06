using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor_de_salas_de_computo.Modelo
{
    class RegistroORM : ICRUD<Registro>
    {
        protected NpgsqlConnection bdConexion()
        {
            return new ConexionBD().conectar();
        }
        public bool Actualizar(Registro obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "UPDATE public.registros SET " +
                    " usuario_id = @UsuarioId" +
                    ", comp_id = @CompId" +
                    ", registro_fecha_inicio = @FechaInicio" +
                    ", registro_duracion_tiempo = @DuracionTiempo" +
                    ", registro_tipo_desconexion = @TipoDesconexion" +
                    " WHERE registro_id = @RegistroId";

                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.UsuarioId,
                    obj.CompId,
                    obj.FechaInicio,
                    obj.DuracionTiempo,
                    obj.TipoDesconexion,
                    obj.RegistroId,
                });
                return result > 0;
            }
        }

        public Registro Detalle(int id)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "SELECT " +
                    "  registro_id AS RegistroId" +
                    ", usuario_id AS UsuarioId" +
                    ", comp_id AS CompId" +
                    ", registro_fecha_inicio AS FechaInicio" +
                    ", registro_duracion_tiempo AS DuracionTiempo" +
                    ", registro_tipo_desconexion AS TipoDesconexion" +
                    " FROM public.registros WHERE registro_id = @Id";

                return bd.QueryFirstOrDefault<Registro>(sentenciaSQL, new { Id = id });
            }
        }

        public int RegresarIdRegistro(Registro registro)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "SELECT " +
                    "  registro_id AS RegistroId" +
                    " FROM public.registros WHERE " +
                    " usuario_id = @UsuarioId AND " +
                    " comp_id = @CompId AND " +
                    " registro_fecha_inicio = @FechaInicio";

                var respuesta = bd.QueryFirstOrDefault<int>(sentenciaSQL, new 
                {
                    registro.UsuarioId,
                    registro.CompId,
                    registro.FechaInicio
                });
                
                return respuesta;
            }
        }

        public bool Eliminar(Registro obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "DELETE FROM public.registros WHERE registro_id = @RegistroId";
                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.RegistroId
                });
                return result > 0;
            }
        }

        public IEnumerable<Registro> GetAll()
        {
            var bd = bdConexion();
            string sentenciaSQL = "SELECT " +
                    "  registro_id AS RegistroId" +
                    ", usuario_id AS UsuarioId" +
                    ", comp_id AS CompId" +
                    ", registro_fecha_inicio AS FechaInicio" +
                    ", registro_duracion_tiempo AS DuracionTiempo" +
                    ", registro_tipo_desconexion AS TipoDesconexion" +
                    " FROM public.registros";

            return bd.Query<Registro>(sentenciaSQL);
        }

        public bool Insertar(Registro obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "INSERT INTO public.registros (" +
                    " usuario_id " +
                    ", comp_id " +
                    ", registro_fecha_inicio " +
                    ", registro_duracion_tiempo " +
                    ", registro_tipo_desconexion) " +
                    " VALUES (@UsuarioId,@CompId,@FechaInicio,@DuracionTiempo,@TipoDesconexion)";

                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.UsuarioId,
                    obj.CompId,
                    obj.FechaInicio,
                    obj.DuracionTiempo,
                    obj.TipoDesconexion
                }); ;
                return result > 0;
            }
        }
    }
}
