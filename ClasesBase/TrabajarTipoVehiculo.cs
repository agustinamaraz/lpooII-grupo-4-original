using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarTipoVehiculo
    {
        public static DataTable traerTipoVehiculo()
        {
            SqlConnection connection = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandText = "select_tipovehiculo_sp";
            command.CommandType = CommandType.StoredProcedure; 
            command.Connection = connection;

            DataTable datatable = new DataTable();
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);

            dataadapter.Fill(datatable);

            return datatable;
        }

        public static DataTable traerVehiculos()
        {
            //ObservableCollection<TipoVehiculo> vehiculos = new ObservableCollection<TipoVehiculo>();
            SqlConnection connection = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandText = "select_tipovehiculo_sp";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            DataTable datatable = new DataTable();
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);

            dataadapter.Fill(datatable);

            return datatable;
        }

        public static TipoVehiculo traerVehiculoPatente(int id)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command = new SqlCommand();
            command.CommandText = "traerVehiculoId_sp";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.Parameters.AddWithValue("@id", id);

            SqlDataAdapter dataadapter = new SqlDataAdapter(command);

            DataTable datatable = new DataTable();
            dataadapter.Fill(datatable);

            TipoVehiculo tipoVehiculo = new TipoVehiculo();
            foreach (DataRow row in datatable.Rows)
            {
                tipoVehiculo.TipoV_Codigo = int.Parse(row["tipov_codigo"].ToString());
                tipoVehiculo.TipoV_Descripcion = row["tipov_descripcion"].ToString();
                tipoVehiculo.TipoV_Tarifa = decimal.Parse(row["tipov_tarifa"].ToString());
            }
            return tipoVehiculo;
        }
    }
}
