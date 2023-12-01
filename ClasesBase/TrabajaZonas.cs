using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
    public class TrabajarZonas
    {
        public static DataTable traerZonas()
        {
            //ObservableCollection<TipoVehiculo> vehiculos = new ObservableCollection<TipoVehiculo>();
            SqlConnection connection = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandText = "select_zonas_sp";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            DataTable datatable = new DataTable();
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);

            dataadapter.Fill(datatable);

            return datatable;
        }
    }
}