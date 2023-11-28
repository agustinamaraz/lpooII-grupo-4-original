using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    //para arreglar la referencia a la clase en el xaml (vista hay que referenciar con static a la clase en su constructor si parametrizar)
    public class TrabajarUsuario
    {
        public static ObservableCollection<Usuario> traerUsuarios()
        {
            ObservableCollection<Usuario> listaUsuario = new ObservableCollection<Usuario>();

            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "listarUsuarios_sp";
            command.Connection = connection;

            SqlDataAdapter dataadapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();

            dataadapter.Fill(datatable);

            foreach (DataRow row in datatable.Rows)
            {
                Usuario usuario = new Usuario();
                usuario.Usr_Id = int.Parse(row["usr_id"].ToString());
                usuario.Usr_UserName = row["usr_username"].ToString();
                usuario.Usr_Password = row["usr_password"].ToString();
                usuario.Usr_Apellido = row["usr_apellido"].ToString();
                usuario.Usr_Nombre = row["usr_nombre"].ToString();
                usuario.Usr_Email = row["usr_email"].ToString();
                usuario.Usr_Rol = row["usr_rol"].ToString();

                listaUsuario.Add(usuario);
            }

            return listaUsuario;
        }
        public static void nuevoUsuario(Usuario usuario) {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "nuevoUsuario_sp";
            command.Connection = connection;

            command.Parameters.AddWithValue("@username", usuario.Usr_UserName);
            command.Parameters.AddWithValue("@password", usuario.Usr_Password);
            command.Parameters.AddWithValue("@apellido", usuario.Usr_Apellido);
            command.Parameters.AddWithValue("@nombre", usuario.Usr_Nombre);
            command.Parameters.AddWithValue("@email", usuario.Usr_Email);
            command.Parameters.AddWithValue("@rol", usuario.Usr_Rol);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void eliminarUsuario(int id){
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "eliminarUsuario_sp";
            command.Connection = connection;

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void modificarUsuario(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "modificarUsuario_sp";
            command.Connection = connection;

            command.Parameters.AddWithValue("@id", usuario.Usr_Id);
            command.Parameters.AddWithValue("@user", usuario.Usr_UserName);
            command.Parameters.AddWithValue("@password", usuario.Usr_Password);
            command.Parameters.AddWithValue("@apellido", usuario.Usr_Apellido);
            command.Parameters.AddWithValue("@nombre", usuario.Usr_Nombre);
            command.Parameters.AddWithValue("@email", usuario.Usr_Email);
            command.Parameters.AddWithValue("@rol", usuario.Usr_Rol);


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        /*public static DataTable traerUsuariosOrdenadosUsuario()
        {
            ObservableCollection<Usuario> usuariosOrdenados = new ObservableCollection<Usuario>();
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "traerUsuariosOrdenadosUsuario_sp";
            command.Connection = connection;

            DataTable datatable = new DataTable();
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);

            dataadapter.Fill(datatable);

            return datatable;
        }

        public static DataTable traerUsuariosFiltrados(string filtro)
        {
            ObservableCollection<Usuario> usuariosOrdenados = new ObservableCollection<Usuario>();
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "traerUsuarioFiltrado_sp";
            command.Connection = connection;

            command.Parameters.AddWithValue("@filtro",filtro);

            DataTable datatable = new DataTable();
            SqlDataAdapter dataadapter = new SqlDataAdapter(command);

            dataadapter.Fill(datatable);

            return datatable;
        }*/

    }
}
