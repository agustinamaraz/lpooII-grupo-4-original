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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for EstadoSector.xaml
    /// </summary>
    public partial class EstadoSector : Window
    {
        public EstadoSector()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("bep: " + comboBox1.SelectedValue.ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox1.SelectedValue = "90";
        }
    }
}
