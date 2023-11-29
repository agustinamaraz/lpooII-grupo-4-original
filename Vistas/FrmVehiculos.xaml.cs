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
using Microsoft.Win32;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for FrmVehiculos.xaml
    /// </summary>
    public partial class FrmVehiculos : Window
    {
        public FrmVehiculos()
        {
            InitializeComponent();
        }

        private void btnGuardarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            TipoVehiculo tipoVehiculo = new TipoVehiculo();
            if (MessageBox.Show("Confirma que los datos ingresados con correctos?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                tipoVehiculo.TipoV_Codigo = int.Parse(txtTVCodigo.Text);
                tipoVehiculo.TipoV_Descripcion = txtDescripcion.Text;
                tipoVehiculo.TipoV_Tarifa = Convert.ToDecimal(txtTarifa.Text);
                tipoVehiculo.TipoV_Imagen = txtImagenPath.Text;
                MessageBox.Show("TV Codigo: " + tipoVehiculo.TipoV_Codigo + "\nDescripcion: " + tipoVehiculo.TipoV_Descripcion + "\nTarifa: " + tipoVehiculo.TipoV_Tarifa);
                TrabajarTipoVehiculo.nuevoVehiculo(tipoVehiculo);
                txtDescripcion.Clear();
                txtTarifa.Clear();
                txtTVCodigo.Clear();
                txtImagenPath.Clear();
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

        private void btnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                txtImagenPath.Text = imagePath;

                // Muestra la imagen en el control Image
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                imgVehiculo.Source = bitmap;
            }
        }
    }
}
