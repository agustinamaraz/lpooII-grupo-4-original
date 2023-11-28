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

        /*
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Password;

            Usuario user = new Usuario("admin","admin");
            Usuario user2 = new Usuario("operador", "operador");

            MainWindow main = new MainWindow();

            if (user.Usr_UserName == usuario && user.User_Password == contrasena)
            {
                MessageBox.Show("Bienvenido, Administrador");
                rol = "1";
                // Realiza las acciones necesarias para el usuario Admin
                main.Show();
                this.Hide();
            }
            else if (user2.Usr_UserName == usuario && user2.User_Password == contrasena)
            {
                MessageBox.Show("Bienvenido, Operador");
                rol = "2";
                // Realiza las acciones necesarias para el usuario Operador
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }*/

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        /*
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea salir del Programa?", "Salir", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }*/

    }
}
