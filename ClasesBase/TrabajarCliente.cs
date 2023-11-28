using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarCliente
    {
        public static ObservableCollection<Cliente> traerClientes(string dni){
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command = new SqlCommand();
            command.CommandText = "select_clientedni_sp";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.Parameters.AddWithValue("@cli_dni", dni);

            SqlDataAdapter dataadapter = new SqlDataAdapter(command);

            DataTable datatable = new DataTable();
            dataadapter.Fill(datatable);

            ObservableCollection<Cliente> clientes = new ObservableCollection<Cliente>();

            foreach (DataRow row in datatable.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.Cli_Apellido = row["cli_apellido"].ToString();
                cliente.Cli_Dni = row["cli_dni"].ToString();
                cliente.Cli_Nombre = row["cli_nombre"].ToString();
                cliente.Cli_Telefono = row["cli_telefono"].ToString();
                clientes.Add(cliente);
            }
            return clientes;
        }

        public static DataTable listaCliente()
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command = new SqlCommand();
            command.CommandText = "traerClientes_sp";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            SqlDataAdapter dataadapter = new SqlDataAdapter(command);

            DataTable datatable = new DataTable();
            dataadapter.Fill(datatable);

            return datatable;
        }

        public static Cliente traerCliente(string dni)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command = new SqlCommand();
            command.CommandText = "select_clientedni_sp";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.Parameters.AddWithValue("@dni", dni);

            SqlDataAdapter dataadapter = new SqlDataAdapter(command);

            DataTable datatable = new DataTable();
            dataadapter.Fill(datatable);

            Cliente cliente = new Cliente();
            foreach (DataRow row in datatable.Rows)
            {    
                cliente.Cli_Apellido = row["cli_apellido"].ToString();
                cliente.Cli_Dni = row["cli_dni"].ToString();
                cliente.Cli_Nombre = row["cli_nombre"].ToString();
                cliente.Cli_Telefono = row["cli_telefono"].ToString();
            }
            return cliente;
        }

        public static void insertarCliente(Cliente cliente){

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Cliente(cli_dni,cli_apellido,cli_nombre,cli_telefono) values(@dni,@apellido,@nombre,@telefono)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", cliente.Cli_Dni);
            cmd.Parameters.AddWithValue("@apellido", cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nombre", cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@telefono", cliente.Cli_Telefono);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void updateCliente(Cliente cliente)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.connection);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Cliente SET cli_apellido = @apellido , cli_nombre = @nombre , cli_telefono = @telefono WHERE cli_dni = @dni";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@dni", cliente.Cli_Dni);
            cmd.Parameters.AddWithValue("@apellido", cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nombre", cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@telefono", cliente.Cli_Telefono);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        
        public static ObservableCollection<Cliente> traerClientes()
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command = new SqlCommand();
            command.CommandText = "traerClientes_sp";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;


            SqlDataAdapter dataadapter = new SqlDataAdapter(command);

            DataTable datatable = new DataTable();
            dataadapter.Fill(datatable);

            ObservableCollection<Cliente> clientes = new ObservableCollection<Cliente>();

            foreach (DataRow row in datatable.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.Cli_Apellido = row["cli_apellido"].ToString();
                cliente.Cli_Dni = row["cli_dni"].ToString();
                cliente.Cli_Nombre = row["cli_nombre"].ToString();
                cliente.Cli_Telefono = row["cli_telefono"].ToString();
                clientes.Add(cliente);
            }
            return clientes;
        }
    }
}
