using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor_de_salas_de_computo.Modelo
{
    class SalaORM
    {
        protected NpgsqlConnection bdConexion()
        {
            return new ConexionBD().conectar();
        }
        public bool Actualizar(Sala obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "UPDATE public.salas SET " +
                    "sala_nombre = @Nombre, sala_plantel = @Plantel" +
                    ",sala_ip_inicial = @IpInicial, sala_ip_final = @IpFinal" +
                    ",sala_gateway = @Gateway, sala_servidor = @Servidor" +
                    ",sala_encargado = @Encargado, sala_telefono = @Telefono " +
                    "WHERE sala_id = @SalaId";

                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.Nombre,
                    obj.Plantel,
                    obj.IpInicial,
                    obj.IpFinal,
                    obj.Gateway,
                    obj.Servidor,
                    obj.Encargado,
                    obj.Telefono,
                    obj.SalaId
                });
                return result > 0;
            }
        }

        public Sala Detalle(int id)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "SELECT " +
                    "  sala_id AS SalaId" +
                    ", sala_nombre AS Nombre" +
                    ", sala_plantel AS Plantel " +
                    ", sala_ip_inicial AS IpInicial " +
                    ", sala_ip_final AS IpFinal " +
                    ", sala_gateway AS Gateway" +
                    ", sala_servidor AS Servidor" +
                    ", sala_encargado AS Encargado" +
                    ", sala_telefono AS Telefono" +
                    " FROM public.salas WHERE sala_id = @SalaId";

                return bd.QueryFirstOrDefault<Sala>(sentenciaSQL, new { SalaId = id });
            }
        }

        public bool Eliminar(Sala obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "DELETE FROM public.salas WHERE sala_id = @SalaId";
                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.SalaId
                });
                return result > 0;
            }
        }

        public IEnumerable<Sala> GetAll()
        {
            var bd = bdConexion();
            string sentenciaSQL = "SELECT " +
                    "  sala_id AS SalaId" +
                    ", sala_nombre AS Nombre" +
                    ", sala_plantel AS Plantel " +
                    ", sala_ip_inicial AS IpInicial " +
                    ", sala_ip_final AS IpFinal " +
                    ", sala_gateway AS Gateway" +
                    ", sala_servidor AS Servidor" +
                    ", sala_encargado AS Encargado" +
                    ", sala_telefono AS Telefono" +
                    " FROM public.salas";

            return bd.Query<Sala>(sentenciaSQL);
        }

        public bool Insertar(Sala obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "INSERT INTO public.salas " +
                    " ( sala_nombre, sala_plantel, sala_ip_inicial, sala_ip_final, sala_gateway, sala_servidor, sala_encargado, sala_telefono)" +
                    " VALUES (@Nombre,@Plantel,@IpInicial,@IpFinal,@Gateway,@Servidor,@Encargado,@Telefono)";

                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.Nombre,
                    obj.Plantel,
                    obj.IpInicial,
                    obj.IpFinal,
                    obj.Gateway,
                    obj.Servidor,
                    obj.Encargado,
                    obj.Telefono
                });
                return result > 0;
            }
        }
    }
}
