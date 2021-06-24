using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor_de_salas_de_computo.Modelo
{
    class ConfiguracionesORM : ICRUD<Configuraciones>
    {
        protected NpgsqlConnection bdConexion()
        {
            return new ConexionBD().conectar();
        }
        public bool Actualizar(Configuraciones obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "UPDATE public.configuraciones SET " +
                    " sala_id = @SalaId" +
                    ", conf_tiempo_actualizar = @TiempoDeActualizacion" +
                    ", conf_tiempo_espera = @TiempoEnEspera" +
                    ", conf_perm_usb = @PermitirUSB" +
                    ", conf_num_registros_mostrados = @NumResgistrosMostrados" +
                    " WHERE conf_id = @ConfId";

                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.SalaId,
                    obj.TiempoDeActalizacion,
                    obj.TiempoEnEspera,
                    obj.PermitirUSB,
                    obj.NumRegistrosMostrados,
                    obj.ConfId
                });
                return result > 0;
            }
        }

        public Configuraciones Detalle(int id)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "SELECT " +
                    "  conf_id AS ConfId" +
                    ", sala_id AS SalaId" +
                    ", conf_tiempo_actualizar AS TiempoDeActualizacion" +
                    ", conf_tiempo_espera AS TiempoEnEspera" +
                    ", conf_perm_usb AS PermitirUSB" +
                    ", conf_num_registros_mostrados AS NumResgistrosMostrados" +
                    " FROM public.configuraciones WHERE conf_id = @Id";

                return bd.QueryFirstOrDefault<Configuraciones>(sentenciaSQL, new { Id = id });
            }
        }

        public bool Eliminar(Configuraciones obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "DELETE FROM public.configuraciones WHERE conf_id = @ConfId";
                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.ConfId
                });
                return result > 0;
            }
        }

        public IEnumerable<Configuraciones> GetAll()
        {
            var bd = bdConexion();
            string sentenciaSQL = "SELECT " +
                    "  conf_id AS ConfId" +
                    ", sala_id AS SalaId" +
                    ", conf_tiempo_actualizar AS TiempoDeActualizacion" +
                    ", conf_tiempo_espera AS TiempoEnEspera" +
                    ", conf_perm_usb AS PermitirUSB" +
                    ", conf_num_registros_mostrados AS NumResgistrosMostrados" +
                    " FROM public.configuraciones";

            return bd.Query<Configuraciones>(sentenciaSQL);
        }

        public bool Insertar(Configuraciones obj)
        {
            using (var bd = bdConexion())
            {
                string sentenciaSQL = "INSERT INTO public.configuraciones " +
                    " sala_id " +
                    ", conf_tiempo_actualizar " +
                    ", conf_tiempo_espera " +
                    ", conf_perm_usb " +
                    ", conf_num_registros_mostrados " +
                    " VALUES (@SalaID,@TiempoDeActualizacion,@TiempoEnEspera,@PermitirUSB,@NumRegistrosMostrados)";

                int result = bd.Execute(sentenciaSQL, new
                {
                    obj.SalaId,
                    obj.TiempoDeActalizacion,
                    obj.TiempoEnEspera,
                    obj.PermitirUSB,
                    obj.NumRegistrosMostrados
                });
                return result > 0;
            }
        }
    }
}
