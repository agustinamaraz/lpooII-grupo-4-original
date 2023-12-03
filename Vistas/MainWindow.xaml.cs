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
using System.Windows.Navigation;
using System.Windows.Shapes;

using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Login.rol == "1"){
                //btnListausuarios.Visibility = Visibility.Hidden;
            }
            else if (Login.rol == "2")
            {
                
                sectoresOcupados.Visibility = Visibility.Hidden;
                btnListausuarios.Visibility = Visibility.Hidden;
                btnListaVentas.Visibility = Visibility.Hidden;
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea salir del Programa?", "Salir", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void btnFrmClientes_Click(object sender, RoutedEventArgs e)
        {
            //FrmClientes formClientes = new FrmClientes();
            //formClientes.Show();

            ValidarCliente validarc = new ValidarCliente();
            validarc.Show();
            this.Close();
            
            
        }

        private void btnFrmVehiculos_Click(object sender, RoutedEventArgs e)
        {
            FrmVehiculos formV = new FrmVehiculos();
            formV.Show();
            this.Close();
        }

        private void btnFrmSectores_Click(object sender, RoutedEventArgs e)
        {
            ABMSector formS = new ABMSector();
            formS.Show();
            this.Close();
        }

        private void menuZonas_Click(object sender, RoutedEventArgs e)
        {
            Zonas zonasVista = new Zonas();
            zonasVista.Show();
            this.Close();
        }

        private void sectoresOcupados_Click(object sender, RoutedEventArgs e)
        {
            ListadoSectoresOcupados sectoresOcupadosWindow = new ListadoSectoresOcupados();
            sectoresOcupadosWindow.Show();
            this.Close();
        }
        private void btnRegistrarSalida_Click(object sender, RoutedEventArgs e)
        {
            registrarSalida registrarSalidaWindow = new registrarSalida();
            registrarSalidaWindow.Show();
            this.Close();
        }
        private void btnListaVentas_Click(object sender, RoutedEventArgs e)
        {
            ListaPorFechasTickets listaTicketsWindow = new ListaPorFechasTickets();
            listaTicketsWindow.Show();
            this.Close();
        }
        private void btnListaUsuarios_Click(object sender, RoutedEventArgs e)
        {
            ABMUsuarios abmUsuarioWindow = new ABMUsuarios();
            abmUsuarioWindow.Show();
            this.Close();
        }
    }
}
