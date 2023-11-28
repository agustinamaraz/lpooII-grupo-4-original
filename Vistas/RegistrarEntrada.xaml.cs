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
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for RegistrarEntrada.xaml
    /// </summary>
    public partial class RegistrarEntrada : Window
    {
        //CollectionView Vista;
        ObservableCollection<Cliente> listaCliente;
        DataTable listaTipoVehiculo = new DataTable();
        private CollectionViewSource vistaColeccionFiltrada;
        public static ObservableCollection<Ticket> prueba;

        //para la duracion
        decimal sDuracion = 0;
        decimal sTarifa = 0;

        public RegistrarEntrada()
        {
            InitializeComponent();
            vistaColeccionFiltrada = Resources["VISTA_CLI"] as CollectionViewSource;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_CLI"];
            listaCliente = odp.Data as ObservableCollection<Cliente>;
            ObjectDataProvider odp1 = (ObjectDataProvider)this.Resources["LIST_TIPO"];
            listaTipoVehiculo = odp1.Data as DataTable;

            seleccionarEntrada();
            cargarComboVehiculo();
        }

        public void seleccionarEntrada()
        {
            DateTime fechaentra = DateTime.Now;
            dateTimeEntraTicket.SelectedDate = fechaentra;
            //Desactivar los controles innecesarios como tarifa y total
            txtTarifa.IsEnabled = false;
            txtTotal.IsEnabled = false;
        }

        private void txtDniCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
            {
                //Se indica el metodo eventVistaUsuario Filter a medida que escriba en el textBox
                vistaColeccionFiltrada.Filter += eventVistaCliente_Filter;
            }
        }

        private void eventVistaCliente_Filter(object sender, FilterEventArgs e)
        {
            Cliente usuario = e.Item as Cliente;

            if (usuario.Cli_Dni.StartsWith(txtDniCliente.Text, StringComparison.CurrentCultureIgnoreCase))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        //tipovehiculo
        private void cargarComboVehiculo()
        {
            //cboTipoVehiculo.ItemsSource = TrabajarTipoVehiculo.traerVehiculos();
            //cboTipoVehiculo.SelectedValuePath = "tipov_descripcion";
            //cboTipoVehiculo.SelectedItem = "tipov_codigo";
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = new Ticket();
            ticket.Cli_Dni = int.Parse(txtDniCliente.Text);
            ticket.Tick_FechaHoraEntra = DateTime.Parse(dateTimeEntraTicket.ToString());
            ticket.Tick_FechaHoraSale = DateTime.Parse(dateTimeSaleTicket.ToString());
            ticket.Cli_Dni = int.Parse(txtDniCliente.Text.ToString());
            ticket.TipoV_Codigo = cboTipoVehiculo.SelectedIndex;
            ticket.Tick_Patente = txtPatente.Text.ToString();
            ticket.Tick_Duracion = float.Parse(cboDuracion.SelectedValue.ToString());
            ticket.Tick_Tarifa = decimal.Parse(txtTarifa.Text);
            ticket.Tick_Total = decimal.Parse(txtTotal.Text);
            ticket.Sec_Codigo = cboSector.SelectedIndex;

            TrabajarTicket.nuevoTicket(ticket);
            
            MessageBox.Show("se agrego correctamente");
            FixedDocs fix = new FixedDocs();
            fix.Show();
            this.Hide();
        }

        private void txtTarifa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cboTipoVehiculo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedValue = cboTipoVehiculo.SelectedIndex;
            sTarifa = decimal.Parse(listaTipoVehiculo.Rows[selectedValue][2].ToString());
            txtTarifa.Text = sTarifa.ToString();
            txtTotal.Text = (calcularTotal(sTarifa, sDuracion)).ToString();
        }

        private decimal calcularTotal(decimal tar, decimal dur)
        {
            dur = dur/60;
            decimal total = tar * decimal.Parse(dur.ToString());
            return Math.Round(total,2);
        }

        private void cboDuracion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sDuracion = decimal.Parse(cboDuracion.SelectedValue.ToString());
            txtTotal.Text = (calcularTotal(sTarifa, sDuracion)).ToString();
        }

        private void convertirFecha()
        {
            int HoraE = int.Parse(cboHoraEntrada.ToString());
            int MinutosE = int.Parse(cboHoraSalida.ToString());
            int HoraS = int.Parse(cboHoraSalida.ToString());
            int MinutosS = int.Parse(cboMinutosSalida.ToString());
            TimeSpan entrada = new TimeSpan(HoraE, MinutosE, 0);
            TimeSpan salida = new TimeSpan(HoraS, MinutosS, 0);


            //dateTimeEntraTicket = DateTime.Parse(dateTimeEntraTicket.ToString()) + entrada;
        }
        private void consulta()
        {
            TrabajarTicket.traerTickets();

        }
    }
}
