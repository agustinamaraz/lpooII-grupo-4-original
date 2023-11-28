using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ListadoDeUsuarios.xaml
    /// </summary>
    public partial class ListadoDeUsuarios : Window
    {
        public static CollectionViewSource vistaColeccionFiltrada;

        public ListadoDeUsuarios()
        {
            InitializeComponent();

            //se accede al recurso CollectionViewSource
            vistaColeccionFiltrada = Resources["VISTA_USER"] as CollectionViewSource;
        }

        private void txtUsernameFiltro_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
            {
                //Se indica el metodo eventVistaUsuario Filter a medida que escriba en el textBox
                vistaColeccionFiltrada.Filter += eventVistaUsuario_Filter;
            }
        }


        //El filtro debe ser en la vista
        /*private void btnFiltroUsername_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Usuario> usuarios = new ObservableCollection<Usuario>();
            DataTable datatable = new DataTable();
            Usuario usuario = new Usuario();
            
            datatable = TrabajarUsuario.traerUsuariosFiltrados(txtUsernameFiltro.ToString());
            foreach (DataRow row in datatable.Rows)
            {
                usuario.Usr_Id = int.Parse(row["usr_id"].ToString());
                usuario.Usr_UserName = row["usr_username"].ToString();
                usuario.Usr_Password = row["usr_password"].ToString();
                usuario.Usr_Apellido = row["usr_apellido"].ToString();
                usuario.Usr_Nombre = row["usr_nombre"].ToString();
                usuario.Usr_Email = row["usr_email"].ToString();
                usuario.Usr_Rol = row["usr_rol"].ToString();
                usuarios.Add(usuario);
            }
            viewUsuarios.DataContext = usuarios;
        }*/

        private void eventVistaUsuario_Filter(object sender, FilterEventArgs e)
        {
            Usuario usuario = e.Item as Usuario;

            if (usuario.Usr_UserName.StartsWith(txtUsernameFiltro.Text, StringComparison.CurrentCultureIgnoreCase))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void btnVistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            VistaPreviaImpresión vpi = new VistaPreviaImpresión();
            this.Hide();
            vpi.Show();
//            vpi.ActualWidth;
        }
    }
}
