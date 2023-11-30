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

        //SECTORES OCUPADOS

        public static DataTable TraerSectoresOcupados()
        {
            using (SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection))
            {
                cnn.Open();

                string query = @"
            SELECT 
                sec.*, 
                tkt.tick_codigo,
                tkt.tick_fechahoraentra,
                tkt.tick_fechahorasale,
                tkt.cli_dni,
                tkt.tipov_codigo,
                tkt.tick_duracion,
                tkt.tick_tarifa,
                tkt.tick_total,
                tkt.sec_codigo,
                tkt.tick_patente,
                cli.cli_Apellido + ', ' + cli.cli_Nombre AS Cliente,
                TV.tipov_descripcion AS TipoVehiculo
            FROM 
                Sector sec
            LEFT JOIN 
                Ticket tkt ON sec.sec_codigo = tkt.sec_codigo
            LEFT JOIN 
                Cliente cli ON tkt.cli_dni = cli.cli_dni
            LEFT JOIN 
                TipoVehiculo TV ON tkt.tipov_codigo = TV.tipov_codigo
            WHERE 
                tkt.sec_codigo IS NOT NULL
                AND tkt.tick_fechahorasale IS NULL"; // Solo incluir sectores con tickets y que no tengan fecha de salida

                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                // Agregar la columna TiempoTranscurrido al DataTable
                dt.Columns.Add("TiempoTranscurrido", typeof(string));

                da.Fill(dt);
                return dt;
            }
        }


    }
}
