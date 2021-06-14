using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace Monitor_de_salas_de_computo.Modelo
{
    class AdaptadorModelo
    {

        public DataTable ConvertirListaToDataTable(IList data)
        {

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Usuario));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties) table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (Usuario item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties) row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }

    
}
