using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor_de_salas_de_computo.Modelo
{
    public interface ICRUD<T>
    {
        IEnumerable<T> GetAll();
        T Detalle(int id);
        bool Insertar(T obj);
        bool Actualizar(T obj);
        bool Eliminar(T obj);
    }
}
