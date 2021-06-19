using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor_de_salas_de_computo.Modelo
{
    class ComputadoraORM
    {
        private const string _tabla = " public.computadoras ";
        private const string _idComp = " comp_id AS CompId ";
        private const string _idSala = " sala_id AS SalaId ";
        private const string _nombre = " comp_nombre AS Nombre ";
        private const string _ip = " comp_ip AS Ip ";
        private const string _submascara = " comp_submascara AS Submascara ";
        private const string _fechaAdquisicion = " comp_fecha_adquisicion AS FechaAdqui ";

        protected NpgsqlConnection bdConexion()
        {
            return new ConexionBD().conectar();
        }
        public bool Actualizar(Computadora obj)
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
                    obj.Sala.SalaId,
                    obj.Ip,
                    obj.Submascara,
                    obj.FechaAdqui,
                    obj.CompId
                });
                return result > 0;
            }
        }

        public Computadora Detalle(int id)
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
                    " FROM camputadoras WHERE comp_id = @Id";

                return bd.QueryFirstOrDefault<Computadora>(sentenciaSQL, new { Id = id });
            }
        }

        public bool Eliminar(Computadora obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "DELETE FROM public.computadoras WHERE comp_id = @Id";
                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.CompId
                });
                return result > 0;
            }
        }

        public IEnumerable<Computadora> GetAll()
        {
            var bd = bdConexion();
            string sentenciaSQL = "SELECT " +
                    "  comp_id AS CompId" +
                    ", sala_id AS SalaId" +
                    ", comp_nombre AS Nombre " +
                    ", comp_ip AS Ip " +
                    ", comp_submascara AS Submascara " +
                    ", comp_fecha_adquisicion AS FechaAdqui " +
                    " FROM camputadoras";

            return bd.Query<Computadora>(sentenciaSQL);
        }

        public bool Insertar(Computadora obj)
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
                    obj.Sala.SalaId,
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
