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
                string sentenciaSQL = "UPDATE public.computadoras SET " +
                    "  sala_id = @SalaId" +
                    ", comp_nombre = @Nombre" +
                    ", comp_ip= @Ip" +
                    ", comp_submascara = @Submascara" +
                    ", comp_fecha_adquisicion = @FechaAdqui" +
                    " WHERE comp_id = @CompId";

                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.Nombre,
                    obj.SalaId,
                    obj.Ip,
                    obj.Submascara,
                    obj.FechaAdqui,
                    obj.CompId
                });
                return result > 0;
            }
        }

        public Registro Detalle(int id)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "SELECT " +
                    "  comp_id AS CompId" +
                    ", sala_id AS SalaId" +
                    ", comp_nombre AS Nombre " +
                    ", comp_ip AS Ip " +
                    ", comp_submascara AS Submascara " +
                    ", comp_fecha_adquisicion AS FechaAdqui " +
                    " FROM computadoras WHERE comp_id = @Id";

                return bd.QueryFirstOrDefault<Registro>(sentenciaSQL, new { Id = id });
            }
        }

        public bool Eliminar(Registro obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "DELETE FROM public.computadoras WHERE comp_id = @Id";
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
                    "  comp_id AS CompId" +
                    ", sala_id AS SalaId" +
                    ", comp_nombre AS Nombre " +
                    ", comp_ip AS Ip " +
                    ", comp_submascara AS Submascara " +
                    ", comp_fecha_adquisicion AS FechaAdqui " +
                    " FROM Registros";

            return bd.Query<Registro>(sentenciaSQL);
        }

        public bool Insertar(Registro obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "INSERT INTO public.computadoras " +
                    "  sala_id " +
                    ", comp_nombre  " +
                    ", comp_ip " +
                    ", comp_submascara " +
                    ", comp_fecha_adquisicion " +
                    " VALUES (@SalaId,@Nombre,@Ip,@Submascara,@FechaAdqui)";

                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.SalaId,
                    obj.Nombre,
                    obj.Ip,
                    obj.Submascara,
                    obj.FechaAdqui
                });
                return result > 0;
            }
        }
    }
}
