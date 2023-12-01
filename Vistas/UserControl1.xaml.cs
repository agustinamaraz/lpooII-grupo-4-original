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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        Usuario login;
        public static string rol = "";
        public UserControl1()
        {
            InitializeComponent();
        }
        public String Usuario
        {
            get { return txtUsuario.Text; }
        }

        public String Password
        {
            get { return txtContrasena.Password; }
        }


    }
}
