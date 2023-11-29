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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ListadoDeUsuarios.xaml
    /// </summary>
    public partial class ListadoDeUsuarios : Window
    {
        private CollectionViewSource vistaColeccionFiltrada;

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
            CollectionViewSource cv = vistaColeccionFiltrada;
            VistaPreviaImpresión vpi = new VistaPreviaImpresión(cv);
            this.Hide();
            vpi.Show();
        }
    }
}
