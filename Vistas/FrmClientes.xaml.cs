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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for FrmClientes.xaml
    /// </summary>
    public partial class FrmClientes : Window
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnGuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            if (MessageBox.Show("Confirma que los datos ingresados son correctos?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                cliente.Cli_Dni = txtDniCliente.Text;
                cliente.Cli_Apellido = txtApellido.Text;
                cliente.Cli_Nombre = txtNombre.Text;
                cliente.Cli_Telefono = txtTelefono.Text;

                MessageBox.Show("DNI: "+cliente.Cli_Dni+"\nApellido: "+cliente.Cli_Apellido+"\nNombre: "+cliente.Cli_Nombre+"\nTelefono: "+cliente.Cli_Telefono);
                txtApellido.Clear();
                txtDniCliente.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
    }
}
