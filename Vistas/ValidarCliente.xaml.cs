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
using System.Data;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for ValidarCliente.xaml
    /// </summary>
    public partial class ValidarCliente : Window
    {
        public ValidarCliente()
        {
            InitializeComponent();
        }

        private static Cliente cliente = new Cliente();

        private void txtDni_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (chkboxModificar.IsChecked == true)
            {
                btnGuardar.Visibility = Visibility.Collapsed;
                btnActualizar.Visibility = Visibility.Visible;
                cliente = TrabajarCliente.traerCliente(txtDni.Text);
                txtApellido.Text = cliente.Cli_Apellido;
                txtNombre.Text = cliente.Cli_Nombre;
                txtTelefono.Text = cliente.Cli_Telefono;
            }
            else
            {
                btnGuardar.Visibility = Visibility.Visible;
                btnActualizar.Visibility = Visibility.Collapsed;
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Cliente oCliente = new Cliente();

            oCliente.Cli_Dni = txtDni.Text;
            oCliente.Cli_Apellido = txtApellido.Text;
            oCliente.Cli_Nombre = txtNombre.Text;
            oCliente.Cli_Telefono = txtTelefono.Text;

            TrabajarCliente.updateCliente(oCliente);

            //llamar funcion para que se muestren o se refresquen los datos cargados
            //load_clientes();
            //dataGridViewClientes.Rows[0].Cells[0].Selected = false;
            //limpiarFormulario();

            MessageBox.Show("¡Cliente modificado exitosamente!", "Modificado");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnActualizar.Visibility = Visibility.Collapsed;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Cliente oCliente = new Cliente();
          
                oCliente.Cli_Apellido = txtApellido.Text;
                oCliente.Cli_Nombre = txtNombre.Text;
                oCliente.Cli_Telefono = txtTelefono.Text;
                oCliente.Cli_Dni = txtDni.Text;
                string a = oCliente.Error;
                //

                if (a == "")
                {
                    MessageBoxResult msg = MessageBox.Show(oCliente.ToString(), "Confirmacion", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                    if (msg == MessageBoxResult.OK)
                    {
                        ClasesBase.TrabajarCliente.insertarCliente(oCliente);
                   
                    }
                }
                else
                {
                    MessageBoxResult msg = MessageBox.Show(a, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            
            
        }

        private void vaciarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDni.Clear();
            txtApellido.Clear();
        }
    }
}
