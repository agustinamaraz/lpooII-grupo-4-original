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

        decimal total = 0;

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
        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }




        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNro.Text))
                {
                    ticketElegido = TrabajarTicket.traerTicketSingular(txtNro.Text);
                    if (ticketElegido.Tick_Duracion != 0)
                    {
                        MessageBox.Show("Este ticket ya fue registrado como venta");
                    }
                    else
                    {
                        // Actualiza los TextBox con la información del ticket encontrado
                        txtApellido.Text = ticketElegido.Cli_Dni.ToString();
                        txtFechaHoraEntra.Text = ticketElegido.Tick_FechaHoraEntra.ToString();

                        ticketElegido.Tick_FechaHoraSale = DateTime.Now;

                        ticketElegido.Tick_Duracion = 0;
                        ticketElegido.Tick_Total = 0;
                        calcularTotal(ticketElegido);

                        txtFechaHoraSale.Text = DateTime.Now.ToString();

                        txtTipoVehiculo.Text = ticketElegido.TipoV_Codigo.ToString();
                        txtSector.Text = ticketElegido.Sec_Codigo.ToString();
                        txtPatente.Text = ticketElegido.Tick_Patente;
                        txtDuracion.Text = ticketElegido.Tick_Duracion.ToString();
                        txtTarifa.Text = ticketElegido.Tick_Tarifa.ToString();
                        txtTotal.Text = ticketElegido.Tick_Total.ToString();
                    }
                }
                else
                {
                    if (ticketElegido.Tick_Total > 0)
                    {
                        MessageBox.Show("Este ticket ya fue registrado anteriormente, no corresponde realizar una nueva salida");
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un número de ticket antes de buscar.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(txtNro.Text + "  " + ex);
                MessageBox.Show("Error al obtener el ticket");
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

            TrabajarSector.liberarSector(true, ticketElegido.Sec_Codigo);

            MessageBox.Show("Se agrego correctamente el ticket a las ventas");

            FixedDocsSalida fix = new FixedDocsSalida(ticketElegido);
            fix.Show();
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
            if (duracionTotal < 1)
            {
                // Si la duración es menor que 1 hora, establecerla en 1 hora
                duracionTotal = 1;
                duracionEnDouble = 1;
            }

            ticketObtenido.Tick_Duracion = duracionTotal;

            decimal duracionDecimal = new Decimal(duracionEnDouble);

            decimal totalAPagar = duracionDecimal * ticketElegido.Tick_Tarifa;
            totalAPagar = Math.Round(totalAPagar, 2);

            ticketObtenido.Tick_Total = totalAPagar;

            // Esto es lo que permitirá registrar luego el ticket
            total = decimal.Parse(totalAPagar.ToString());

            return total;
        }

        private void txtTotal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void txtDuracion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}