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
        public Usuario login;
        public static string rol = "";
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = control.Usuario;
            string contrasena = control.Password;

            //Usuario user = new Usuario("admin", "admin");
            //Usuario user2 = new Usuario("operador", "operador");
            login = TrabajarUsuario.findLogin(usuario, contrasena);


            if (login != null)
            {
                MainWindow main = new MainWindow();
                if (login.Usr_Rol == "Administrador")
                {
                    MessageBox.Show("Bienvenido, Administrador");
                    rol = "1";
                    // Realiza las acciones necesarias para el usuario Admin
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bienvenido, Operador");
                    rol = "2";
                    // Realiza las acciones necesarias para el usuario Operador
                    main.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }

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
