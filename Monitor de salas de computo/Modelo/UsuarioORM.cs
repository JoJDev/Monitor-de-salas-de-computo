using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Monitor_de_salas_de_computo.Modelo
{
    public class UsuarioORM : ICRUD<Usuario>
    {

        protected NpgsqlConnection bdConexion() {
            return new ConexionBD().conectar();
        }
        public bool Actualizar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Usuario Detalle(int id)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            var bd = bdConexion();
            string sentenciaSQL = "SELECT * FROM usuarios";

            return bd.Query<Usuario>(sentenciaSQL);
        }

        public bool Insertar(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
