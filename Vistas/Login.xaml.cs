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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static string rol = "";
        public Login()
        {
            InitializeComponent();
        }

       

        private void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnPresentacion_Click(object sender, RoutedEventArgs e)
        {
            AcercaDe a = new AcercaDe();
            a.Show();
        }

        private void btnAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            Presentacion p = new Presentacion();
            p.Show();
        }

    }
}
