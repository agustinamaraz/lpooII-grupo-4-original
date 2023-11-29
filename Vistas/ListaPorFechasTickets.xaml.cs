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
using System.Data;

using ClasesBase;


namespace Vistas
{
    /// <summary>
    /// Interaction logic for ListaPorFechasTickets.xaml
    /// </summary>
    public partial class ListaPorFechasTickets : Window
    {

        DataTable dtVentas;
        string totalVentas;
        string total;


        public ListaPorFechasTickets()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgVentas.ItemsSource = dtVentas.DefaultView;
            //totalDeVentas.Text = totalVentas;
        }

                private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerFechaEntrada.SelectedDate == null && datePickerFechaSalida.SelectedDate == null)
            {
                dtVentas = TrabajarTicket.traerTicketsDataTable();
                dgVentas.ItemsSource = dtVentas.DefaultView;

                object resultado = dtVentas.Compute("SUM(tkt_Total)", "");
                if (resultado != DBNull.Value)
                {
                    total = Convert.ToString(resultado);
                    txtTotal.Text = total;
                }
                else
                {
                    total = "0";
                    txtTotal.Text = total;
                }
            }
            else if (datePickerFechaEntrada.SelectedDate == null || datePickerFechaSalida.SelectedDate == null)
            {
                MessageBox.Show("Ingrese un rango de fechas", "Error");
            }
            else if (datePickerFechaEntrada.SelectedDate > datePickerFechaSalida.SelectedDate)
            {
                MessageBox.Show("Ingrese un rango de fechas posible", "Error");
            }
            else
            {
                dtVentas = TrabajarTicket.traerTicketsFechas(datePickerFechaEntrada.SelectedDate.Value, datePickerFechaSalida.SelectedDate.Value);
                dgVentas.ItemsSource = dtVentas.DefaultView;
                Console.WriteLine("Información de dtVentas:");
foreach (DataRow row in dtVentas.Rows)
{
    foreach (DataColumn col in dtVentas.Columns)
    {
        Console.Write(string.Format("{0}: {1} | ", col.ColumnName, row[col]));
    }
    Console.WriteLine();
}

                object resultado = dtVentas.Compute("SUM(Tick_Total)", "");
                if (resultado != DBNull.Value)
                {
                    total = Convert.ToString(resultado);
                    txtTotal.Text = total;
                }
                else
                {
                    total = "0";
                    txtTotal.Text = total;
                }
            }
        }
                private void btnImprimir_Click(object sender, RoutedEventArgs e)
                {
                    if (TieneDatos(dtVentas))
                    {
                        VistaPreviaVentas vistaPreviaVentasWindow = new VistaPreviaVentas(dtVentas, total);
                        vistaPreviaVentasWindow.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No hay datos para imprimir", "Error");
                    }

                }

                static bool TieneDatos(DataTable dataTable)
                {
                    // Verificar si hay al menos una fila en el DataTable
                    return (dataTable != null && dataTable.Rows.Count > 0);
                }
    }
}
