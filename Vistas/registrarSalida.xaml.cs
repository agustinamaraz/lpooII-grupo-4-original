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
                        Console.WriteLine(ticketElegido.Tick_Tarifa.ToString());
                        ticketElegido.Tick_FechaHoraSale = DateTime.Now.AddHours(1);

                        ticketElegido.Tick_Duracion = 1;
                        ticketElegido.Tick_Total = ticketElegido.Tick_Tarifa;
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
            // Calcular la duración en horas
            TimeSpan duracion = ticketObtenido.Tick_FechaHoraSale - ticketObtenido.Tick_FechaHoraEntra;
            double duracionEnHoras = Math.Round(duracion.TotalHours, 1);

            // Establecer la duración mínima en 1 hora
            double duracionTotal = Math.Max(duracionEnHoras, 1);

            // Actualizar la duración en el ticket
            ticketObtenido.Tick_Duracion = duracionTotal;

            // Calcular el total a pagar
            decimal totalAPagar = (decimal)duracionTotal * ticketObtenido.Tick_Tarifa;

            // Ajustar el total si es 0 o menor que la tarifa
            if (totalAPagar <= 0)
            {
                totalAPagar = ticketObtenido.Tick_Tarifa;
                duracionTotal = 1;
                ticketObtenido.Tick_Duracion = 1;
            }

            // Redondear el total a dos decimales
            totalAPagar = Math.Round(totalAPagar, 2);

            // Actualizar el total en el ticket
            ticketObtenido.Tick_Total = totalAPagar;

            // Mostrar el total en la consola (puedes comentar o eliminar esta línea en producción)
            Console.WriteLine(totalAPagar.ToString());

            // Devolver el total calculado
            return totalAPagar;
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