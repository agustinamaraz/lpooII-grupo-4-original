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
using Vistas;
using System.Collections.ObjectModel;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for FixedDocs.xaml
    /// </summary>
    public partial class FixedDocs : Window
    {
        public FixedDocs(Ticket t)
        {
            InitializeComponent();
            llenarCampos(t);
        }

        private void llenarCampos(Ticket ticket)
        {
            Cliente cliente = traerCliente(ticket);
            TipoVehiculo tipo = traerTipoVehiculo(ticket);

            string nombres = cliente.Cli_Apellido + " " + cliente.Cli_Nombre;

            txtNroTicket.Text = ticket.Tick_Numero.ToString();
            txtApellidoNombre.Text = nombres;
            txtPatente.Text = ticket.Tick_Patente;
            txtFechaEntra.Text = ticket.Tick_FechaHoraEntra.ToString();
            txtTipoVehiculo.Text = tipo.TipoV_Descripcion;
            txtTarifa.Text = ticket.Tick_Tarifa.ToString();
            txtTotal.Text = ticket.Tick_Total.ToString();
            txtOperador.Text = "Operador";


        }

        private Cliente traerCliente(Ticket ticket)
        {
            return TrabajarCliente.traerCliente(ticket.Cli_Dni.ToString());
        }

        private TipoVehiculo traerTipoVehiculo(Ticket ticket)
        {
            return TrabajarTipoVehiculo.traerVehiculoPatente(ticket.TipoV_Codigo);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
