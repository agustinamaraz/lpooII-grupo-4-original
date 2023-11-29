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
    /// Interaction logic for registrarSalida.xaml
    /// </summary>
    public partial class registrarSalida : Window
    {

        ObservableCollection<Ticket> listaTicket;
        DataTable listaTipoVehiculo = new DataTable();
        private CollectionViewSource vistaColeccionFiltradaTicket;
        public static ObservableCollection<Ticket> prueba;


        Ticket ticketElegido = new Ticket();

        string numeroString;
        double duracionTiempo;
        decimal total = 0;
        decimal sDuracion = 0;
        decimal sTarifa = 0;

        public registrarSalida()
        {
            InitializeComponent();
            vistaColeccionFiltradaTicket = Resources["VISTA_TICK"] as CollectionViewSource;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_TICK"];
            listaTicket = odp.Data as ObservableCollection<Ticket>;
            ObjectDataProvider odp1 = (ObjectDataProvider)this.Resources["LIST_TIPO"];
            listaTipoVehiculo = odp1.Data as DataTable;

            cargarComboVehiculo();
        }


     

        private void txtNro_TextChanged(object sender, TextChangedEventArgs e)
        {

    try
    {
 
        ticketElegido = TrabajarTicket.traerTicketSingular(txtNro.Text);
        ticketElegido.Tick_Duracion = 0;
        ticketElegido.Tick_Total = 0;
        txtApellido.Text = ticketElegido.Cli_Dni.ToString();
        txtFechaHoraEntra.Text = ticketElegido.Tick_FechaHoraEntra.ToString();
        ticketElegido.Tick_FechaHoraSale = DateTime.Now;
        calcularTotal(ticketElegido);
        txtFechaHoraSale.Text = ticketElegido.Tick_FechaHoraSale.ToString();
        txtTipoVehiculo.Text = ticketElegido.TipoV_Codigo.ToString();
        txtSector.Text = ticketElegido.Sec_Codigo.ToString();
        txtPatente.Text = ticketElegido.Tick_Patente;
        txtDuracion.Text = ticketElegido.Tick_Duracion.ToString();
        txtTarifa.Text = ticketElegido.Tick_Tarifa.ToString();
        txtTotal.Text = ticketElegido.Tick_Total.ToString();

    }
    catch (Exception ex)
    {
        // Manejar la excepción aquí (puedes mostrar un mensaje al usuario, registrar el error, etc.)
        MessageBox.Show("Error al obtener el ticket" + ex.Message);
    }
        }
        private void txtApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
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

            TrabajarTicket.modificarTicket(ticketElegido);

            TrabajarSector.liberarSector(false, ticketElegido.Sec_Codigo);

            MessageBox.Show("se agrego correctamente");

            //FixedDocs fix = new FixedDocs();
            //fix.Show();
            this.Hide();
        }

        private decimal calcularTotalHora(decimal tar, decimal dur)
        {
           dur = dur / 60;
           decimal total = tar * decimal.Parse(dur.ToString());
           return Math.Round(total, 2);
        }


        private void txtTarifa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



      
        private void consulta()
        {
            TrabajarTicket.traerTickets();

        }

        public decimal calcularTotal(Ticket ticketObtenido)
        {
            TimeSpan duracion = ticketObtenido.Tick_FechaHoraSale - ticketObtenido.Tick_FechaHoraEntra;

            double duracionEnDouble = duracion.TotalHours;
           double duracionTotal = Math.Round(duracionEnDouble, 1);


            ticketObtenido.Tick_Duracion = duracionTotal;

            decimal duracionDecimal = new Decimal(duracionEnDouble);

            decimal totalAPagar = duracionDecimal * ticketElegido.Tick_Tarifa;
            totalAPagar = Math.Round(totalAPagar, 2);

            ticketObtenido.Tick_Total = totalAPagar;

            //Esto es lo permitira registrar luego el ticket
            total = decimal.Parse(totalAPagar.ToString());
            return total;
        }

        private void txtTotal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void txtDuracion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
