using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase
{
    public class TrabajarSector
    {
        public static DataTable traerSectores()
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "traerSectores_sp";
            command.Connection = connection;

            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();

            dataadapter.Fill(datatable);

            return datatable;
        }

        public static void nuevoSector(Sector sector)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "nuevoSector_sp";
            command.Connection = connection;
            command.Parameters.AddWithValue("@descripcion", sector.Sec_Descripcion);
            command.Parameters.AddWithValue("@estado", sector.Sec_Habilitado);
            command.Parameters.AddWithValue("@id", sector.Sec_Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void liberarSector(Boolean booleano, int id)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "actualizarEstadoSector_sp";
            command.Connection = connection;
            command.Parameters.AddWithValue("@estado", booleano);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

    }
}
