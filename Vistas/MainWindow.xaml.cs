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
                btnFrmClientes.Visibility = Visibility.Hidden;
                btnFrmVehiculoEnPlaya.Visibility = Visibility.Hidden;
            }
            else if (Login.rol == "2")
            {
                btnFrmSectores.Visibility = Visibility.Hidden;
                btnFrmVehiculos.Visibility = Visibility.Hidden;
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
            FrmClientes formClientes = new FrmClientes();
            formClientes.Show();
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
            FrmSectores formS = new FrmSectores();
            formS.Show();
            this.Close();
        }

        private void btnFrmVehiculoEnPlaya_Click(object sender, RoutedEventArgs e)
        {
            VehiculosEnPlaya vehiculo = new VehiculosEnPlaya();
            vehiculo.Show();
            this.Hide();
        }


    }
}
