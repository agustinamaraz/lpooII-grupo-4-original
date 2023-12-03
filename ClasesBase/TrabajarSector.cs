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
                AND tkt.tick_total = 0"; // Solo incluir sectores con tickets y que no tengan fecha de salida

                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                // Agregar la columna TiempoTranscurrido al DataTable
                dt.Columns.Add("TiempoTranscurrido", typeof(string));

                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable TraerSectoresPorZona(int zonaCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Sector WHERE zona_codigo = @ZonaCodigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            // Agrega el parámetro para el código de zona
            cmd.Parameters.AddWithValue("@ZonaCodigo", zonaCodigo);

            // Ejecuta la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Llena los datos de la consulta en el DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        //PARA ABM SECTOR

        public static void AgregarSector(Sector nuevoSector)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Sector (sec_descripcion, sec_habilitado, sec_id, zona_codigo, sec_codigo) " +
                              "VALUES (@Descripcion, @Habilitado, @Identificador, @ZonaCodigo, @SectorCodigo)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@Descripcion", nuevoSector.Sec_Descripcion);
            cmd.Parameters.AddWithValue("@Habilitado", nuevoSector.Sec_Habilitado);
            cmd.Parameters.AddWithValue("@Identificador", nuevoSector.Sec_Id);
            cmd.Parameters.AddWithValue("@ZonaCodigo", nuevoSector.Zona_Codigo);
            cmd.Parameters.AddWithValue("@SectorCodigo", nuevoSector.Sec_Codigo);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar sector: " + ex);
            }
            finally
            {
                cnn.Close();
            }
        }

        public static void ModificarSector(Sector sectorModificado)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarSector_sp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@Descripcion", sectorModificado.Sec_Descripcion);
            cmd.Parameters.AddWithValue("@Habilitado", sectorModificado.Sec_Habilitado);
            cmd.Parameters.AddWithValue("@ZonaCodigo", sectorModificado.Zona_Codigo);
            cmd.Parameters.AddWithValue("@Identificador", sectorModificado.Sec_Id);
            cmd.Parameters.AddWithValue("@SectorCodigo", sectorModificado.Sec_Codigo);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }

        public static void EliminarSector(int sectorCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Sector WHERE sec_codigo = @SectorCodigo";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@SectorCodigo", sectorCodigo);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }

        public static Sector BuscarSectorPorCodigo(int codigoSector)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Sector WHERE sec_codigo = @CodigoSector";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@CodigoSector", codigoSector);

            try
            {
                cnn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Sector sector = new Sector
                        {
                            Sec_Codigo = Convert.ToInt32(reader["sec_codigo"]),
                            Sec_Descripcion = Convert.ToString(reader["sec_descripcion"]),
                            Sec_Id = Convert.ToString(reader["sec_id"]),
                            Sec_Habilitado = Convert.ToBoolean(reader["sec_habilitado"]),
                            Zona_Codigo = Convert.ToInt32(reader["Zona_Codigo"])
                        };

                        return sector;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            finally
            {
                cnn.Close();
            }
        }

        public static DataTable traerTodosSectores()
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "traerTodosSectores_sp";
            command.Connection = connection;

            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();

            dataadapter.Fill(datatable);

            return datatable;
        }
    }

}
