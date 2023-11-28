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
    /// Interaction logic for FrmSectores.xaml
    /// </summary>
    public partial class FrmSectores : Window
    {
        public FrmSectores()
        {
            InitializeComponent();
        }

        private void btnGuardarSector_Click(object sender, RoutedEventArgs e)
        {
            Sector sector = new Sector();
            if (MessageBox.Show("Confirma que los datos ingresados con correctos?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                sector.Sec_Codigo = int.Parse(txtSectorCodigo.Text);
                sector.Sec_Descripcion = txtDescripcion.Text;
                sector.Sec_Id = txtIdentificador.Text;
                if (chkHabilitado.IsChecked == true)
                {
                    sector.Sec_Habilitado = true;
                }
                else
                {
                    sector.Sec_Habilitado = false;
                }
            }       

                MessageBox.Show("Sector Codigo: "+sector.Sec_Codigo+"\nDescripcion: "+sector.Sec_Descripcion+"\nIdentificador: "+sector.Sec_Id+"\nHabilitado: "+sector.Sec_Habilitado);
                txtDescripcion.Clear();
                txtIdentificador.Clear();
                txtSectorCodigo.Clear();
                chkHabilitado.IsChecked = false;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
    }
}
