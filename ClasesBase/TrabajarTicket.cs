using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarTicket
    {
        public static void nuevoTicket(Ticket ticket)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "nuevoTicket_sp";
            command.Connection = connection;

            command.Parameters.AddWithValue("@fechaE",ticket.Tick_FechaHoraEntra);
            command.Parameters.AddWithValue("@fechaS", ticket.Tick_FechaHoraSale);
            command.Parameters.AddWithValue("@dni", ticket.Cli_Dni);
            command.Parameters.AddWithValue("@vehiculo", ticket.TipoV_Codigo);
            command.Parameters.AddWithValue("@sector", ticket.Sec_Codigo);
            command.Parameters.AddWithValue("@patente", ticket.Tick_Patente);
            command.Parameters.AddWithValue("@duracion", ticket.Tick_Duracion);
            command.Parameters.AddWithValue("@tarifa", ticket.Tick_Tarifa);
            command.Parameters.AddWithValue("@total", ticket.Tick_Total);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    

        public static ObservableCollection<Ticket> traerTickets()
        {
            ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "traerTickets_sp";
            command.Connection = connection;

            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();

            dataadapter.Fill(datatable);

            foreach (DataRow row in datatable.Rows)
            {
                Ticket tick = new Ticket();
                tick.Tick_Numero = int.Parse(row["tick_codigo"].ToString());
                tick.Tick_FechaHoraEntra = DateTime.Parse(row["tick_fechahoraentra"].ToString());
                tick.Tick_FechaHoraSale = DateTime.Parse(row["tick_fechahorasale"].ToString());
                tick.Cli_Dni = int.Parse(row["cli_dni"].ToString());
                tick.TipoV_Codigo = int.Parse(row["tipov_codigo"].ToString());
                tick.Sec_Codigo = int.Parse(row["sec_codigo"].ToString());
                tick.Tick_Patente = row["tick_patente"].ToString();
                tick.Tick_Duracion = int.Parse(row["tick_duracion"].ToString());
                tick.Tick_Tarifa = decimal.Parse(row["tick_tarifa"].ToString());
                tick.Tick_Total = decimal.Parse(row["tick_total"].ToString());

                tickets.Add(tick);
            }

            return tickets;
        }

        /*public static DataTable traerTicketsCosdigo(string codigo)
        {
            SqlConnection conection = new SqlConnection(Properties.Settings.Default.connection);
        }*/
    }
}
