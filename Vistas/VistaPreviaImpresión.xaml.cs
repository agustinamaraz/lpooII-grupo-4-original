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
    /// Interaction logic for VistaPreviaImpresión.xaml
    /// </summary>
    public partial class VistaPreviaImpresión : Window
    {
        CollectionViewSource cvs = new CollectionViewSource();
        public VistaPreviaImpresión(CollectionViewSource v)
        {
            InitializeComponent();
            viewUsuarios.ItemsSource = v.View;
            cvs = v;
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            FlowDocs fd = new FlowDocs(cvs);
            fd.Show();
            this.Close();
        }

    }
}
