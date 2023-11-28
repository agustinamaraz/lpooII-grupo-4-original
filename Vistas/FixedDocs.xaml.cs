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
        public FixedDocs()
        {
            InitializeComponent();
        }
        Ticket ticket = new Ticket();
        
        private void llenarTxt()
        {
            ticket.Tick_Numero = RegistrarEntrada.prueba[0].Tick_Numero;
            ticket.Tick_FechaHoraEntra = RegistrarEntrada.prueba[0].Tick_FechaHoraEntra;
            ticket.Tick_FechaHoraSale = RegistrarEntrada.prueba[0].Tick_FechaHoraSale;
            ticket.Cli_Dni = RegistrarEntrada.prueba[0].Cli_Dni;
            ticket.TipoV_Codigo = RegistrarEntrada.prueba[0].TipoV_Codigo;
            ticket.Tick_Patente = RegistrarEntrada.prueba[0].Tick_Patente;
            ticket.Tick_Duracion = RegistrarEntrada.prueba[0].Tick_Duracion;
            ticket.Tick_Tarifa = RegistrarEntrada.prueba[0].Tick_Tarifa;
            ticket.Tick_Total = RegistrarEntrada.prueba[0].Tick_Total;
        }

        private void llenarCampos()
        {
            Cliente cliente = new Cliente();
            TipoVehiculo tipo = new TipoVehiculo();
            cliente = traerCliente();
            txtNroTicket.Text = ticket.Tick_Numero.ToString();
            txtApellidoNombre.Text = cliente.Cli_Apellido+cliente.Cli_Nombre;
            txtPatente.Text = ticket.Tick_Patente;
            txtFechaEntra.Text = ticket.Tick_FechaHoraEntra.ToString();
            txtTipoVehiculo.Text = tipo.TipoV_Descripcion;
            txtTarifa.Text = ticket.Tick_Tarifa.ToString();
            txtTotal.Text = ticket.Tick_Total.ToString();
            txtOperador.Text = "Operador";


        }

        private Cliente traerCliente()
        {
            return TrabajarCliente.traerCliente(ticket.Cli_Dni.ToString());
        }

        private TipoVehiculo traerTipoVehiculo()
        {
            return TrabajarTipoVehiculo.traerVehiculoPatente(int.Parse(ticket.Tick_Patente));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            llenarTxt();
            llenarCampos();
        }
    }
}
